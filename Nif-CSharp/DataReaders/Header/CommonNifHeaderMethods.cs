// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


using CommonCode;
using System.Buffers.Binary;

namespace Nif_CSharp.DataReaders.Header
{
	internal struct CommonNifHeaderMethods
	{
		internal static bool _ReadNifHeader(BinaryReader _NifRawDataStream, in string NifIdentifier, ref string _ErrorText,
			out string _NifHeaderString, out uint _NifVersionCombined)
		{
			if (BytesToString.UnprefixedByteTerminatedString(_NifRawDataStream, 0x0A, out _NifHeaderString))
			{
				int _lastSpacePos = _NifHeaderString.LastIndexOf(" ", StringComparison.Ordinal);
				string _headerTextSubString = _NifHeaderString.Substring(0, _lastSpacePos);
				string _versionSubString = _NifHeaderString.Substring(_lastSpacePos + 1);

				// Extract the NIF's version from the HeaderString
				string[] _versionStringParts = _versionSubString.Split('.');
				byte _nifVersionPart1 = Convert.ToByte(_versionStringParts[0]);
				byte _nifVersionPart2 = 0;
				byte _nifVersionPart3 = 0;
				byte _nifVersionPart4 = 0;
				if (_versionStringParts.Length >= 2)
					_nifVersionPart2 = Convert.ToByte(_versionStringParts[1]);
				if (_versionStringParts.Length >= 3)
					_nifVersionPart3 = Convert.ToByte(_versionStringParts[2]);
				if (_versionStringParts.Length >= 4)
					_nifVersionPart4 = Convert.ToByte(_versionStringParts[3]);
				_NifVersionCombined = (uint)((_nifVersionPart1 << 24) | (_nifVersionPart2 << 16) | (_nifVersionPart3 << 8) | (_nifVersionPart4 << 0));

				// Check if the start of the HeaderString matches what we expect it to say.
				// For versions less than or equal to 10.0.1.2, the text must say "NetImmerse File Format, Version"
				// For versions greater than or equal to 10.1.0.0, the text must say "Gamebryo File Format, Version"
				if (_NifVersionCombined >= 0x0A010000)		// 10.1.0.0
				{
					if (_headerTextSubString != "Gamebryo File Format, Version")
					{
						_ErrorText = $"An error occured while attempting to read the NIF data for: {NifIdentifier}\n" +
						             "The HeaderString was supposed to say \"Gamebryo File Format, Version <number>\"" +
						             $"but it said \"{_NifHeaderString}\" instead.";
						return false;
					}
				}
				else
				{
					if (_headerTextSubString != "NetImmerse File Format, Version")
					{
						_ErrorText = $"An error occured while attempting to read the NIF data for: {NifIdentifier}\n" +
						             "The HeaderString was supposed to say \"NetImmerse File Format, Version <number>\"" +
						             $"but it said \"{_NifHeaderString}\" instead.";
						return false;
					}
				}
			}
			else
			{
				_ErrorText = $"{_NifHeaderString}/nAn error occured while attempting to read the NIF data for: {NifIdentifier}";
				_NifVersionCombined = 0;
				return false;
			}

			return true;
		}

		internal static bool _Read2ndNifVersion(BinaryReader _NifRawDataStream, in string NifIdentifier, in uint _NifVersion,
			ref string _ErrorText)
		{
			// NIFs from v3.1.0.1 will have a uint32 with the NifVersion in little-endian format.
			// _nifVersion2nd = 0x04000002;		// Default value for this field
			// BinaryReader can only read UInts in little-endian format. Need to read the raw bytes instead.

			uint _nifVersion2nd = _NifRawDataStream.ReadUInt32();
			if (_NifVersion != _nifVersion2nd)
			{
				_ErrorText += $"Error while reading Nif: {NifIdentifier}\n" + "The 2nd version number read " +
				              $"from the header was supposed to be {_NifVersion} but {_nifVersion2nd} was read instead";
				return false;
			}

			return true;
		}

		internal static bool _ReadNifEndiannessBit(BinaryReader _NifRawDataStream, in string _NifIdentifier,
			ref bool _IsLittleEndian, ref string _ErrorText)
		{
			byte _endianByte = _NifRawDataStream.ReadByte();
			switch (_endianByte)
			{
				case 0:
					_IsLittleEndian = false;
					break;

				case 1:
					// Already set to little-endian by default so just skip
					break;

				default:
					_ErrorText += $"An error occured while attempting to read the NIF data for: {_NifIdentifier}\n" +
					              "The endianness byte is supposed to be equal to either 0 or 1" +
					              $"but \"{_endianByte}\" was read instead.";
					return false;
			}

			return true;
		}
	}
}
