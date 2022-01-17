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
	/// Struct holding common methods for reading data from an NIF's header.
	/// </summary>
	internal struct CommonNifHeaderMethods
	{
		/// <summary>
		/// Reads the NIF's Header String from the data, extracts the Version number from the string and tests if the
		/// portion before the version number matches what it should be for that version.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <param name="_NifHeaderString_">The entire Header String (including version) that was read.</param>
		/// <param name="_NifVersionCombined_">The Version portion that was read.</param>
		/// <returns>True if the Header String was successfully read and matches what an NIF of it's version should say.
		/// False if an error occurred.</returns>
		internal static bool _ReadNifHeaderString(BinaryReader _NifRawDataStream_, in string _NifIdentifier_, ref string _Error_,
			out string _NifHeaderString_, out uint _NifVersionCombined_)
		{
			if (BytesToString._UnprefixedByteTerminatedString(_NifRawDataStream_, 0x0A, out _NifHeaderString_))
			{
				int _lastSpacePos_ = _NifHeaderString_.LastIndexOf(" ", StringComparison.Ordinal);
				string _headerTextSubString_ = _NifHeaderString_.Substring(0, _lastSpacePos_);
				string _versionSubString_ = _NifHeaderString_.Substring(_lastSpacePos_ + 1);

				// Extract the NIF's version from the HeaderString
				string[] _versionStringParts_ = _versionSubString_.Split('.');
				byte _nifVersionPart1_ = Convert.ToByte(_versionStringParts_[0]);
				byte _nifVersionPart2_ = 0;
				byte _nifVersionPart3_ = 0;
				byte _nifVersionPart4_ = 0;
				if (_versionStringParts_.Length >= 2)
				{
					_nifVersionPart2_ = Convert.ToByte(_versionStringParts_[1]);
				}
				if (_versionStringParts_.Length >= 3)
				{
					_nifVersionPart3_ = Convert.ToByte(_versionStringParts_[2]);
				}
				if (_versionStringParts_.Length >= 4)
				{
					_nifVersionPart4_ = Convert.ToByte(_versionStringParts_[3]);
				}
				_NifVersionCombined_ = (uint)((_nifVersionPart1_ << 24) | (_nifVersionPart2_ << 16) | (_nifVersionPart3_ << 8) | (_nifVersionPart4_ << 0));

				// Check if the start of the HeaderString matches what it's supposed to say.
				// For versions less than or equal to 10.0.1.2, the text must say "NetImmerse File Format, Version"
				// For versions greater than or equal to 10.1.0.0, the text must say "Gamebryo File Format, Version"
				if (_NifVersionCombined_ >= 0x0A010000)		// 10.1.0.0
				{
					if (_headerTextSubString_ != "Gamebryo File Format, Version")
					{
						_Error_ = $"An error occured while attempting to read byte " +
						              $"{_NifRawDataStream_.BaseStream.Position} in the NIF data for: {_NifIdentifier_}\n" +
						             "The HeaderString was supposed to say \"Gamebryo File Format, Version <number>\"" +
						             $"but it said \"{_NifHeaderString_}\" instead.";
						return false;
					}
				}
				else
				{
					if (_headerTextSubString_ != "NetImmerse File Format, Version")
					{
						_Error_ = $"An error occured while attempting to read byte " +
						              $"{_NifRawDataStream_.BaseStream.Position} in the NIF data for: {_NifIdentifier_}\n" +
						             "The HeaderString was supposed to say \"NetImmerse File Format, Version <number>\"" +
						             $"but it said \"{_NifHeaderString_}\" instead.";
						return false;
					}
				}
			}
			else
			{
				_Error_ = $"{_NifHeaderString_}/nAn error occured while attempting to read byte " +
				              $"{_NifRawDataStream_.BaseStream.Position} in the NIF data for: {_NifIdentifier_}";
				_NifVersionCombined_ = 0;
				return false;
			}

			return true;
		}

		/// <summary>
		/// Reads the second instance of the NIF's Version stored in UInt32 format and checks if it matches what was read
		/// from the Header String.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_NifVersion_">The NIF's version that was read from the Header String.</param>
		/// <param name="_IsDataLittleEndian_">Set to True if the data being read is in little-endian format.
		/// Set to false if it's big-endian.</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <returns>True if the 2nd version read here matches the number read from the Header String. False otherwise.</returns>
		internal static bool _Read2ndNifVersion(BinaryReader _NifRawDataStream_, in string _NifIdentifier_,
			in uint _NifVersion_, in bool _IsDataLittleEndian_, ref string _Error_)
		{
			// NIFs from v3.1.0.1 will have a uint32 with the NifVersion in little-endian format.
			// _nifVersion2nd = 0x04000002;		// Default value for this field
			ValueReaders._ULittle32(_NifRawDataStream_, in _IsDataLittleEndian_);
			uint _nifVersionSecond_ = _NifRawDataStream_.ReadUInt32();
			if (_NifVersion_ != _nifVersionSecond_)
			{
				_Error_ += $"Error while reading byte {_NifRawDataStream_.BaseStream.Position} in " +
				           $"Nif: {_NifIdentifier_}\n" + "The 2nd version number read " +
				           $"from the header was supposed to be {_NifVersion_} but {_nifVersionSecond_} was read instead";
				return false;
			}

			return true;
		}

		/// <summary>
		/// Used to read the byte in the NIF indicating the data's endianness.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_IsDataLittleEndian_">Set to false if the data is big-endian. Stays True if little-endian.</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <returns>True if the endianness value was successfully read. False if an error occurred.</returns>
		internal static bool _ReadNifEndiannessBit(BinaryReader _NifRawDataStream_, in string _NifIdentifier_,
			ref bool _IsDataLittleEndian_, ref string _Error_)
		{
			byte _endianByte_ = _NifRawDataStream_.ReadByte();
			switch (_endianByte_)
			{
				case 0:
					_IsDataLittleEndian_ = false;
					break;

				case 1:
					// Already set to little-endian by default so just skip
					break;

				default:
					_Error_ += $"An error occured while attempting to read byte " +
					           $"{_NifRawDataStream_.BaseStream.Position} in the NIF data for: {_NifIdentifier_}\n" +
					           "The endianness byte is supposed to be equal to either 0 or 1" +
					           $"but \"{_endianByte_}\" was read instead.";
					return false;
			}

			return true;
		}

		/// <summary>
		/// Used to read the list of block types used in the NIF and the mappings between these types and the present blocks.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_NifVersion_">The NIF's version.</param>
		/// <param name="_NumBlocks_">The number of blocks present in the NIF.</param>
		/// <param name="_IsDataLittleEndian_">Set to false if the data is big-endian. Stays True if little-endian.</param>
		/// <param name="_BlockTypes_">The list of block types used in the NIF.</param>
		/// <param name="_BlockTypeHashes_">The list of block type hashes used in the NIF.</param>
		/// <param name="_BlockTypeMapping_">A mapping between the block types list and the blocks in the NIF.</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <returns>True if the data regarding block types was successfully read. False otherwise.</returns>
		internal static bool _ReadBlockTypesList(BinaryReader _NifRawDataStream_, in string _NifIdentifier_, in uint _NifVersion_,
			in uint _NumBlocks_, in bool _IsDataLittleEndian_, ref string[] _BlockTypes_, ref uint[] _BlockTypeHashes_,
			ref ushort[] _BlockTypeMapping_, ref string _Error_)
		{
			ushort _numBlockTypes_ = ValueReaders._UShort(_NifRawDataStream_, in _IsDataLittleEndian_);

			// NIFs with version 20.3.1.2 will use an array of block type hashes. Other qualifying versions have an array of strings.
			if (_NifVersion_ != 0x14030102) // 20.3.1.2
			{
				_BlockTypes_ = new string[_numBlockTypes_];
				for (ushort _i_ = 0; _i_ < _numBlockTypes_; _i_++)
				{
					if (!BytesToString._ReadSizedString(_NifRawDataStream_, out string _blockTypeRead_))
					{
						_Error_ += $"{_blockTypeRead_}\nAn error occured while attempting to read byte " +
						           $"{_NifRawDataStream_.BaseStream.Position} in the NIF data for: {_NifIdentifier_}";
						return false;
					}
					_BlockTypes_[_i_] = _blockTypeRead_;
				}
			}
			else
			{
				_BlockTypeHashes_ = new uint[_numBlockTypes_];
				for (ushort _i_ = 0; _i_ < _numBlockTypes_; _i_++)
				{
					_BlockTypeHashes_[_i_] = _NifRawDataStream_.ReadUInt32();
				}
			}

			// Finally, there is an array of Int16s mapping one of the block types above to the blocks used in the model.
			_BlockTypeMapping_ = new ushort[_NumBlocks_];
			for (int _i_ = 0; _i_ < _NumBlocks_; _i_++)
			{
				_BlockTypeMapping_[_i_] = _NifRawDataStream_.ReadUInt16();
				// The last bit appears to be a PhysX flag that is not needed. Remove if present.
				if ((_BlockTypeMapping_[_i_] & (1 << 15)) != 0)
				{
					_BlockTypeMapping_[_i_] -= 0x8000;
				}
			}

			return true;
		}

		/// <summary>
		/// Reads the strings database from the NIF's header.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <param name="_StringsDatabase_">List of all the strings used in the NIF.</param>
		/// <returns>True if the strings database was successfully created. False if an error occurred.</returns>
		internal static bool _ReadStringsDatabase(BinaryReader _NifRawDataStream_, in string _NifIdentifier_,
			ref string _Error_, out string[] _StringsDatabase_)
		{
			uint _numStrings_ = _NifRawDataStream_.ReadUInt32();
			uint _maxStringLength_ = _NifRawDataStream_.ReadUInt32();
			_StringsDatabase_ = new string[_numStrings_];
			for (int _i_ = 0; _i_ < _numStrings_; _i_++)
			{
				long _startPos_ = _NifRawDataStream_.BaseStream.Position;
				if (!BytesToString._ReadSizedString(_NifRawDataStream_, out _StringsDatabase_[_i_]))
				{
					_Error_ += $"{_StringsDatabase_[_i_]}\nAn error occured while attempting to read byte " +
					           $"{_NifRawDataStream_.BaseStream.Position} in the NIF data for: {_NifIdentifier_}";
					_StringsDatabase_[_i_] = "";
					return false;
				}

				if (_StringsDatabase_[_i_].Length > _maxStringLength_)
				{
					_Error_ += $"An error occured while attempting to read byte {_startPos_} in the NIF data for: {_NifIdentifier_}\n" +
					           $"String #{_i_} read for the string database has a length of {_StringsDatabase_[_i_].Length}, " +
					           $"which exceeds the NIF's specified max length of {_maxStringLength_}.";
					return false;
				}
			}

			return true;
		}
	}
}
