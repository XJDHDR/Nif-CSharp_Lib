// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


using CommonCode;

namespace Nif_CSharp.DataReaders.Header
{
	public readonly struct NifHeaderData
	{
		public readonly string NifHeaderString;
		public readonly uint NifVersion;
		public readonly string[] CopyrightInfo;
		public readonly bool IsLittleEndian;
		public readonly uint UserVersion;
		public readonly uint NumBlocks;
		public readonly BSStreamHeader BSStreamHeader;
		public readonly byte[] Metadata;
		public readonly string[] BlockTypes;
		public readonly uint[] BlockTypeHashes;

		internal NifHeaderData(BinaryReader _NifRawDataStream, in string NifIdentifier, ref string _Error, out bool _CompletedSuccessfully)
		{
			// Set the initial state of these variables, to prevent "must be assigned upon exit" errors.
			NifVersion = 0;
			CopyrightInfo = new string[3];
			IsLittleEndian = true;	// default value if Endianness field not present.
			UserVersion = 0;
			NumBlocks = 0;
			BSStreamHeader = new BSStreamHeader();
			Metadata = Array.Empty<byte>();
			BlockTypes = Array.Empty<string>();
			BlockTypeHashes = Array.Empty<uint>();

			// First dozen or so bytes are titled the "HeaderString". It is an unprefixed & newline-terminated sequence of bytes
			// that is supposed to consist of the string: "NetImmerse/Gamebryo File Format" and then the file's version number.
			if (!CommonNifHeaderMethods._ReadNifHeader(_NifRawDataStream, NifIdentifier, ref _Error, out NifHeaderString, out NifVersion))
			{
				_CompletedSuccessfully = false;
				return;
			}

			// NIFs up to v3.1.0.0 will have three unprefixed & newline-terminated sequences of bytes
			// which makes up 3 strings designating the model's copyright info.
			if (NifVersion <= 0x03010000)		// 3.1.0.0
			{
				for (byte _i = 0; _i < 3; ++_i)
				{
					if (!BytesToString.UnprefixedByteTerminatedString(_NifRawDataStream, 0x0A, out string _copyrightString))
					{
						_Error += $"{_copyrightString}\nAn error occured while attempting to read the NIF data for: {NifIdentifier}";
						_CompletedSuccessfully = false;
						return;
					}
					CopyrightInfo[_i] = _copyrightString;
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
			// NIFs from v20.0.0.3 will have a byte defining the endianness of the remaining data.
			if (NifVersion >= 0x14000003) // 20.0.0.3
			{
				if (!CommonNifHeaderMethods._ReadNifEndiannessBit(_NifRawDataStream, in NifIdentifier, ref IsLittleEndian, ref _Error));
				{
					_CompletedSuccessfully = false;
					return;
				}
			}

			// NIFs from v10.0.1.8 will have a uint32 with the User version in little-endian format.
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
			if (ComplexVersionChecks._BSStreamHeader(NifVersion, UserVersion))
			{
				BSStreamHeader = new BSStreamHeader(_NifRawDataStream, in NifIdentifier, ref _Error, out _CompletedSuccessfully);
				if (!_CompletedSuccessfully)
				{
					_CompletedSuccessfully = false;
					return;
				}
			}

			// NIFs from v30.0.0.0 will have an array of bytes containing metadata
			if (NifVersion >= 0x1E000000) // 30.0.0.0
			{
				uint _arrayLength = _NifRawDataStream.ReadUInt32();
				Metadata = new byte[_arrayLength];
				for (uint _i = 0; _i < _arrayLength; ++_i)
				{
					Metadata[_i] = _NifRawDataStream.ReadByte();
				}
			}

			// NIFs from v5.0.0.1 onwards will have some data listing the block types used in the model and mapping each
			// block to one of these types.
			if (NifVersion >= 0x05000001) // 5.0.0.1
			{
				ushort _numBlockTypes = _NifRawDataStream.ReadUInt16();

				// NIFs with version 20.3.1.2 will use an array of block type hashes. Other qualifying versions have an array of strings.
				if (NifVersion != 0x14030102) // 20.3.1.2
				{
					BlockTypes = new string[_numBlockTypes];
					for (ushort _i = 0; _i < _numBlockTypes; _i++)
					{
						if (!BytesToString._ReadSizedString(_NifRawDataStream, out string _blockTypeRead))
						{
							_Error += $"{_blockTypeRead}\nAn error occured while attempting to read the NIF data for: {NifIdentifier}";
							_CompletedSuccessfully = false;
							return;
						}
						BlockTypes[_i] = _blockTypeRead;
					}
				}
				else
				{
					BlockTypeHashes = new uint[_numBlockTypes];
					for (ushort _i = 0; _i < _numBlockTypes; _i++)
					{
						BlockTypeHashes[_i] = _NifRawDataStream.ReadUInt32();
					}
				}

			}






			_CompletedSuccessfully = true;
		}
	}
}
