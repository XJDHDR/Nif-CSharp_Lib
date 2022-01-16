// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


using CommonCode;

namespace Nif_CSharp.DataReaders.Header
{
	/// <summary>
	/// Struct containing all of the data present in an NIF's header. This data isn't used to read data from an NIF's
	/// blocks (the Slim Header struct is used for that). It's main purpose is for any applications that need to display
	/// all of this data in a human readable format.
	/// </summary>
	public readonly struct NifHeaderData
	{
		// ReSharper disable MemberCanBePrivate.Global
		// ReSharper disable InconsistentNaming
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
		public readonly ushort[] BlockTypeMappings;
		public readonly uint[] BlockSizes;
		public readonly string[] StringsDatabase;
		public readonly uint[] Groups;
		// ReSharper restore InconsistentNaming
		// ReSharper restore MemberCanBePrivate.Global

		/// <summary>
		/// Constructor used to create a Full NIF Header struct by reading the required data from a BinaryReader pointing
		/// to the NIF data.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <param name="_CompletedSuccessfully_">True if the constructor completed without encountering an error. False otherwise.</param>
		internal NifHeaderData(BinaryReader _NifRawDataStream_, in string _NifIdentifier_, ref string _Error_, out bool _CompletedSuccessfully_)
		{
			// Set an initial state of these variables, to prevent "must be assigned upon exit" errors.
			NifVersion = 0;
			CopyrightInfo = new string[3];
			IsLittleEndian = true;	// default value if Endianness field not present.
			UserVersion = 0;
			NumBlocks = 0;
			BSStreamHeader = new BSStreamHeader();
			Metadata = Array.Empty<byte>();
			BlockTypes = Array.Empty<string>();
			BlockTypeHashes = Array.Empty<uint>();
			BlockTypeMappings = Array.Empty<ushort>();
			BlockSizes = Array.Empty<uint>();
			StringsDatabase = Array.Empty<string>();
			Groups = Array.Empty<uint>();

			// First dozen or so bytes are titled the "HeaderString". It is an unprefixed & newline-terminated sequence of bytes
			// that is supposed to consist of the string: "NetImmerse/Gamebryo File Format" and then the file's version number.
			if (!CommonNifHeaderMethods._ReadNifHeaderString(_NifRawDataStream_, _NifIdentifier_, ref _Error_, out NifHeaderString, out NifVersion))
			{
				_CompletedSuccessfully_ = false;
				return;
			}

			// NIFs up to v3.1.0.0 will have three unprefixed & newline-terminated sequences of bytes
			// which makes up 3 strings designating the model's copyright info.
			if (NifVersion <= 0x03010000)		// 3.1.0.0
			{
				for (byte _i_ = 0; _i_ < 3; ++_i_)
				{
					if (!BytesToString._UnprefixedByteTerminatedString(_NifRawDataStream_, 0x0A, out string _copyrightString_))
					{
						_Error_ += $"{_copyrightString_}\nAn error occured while attempting to read byte " +
						           $"{_NifRawDataStream_.BaseStream.Position} in the NIF data for: {_NifIdentifier_}";
						_CompletedSuccessfully_ = false;
						return;
					}
					CopyrightInfo[_i_] = _copyrightString_;
				}
			}

			// NIFs from v3.1.0.1 will have a uint32 with the NifVersion in little-endian format.
			// The version was already extracted but this can be compared against what was extracted to see if they match.
			if (NifVersion >= 0x03010001) // 3.1.0.1
			{
				if (!CommonNifHeaderMethods._Read2ndNifVersion(_NifRawDataStream_, in _NifIdentifier_, in NifVersion, ref _Error_))
				{
					_CompletedSuccessfully_ = false;
					return;
				}
			}

			// NIFs from v20.0.0.3 will have a byte defining the endianness of the remaining data.
			// NIFs from v20.0.0.3 will have a byte defining the endianness of the remaining data.
			if (NifVersion >= 0x14000003) // 20.0.0.3
			{
				if (!CommonNifHeaderMethods._ReadNifEndiannessBit(_NifRawDataStream_, in _NifIdentifier_, ref IsLittleEndian, ref _Error_))
				{
					_CompletedSuccessfully_ = false;
					return;
				}
			}

			// NIFs from v10.0.1.8 will have a uint32 with the User version in little-endian format.
			if (NifVersion >= 0x0A001008) // 10.0.1.8
			{
				UserVersion = _NifRawDataStream_.ReadUInt32();
			}

			// NIFs from v3.1.0.1 will have a uint32 with the number of NIF Objects in the model.
			if (NifVersion >= 0x03010001) // 3.1.0.1
			{
				NumBlocks = _NifRawDataStream_.ReadUInt32();
			}

			// NIFs that pass the BSStreamHeader check will contain a series of bytes representing the BSStreamHeader
			if (ComplexVersionChecks._BSStreamHeader(NifVersion, UserVersion))
			{
				BSStreamHeader = new BSStreamHeader(_NifRawDataStream_, in _NifIdentifier_, ref _Error_, out _CompletedSuccessfully_);
				if (!_CompletedSuccessfully_)
				{
					_CompletedSuccessfully_ = false;
					return;
				}
			}

			// NIFs from v30.0.0.0 will have an array of bytes containing metadata
			if (NifVersion >= 0x1E000000) // 30.0.0.0
			{
				uint _arrayLength_ = _NifRawDataStream_.ReadUInt32();
				Metadata = new byte[_arrayLength_];
				for (uint _i_ = 0; _i_ < _arrayLength_; ++_i_)
				{
					Metadata[_i_] = _NifRawDataStream_.ReadByte();
				}
			}

			// NIFs from v5.0.0.1 onwards will have some data listing the block types used in the model and mapping each
			// block to one of these types.
			if (NifVersion >= 0x05000001) // 5.0.0.1
			{
				if (!CommonNifHeaderMethods._ReadBlockTypesList(_NifRawDataStream_, in _NifIdentifier_, in NifVersion,
					    in NumBlocks, ref BlockTypes, ref BlockTypeHashes, ref BlockTypeMappings, ref _Error_))
				{
					_CompletedSuccessfully_ = false;
					return;
				}
			}

			// NIFs from v20.2.0.5 onwards will have an array of UInt32s designating the size in bytes of each block in the model.
			if (NifVersion >= 0x14020005) // 20.2.0.5
			{
				BlockSizes = new uint[NumBlocks];
				for (int _i_ = 0; _i_ < NumBlocks; _i_++)
				{
					BlockSizes[_i_] = _NifRawDataStream_.ReadUInt32();
				}
			}

			// NIFs from v20.1.0.1 onwards will have an array of strings used in the model.
			if (NifVersion >= 0x14010001) // 20.1.0.1
			{
				if (!CommonNifHeaderMethods._ReadStringsDatabase(_NifRawDataStream_, in _NifIdentifier_, ref _Error_,
					    out StringsDatabase))
				{
					_CompletedSuccessfully_ = false;
					return;
				}
			}

			// NIFs from v5.0.0.6 onwards will have an array of UInt32s designating groups.
			if (NifVersion >= 0x05000006) // 5.0.0.6
			{
				uint _numGroups_ = _NifRawDataStream_.ReadUInt32();
				Groups = new uint[_numGroups_];
				for (int _i_ = 0; _i_ < _numGroups_; _i_++)
				{
					Groups[_i_] = _NifRawDataStream_.ReadUInt32();
				}
			}

			// That's all the data an NIF's header can contain.
			_CompletedSuccessfully_ = true;
		}
	}
}
