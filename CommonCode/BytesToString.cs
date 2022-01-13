// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


using System.Text;

namespace CommonCode
{
	internal struct BytesToString
	{
		internal static bool UnprefixedByteTerminatedString(BinaryReader _NifRawDataStream, byte _TerminatingByte, out string _ReadString)
		{
			// Read bytes until either the specified character is found or 1000 bytes are read;
			StringBuilder _stringBuilder = new StringBuilder(32, 1002);
			ushort _loopIterations = 0;
			byte[] _currentByte = new byte[1];

			while (true)
			{
				++_loopIterations;

				_currentByte[0] = _NifRawDataStream.ReadByte();
				if (_currentByte[0] == _TerminatingByte)
				{
					break;
				}

				_stringBuilder.Append(Encoding.UTF8.GetString(_currentByte));

				if (_loopIterations > 1000)
				{
					_ReadString = $"Error: Did not find a byte with the value \"{_TerminatingByte}\" after reading 1000 bytes.";
					return false;
				}
			}

			_ReadString = _stringBuilder.ToString();
			return true;
		}

		internal static bool _ReadExportString(BinaryReader _NifRawDataStream, out string _ReadString)
		{
			return _ReadLengthPrefixedStringWithTerminatingByte(_NifRawDataStream, 0x00, out _ReadString);
		}

		internal static bool _ReadLengthPrefixedStringWithTerminatingByte(BinaryReader _NifRawDataStream,
			byte _TerminatingByte, out string _ReadString)
		{
			byte _DataUnitLength = (byte)(_NifRawDataStream.ReadByte() - 1);

			byte[] _stringBytes = _NifRawDataStream.ReadBytes(_DataUnitLength);

			byte _LastByteInDataUnit = _NifRawDataStream.ReadByte();
			if (_LastByteInDataUnit != _TerminatingByte)
			{
				_ReadString = $"Error: Did not find a byte with the value \"{_TerminatingByte}\" at position " +
				          $"{_NifRawDataStream.BaseStream.Position}. {_LastByteInDataUnit} was read instead.";
				return false;
			}

			_ReadString = Encoding.UTF8.GetString(_stringBytes);
			return true;
		}

		internal static bool _ReadSizedString(BinaryReader _NifRawDataStream, out string _ReadString)
		{
			int _DataUnitLength = _NifRawDataStream.ReadInt32();
			if (_DataUnitLength < 0)
			{
				_ReadString = $"Error while reading a SizedString: String length is more than {int.MaxValue}, which is not supported.";
				return false;
			}
			byte[] _stringBytes = _NifRawDataStream.ReadBytes(_DataUnitLength);
			_ReadString = Encoding.UTF8.GetString(_stringBytes);
			return true;
		}

		internal static string _ReadSizedString16(BinaryReader _NifRawDataStream)
		{
			byte _DataUnitLength = _NifRawDataStream.ReadByte();
			byte[] _stringBytes = _NifRawDataStream.ReadBytes(_DataUnitLength);
			return Encoding.UTF8.GetString(_stringBytes);
		}
	}
}
