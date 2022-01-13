// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


namespace CommonCode
{
	internal struct SkipBytes
	{
		internal static bool _SkipAheadUntilByte(BinaryReader _NifRawDataStream, byte _TerminatingByte, ref string _Error)
		{
			// Read bytes until either the specified character is found or 1000 bytes are read;
			ushort _loopIterations = 0;

			while (true)
			{
				++_loopIterations;

				if (_NifRawDataStream.ReadByte() == _TerminatingByte)
				{
					break;
				}

				if (_loopIterations > 1000)
				{
					_Error += $"Error: Did not find a byte with the value \"{_TerminatingByte}\" after reading 1000 bytes.";
					return false;
				}
			}

			return true;
		}

		internal static bool _SkipExportString(BinaryReader _NifRawDataStream, ref string _Error)
		{
			return _SkipLengthPrefixedDataUnitWithTerminatingByte(_NifRawDataStream, 0x00, ref _Error);
		}

		internal static bool _SkipLengthPrefixedDataUnitWithTerminatingByte(BinaryReader _NifRawDataStream,
			byte _TerminatingByte, ref string _Error)
		{
			byte DataUnitLength = _NifRawDataStream.ReadByte();
			_NifRawDataStream.BaseStream.Position += DataUnitLength - 1;
			byte _LastByteInDataUnit = _NifRawDataStream.ReadByte();
			if (_LastByteInDataUnit != _TerminatingByte)
			{
				_Error += $"Error: Did not find a byte with the value \"{_TerminatingByte}\" at position " +
				          $"{_NifRawDataStream.BaseStream.Position}. {_LastByteInDataUnit} was read instead.";
				return false;
			}
			return true;
		}
	}
}
