// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


using CommonCode;

namespace Nif_CSharp.DataReaders.Header
{
	public struct BSStreamHeader
	{
		public readonly uint BSVersion;
		public readonly string Author;
		public readonly int UnknownInt;
		public readonly string ProcessScript;
		public readonly string ExportScript;
		public readonly string MaxFilepath;

		internal BSStreamHeader(BinaryReader _NifRawDataStream, in string NifIdentifier, ref string _Error, out bool _CompletedSuccessfully)
		{
			// BS Version is a little-endian uint32.
			BSVersion = _NifRawDataStream.ReadUInt32();
			Author = "";
			UnknownInt = 0;
			ProcessScript = "";
			ExportScript = "";
			MaxFilepath = "";

			// Next is the NIF's author encoded as an "ExportString" (null-terminated string
			// prefixed with it's length, including the null-terminator)
			if (BytesToString._ReadExportString(_NifRawDataStream, out string _readText))
			{
				_Error = $"An error occured while attempting to read the BSStream Header author for: {NifIdentifier}\n" +
				         $"{_readText}";
				_CompletedSuccessfully = false;
				return;
			}
			Author = _readText;

			// Next is an unknown int32 if BS Version is more than 130
			if (BSVersion > 130)
			{
				UnknownInt = _NifRawDataStream.ReadInt32();
			}

			// Next is the NIF's processing script encoded as an "ExportString".
			if (BytesToString._ReadExportString(_NifRawDataStream, out _readText))
			{
				_Error = $"An error occured while attempting to read the BSStream Header process script for: {NifIdentifier}\n" +
				         $"{_readText}";
				_CompletedSuccessfully = false;
				return;
			}
			ProcessScript = _readText;

			// Next is the NIF's export script encoded as an "ExportString".
			if (BytesToString._ReadExportString(_NifRawDataStream, out _readText))
			{
				_Error = $"An error occured while attempting to read the BSStream Header export script for: {NifIdentifier}\n" +
				         $"{_readText}";
				_CompletedSuccessfully = false;
				return;
			}
			ExportScript = _readText;

			// Next is the NIF's "max filepath" encoded as an "ExportString" if BS Version is equal to 130
			if (BSVersion == 130)
			{
				if (BytesToString._ReadExportString(_NifRawDataStream, out _readText))
				{
					_Error =
						$"An error occured while attempting to read the BSStream Header max filepath for: {NifIdentifier}\n" +
						$"{_readText}";
					_CompletedSuccessfully = false;
					return;
				}
				MaxFilepath = _readText;
			}

			_CompletedSuccessfully = true;
		}

		internal static bool _ReadOnlyVersionAndSkipEverythingElse(BinaryReader _NifRawDataStream, in string NifIdentifier, ref string _Error, out uint _BSVersion)
		{
			// BS Version is a little-endian uint32.
			_BSVersion = _NifRawDataStream.ReadUInt32();

			// Next is the NIF's author encoded as an "ExportString" (null-terminated string
			// prefixed with it's length, including the null-terminator)
			if (SkipBytes._SkipExportString(_NifRawDataStream, ref _Error))
			{
				_Error = $"An error occured while attempting to skip the BSStream Header author for: {NifIdentifier}";
				return false;
			}

			// Next is an unknown int32 if BS Version is more than 130
			if (_BSVersion > 130)
			{
				_NifRawDataStream.BaseStream.Position += 4;
			}

			// Next is the NIF's processing script encoded as an "ExportString".
			if (SkipBytes._SkipExportString(_NifRawDataStream, ref _Error))
			{
				_Error = $"An error occured while attempting to skip the BSStream Header process script for: {NifIdentifier}";
				return false;
			}

			// Next is the NIF's export script encoded as an "ExportString".
			if (SkipBytes._SkipExportString(_NifRawDataStream, ref _Error))
			{
				_Error = $"An error occured while attempting to skip the BSStream Header export script for: {NifIdentifier}";
				return false;
			}

			// Next is the NIF's "max filepath" encoded as an "ExportString" if BS Version is equal to 130
			if (_BSVersion == 130)
			{
				if (SkipBytes._SkipExportString(_NifRawDataStream, ref _Error))
				{
					_Error = $"An error occured while attempting to skip the BSStream Header max filepath for: {NifIdentifier}";
					return false;
				}
			}
			return true;
		}
	}
}
