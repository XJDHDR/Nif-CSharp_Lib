// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


using System.IO;

namespace Nif_CSLib_CommonCode
{
	/// <summary>
	/// Struct which holds methods used to skip past bytes that don't need to be read.
	/// </summary>
	public struct SkipBytes
	{
		/// <summary>
		/// Skip past individual bytes until a byte matching the supplied value is found. Skips a maximum of 1000 bytes before failing.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_TerminatingByte_">Supply the terminating byte value that will be searched for to find the end of the byte sequence to skip.</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <returns>True if the terminating byte was found within 1000 bytes of start. False otherwise.</returns>
		public static bool _SkipAheadUntilByte(BinaryReader _NifRawDataStream_, byte _TerminatingByte_, ref string _Error_)
		{
			// Read bytes until either the specified character is found or 1000 bytes are read;
			ushort _loopIterations_ = 0;
			long _startPos_ = _NifRawDataStream_.BaseStream.Position;

			while (true)
			{
				++_loopIterations_;

				if (_NifRawDataStream_.ReadByte() == _TerminatingByte_)
				{
					break;
				}

				if (_loopIterations_ > 1000)
				{
					_Error_ += $"Error: Did not find a byte with the value \"{_TerminatingByte_}\" after reading 1000 bytes " +
					           $"starting at byte {_startPos_}.";
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Used to skip over sequences of bytes identified in NIF xml as an "ExportString".
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <returns>True if the Export String was successfully skipped over. False otherwise.</returns>
		public static bool _SkipExportString(BinaryReader _NifRawDataStream_, ref string _Error_)
		{
			return _SkipLengthPrefixedStringEndingWithTerminatingByte(_NifRawDataStream_, 0x00, ref _Error_);
		}

		/// <summary>
		/// A generic method used to skip over a string that is both prefixed with it's length (in UInt8 format) and
		/// has it's last character be a specified terminating character (which is included in the length value).
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_TerminatingByte_">Supply the terminating byte value that is supposed to terminate the string.</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <returns>True if the last byte in the string was the terminating byte. False otherwise.</returns>
		public static bool _SkipLengthPrefixedStringEndingWithTerminatingByte(BinaryReader _NifRawDataStream_,
			byte _TerminatingByte_, ref string _Error_)
		{
			byte _dataUnitLength_ = _NifRawDataStream_.ReadByte();
			_NifRawDataStream_.BaseStream.Position += _dataUnitLength_ - 1;
			byte _lastByteInDataUnit_ = _NifRawDataStream_.ReadByte();
			if (_lastByteInDataUnit_ != _TerminatingByte_)
			{
				_Error_ += $"Error: Did not find a byte with the value \"{_TerminatingByte_}\" at position " +
				          $"{_NifRawDataStream_.BaseStream.Position}. {_lastByteInDataUnit_} was read instead.";
				return false;
			}
			return true;
		}
	}
}
