// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


using CommonCode;
using System.Buffers.Binary;

// Source in nif.xml: <compound name="Header">
namespace Nif_CSharp.DataReaders.Header
{
	public readonly struct NifHeaderSlim
	{
		public readonly uint NifVersion;
		public readonly bool IsLittleEndian;
		public readonly uint UserVersion;
		public readonly uint NumBlocks;
		public readonly uint BSVersion;

		public NifHeaderSlim(NifHeaderData _nifHeaderData)
		{
			NifVersion = _nifHeaderData.NifVersion;
			IsLittleEndian = _nifHeaderData.IsLittleEndian;
			UserVersion = _nifHeaderData.UserVersion;
			NumBlocks = _nifHeaderData.NumBlocks;
			BSVersion = _nifHeaderData.BSStreamHeader.BSVersion;
		}

		internal NifHeaderSlim(BinaryReader _NifRawDataStream, in string NifIdentifier, ref string _Error, out bool _CompletedSuccessfully)
		{
			// Set the initial state of these variables, to prevent "must be assigned upon exit" errors.
			NifVersion = 0;
			IsLittleEndian = true;	// default value if Endianness field not present.
			UserVersion = 0;
			NumBlocks = 0;
			BSVersion = 0;

			// First dozen or so bytes are titled the "HeaderString". It is an unprefixed & newline-terminated sequence of bytes
			// that is supposed to consist of the string: "NetImmerse/Gamebryo File Format" and then the file's version number.
			if (!CommonNifHeaderMethods._ReadNifHeader(_NifRawDataStream, in NifIdentifier, ref _Error, out _, out NifVersion))
			{
				_CompletedSuccessfully = false;
				return;
			}

			// NIFs up to v3.1.0.0 will have three unprefixed & newline-terminated sequences of bytes which makes up 3
			// strings designating the model's copyright info. The slim header doesn't need this so just skip over it.
			if (NifVersion <= 0x03010000) // 3.1.0.0
			{
				for (byte _i = 0; _i < 3; ++_i)
				{
					if (!SkipBytes._SkipAheadUntilByte(_NifRawDataStream, 0x0A, ref _Error))
					{
						_Error = $"An error occured while attempting to skip the NIF copyright info for: {NifIdentifier}";
						_CompletedSuccessfully = false;
						return;
					}
				}
			}

			// NIFs from v3.1.0.1 will have a uint32 with the NifVersion in little-endian format.
			// The version was already extracted but this can be compared against what was extracted to see if they match.
			if (NifVersion >= 0x03010001) // 3.1.0.1
			{
				if (!CommonNifHeaderMethods._Read2ndNifVersion(_NifRawDataStream, in NifIdentifier, in NifVersion, ref _Error))
				{
					_CompletedSuccessfully = false;
					return;
				}
			}

			// NIFs from v20.0.0.3 will have a byte defining the endianness of the remaining data.
			if (NifVersion >= 0x14000003) // 20.0.0.3
			{
				if (!CommonNifHeaderMethods._ReadNifEndiannessBit(_NifRawDataStream, in NifIdentifier, ref IsLittleEndian, ref _Error));
				{
					_CompletedSuccessfully = false;
					return;
				}
			}

			// NIFs from v10.0.1.8 will have a little-endian uint32 with the User version.
			if (NifVersion >= 0x0A001008) // 10.0.1.8
			{
				UserVersion = _NifRawDataStream.ReadUInt32();
			}

			// NIFs from v3.1.0.1 will have a uint32 with the number of NIF Objects in the model.
			if (NifVersion >= 0x03010001) // 3.1.0.1
			{
				NumBlocks = _NifRawDataStream.ReadUInt32();
			}

			// NIFs that pass the BSStreamHeader check will contain a series of bytes representing the BSStreamHeader
			// In the Slim Header, only the BSVersion is required. The rest can be skipped over.
			if (ComplexVersionChecks._BSStreamHeader(NifVersion, UserVersion))
			{
				if (!BSStreamHeader._ReadOnlyVersionAndSkipEverythingElse(_NifRawDataStream, in NifIdentifier,
					ref _Error, out BSVersion))
				{
					_CompletedSuccessfully = false;
					return;
				}
			}

			// NIFs from v30.0.0.0 will have an array of bytes containing metadata. Don't need this so skip.
			if (NifVersion >= 0x1E000000) // 30.0.0.0
			{
				_NifRawDataStream.BaseStream.Position += _NifRawDataStream.ReadUInt32();
			}

			//







			_CompletedSuccessfully = true;
		}
	}
}
