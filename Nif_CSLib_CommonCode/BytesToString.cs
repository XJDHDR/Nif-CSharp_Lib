// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


using System.IO;
using System.Text;

namespace Nif_CSLib_CommonCode
{
	/// <summary>
	/// Struct holding methods used to convert sequences of bytes into strings.
	/// </summary>
	public struct BytesToString
	{
		/// <summary>
		/// Used to get a string from a sequence of bytes that doesn't specify the string's length but is terminated
		/// by a specific character. Can read a maximum of 1000 characters before it errors out.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_TerminatingByte_">Supply the terminating byte value that is supposed to terminate the string.</param>
		/// <param name="_ReadString_">Outputs either the string that was read or an error message if an error occurred.</param>
		/// <returns>True if the terminating byte was found within 1000 bytes of start. False otherwise.</returns>
		public static bool _UnprefixedByteTerminatedString(BinaryReader _NifRawDataStream_, byte _TerminatingByte_, out string _ReadString_)
		{
			// Read bytes until either the specified character is found or 1000 bytes are read;
			long _startPos_ = _NifRawDataStream_.BaseStream.Position;
			StringBuilder _stringBuilder_ = new StringBuilder(32, 1002);
			ushort _loopIterations_ = 0;
			byte[] _currentByte_ = new byte[1];

			while (true)
			{
				++_loopIterations_;

				_currentByte_[0] = _NifRawDataStream_.ReadByte();
				if (_currentByte_[0] == _TerminatingByte_)
				{
					break;
				}

				_stringBuilder_.Append(Encoding.UTF8.GetString(_currentByte_));

				if (_loopIterations_ > 1000)
				{
					_ReadString_ = $"Error: Did not find a byte with the value \"{_TerminatingByte_}\" after reading 1000 bytes " +
					               $"starting at {_startPos_}.";
					return false;
				}
			}

			_ReadString_ = _stringBuilder_.ToString();
			return true;
		}

		/// <summary>
		/// Used to read a sequences of bytes identified in NIF xml as an "ExportString".
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_ReadString_">Outputs either the string that was read or an error message if an error occurred.</param>
		/// <returns>True if the Export String was successfully read. False otherwise.</returns>
		public static bool _ReadExportString(BinaryReader _NifRawDataStream_, out string _ReadString_)
		{
			return _ReadByteLengthPrefixedStringWithTerminatingByte(_NifRawDataStream_, 0x00, out _ReadString_);
		}

		/// <summary>
		/// A generic method used to read a string that is both prefixed with it's length (in UInt8 format) and
		/// has it's last character be a specified terminating character (which is included in the length value).
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_TerminatingByte_">Supply the terminating byte value that is supposed to terminate the string.</param>
		/// <param name="_ReadString_">Outputs either the string that was read or an error message if an error occurred.</param>
		/// <returns>True if the last byte in the string was the terminating byte. False otherwise.</returns>
		public static bool _ReadByteLengthPrefixedStringWithTerminatingByte(BinaryReader _NifRawDataStream_,
			byte _TerminatingByte_, out string _ReadString_)
		{
			byte _dataUnitLength_ = (byte)(_NifRawDataStream_.ReadByte() - 1);

			byte[] _stringBytes_ = _NifRawDataStream_.ReadBytes(_dataUnitLength_);

			byte _lastByteInDataUnit_ = _NifRawDataStream_.ReadByte();
			if (_lastByteInDataUnit_ != _TerminatingByte_)
			{
				_ReadString_ = $"Error: Did not find a byte with the value \"{_TerminatingByte_}\" at position " +
				          $"{_NifRawDataStream_.BaseStream.Position}. {_lastByteInDataUnit_} was read instead.";
				return false;
			}

			_ReadString_ = Encoding.UTF8.GetString(_stringBytes_);
			return true;
		}

		/// <summary>
		/// Used to read a sequences of bytes identified in NIF xml as an "SizedString". Limited to reading a maximum
		/// string length of 2147483647, as an array can only use an Int32 to define it's indexes whereas these strings
		/// use a UInt32 to designate length.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_IsDataLittleEndian_">Set to false if the data is big-endian. Stays True if little-endian.</param>
		/// <param name="_ReadString_">Outputs either the string that was read or an error message if an error occurred.</param>
		/// <returns>True if the string's indicated length is less than 2147483647. False otherwise.</returns>
		public static bool _ReadSizedString(BinaryReader _NifRawDataStream_, in bool _IsDataLittleEndian_, out string _ReadString_)
		{
			uint _dataUnitLength_ = ValueReaders._UInt(_NifRawDataStream_, in _IsDataLittleEndian_);
			if (_dataUnitLength_ > int.MaxValue) // TODO: Replace this with an "Array.MaxLength" if .NET 6 support is added.
			{
				_ReadString_ = $"Error while reading a SizedString at byte {_NifRawDataStream_.BaseStream.Position}: " +
				               $"String length is more than {int.MaxValue}, which is not supported.";
				return false;
			}
			byte[] _stringBytes_ = _NifRawDataStream_.ReadBytes((int)_dataUnitLength_);
			_ReadString_ = Encoding.UTF8.GetString(_stringBytes_);
			return true;
		}

		/// <summary>
		/// Used to read a sequences of bytes identified in NIF xml as an "SizedString16".
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_IsDataLittleEndian_">Set to false if the data is big-endian. Stays True if little-endian.</param>
		/// <returns>The string that was read from the data.</returns>
		public static string _ReadSizedString16(BinaryReader _NifRawDataStream_, in bool _IsDataLittleEndian_)
		{
			ushort _dataUnitLength_ = ValueReaders._UShort(_NifRawDataStream_, in _IsDataLittleEndian_);
			byte[] _stringBytes_ = _NifRawDataStream_.ReadBytes(_dataUnitLength_);
			return Encoding.UTF8.GetString(_stringBytes_);
		}
	}
}
