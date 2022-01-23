// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


using System.IO;
using Nif_CSLib_CommonCode;

namespace Nif_CSharp.DataReaders.Header
{
	/// <summary>
	/// Holds data related to the BS Stream header portion of the NIF's header.
	/// </summary>
	// ReSharper disable InconsistentNaming
	public struct BSStreamHeader
	{
		// ReSharper disable MemberCanBePrivate.Global
		public readonly uint BSVersion;
		public readonly string Author;
		public readonly uint UnknownInt;
		public readonly string ProcessScript;
		public readonly string ExportScript;
		public readonly string MaxFilepath;
		// ReSharper restore MemberCanBePrivate.Global
		// ReSharper restore InconsistentNaming

		/// <summary>
		/// Constructor that automatically assigns the struct's fields by reading the required data from the NIF data stream.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_IsDataLittleEndian_">Set to false if the data is big-endian. Stays True if little-endian.</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <param name="_CompletedSuccessfully_">True if the constructor completed without encountering an error. False otherwise.</param>
		internal BSStreamHeader(BinaryReader _NifRawDataStream_, in string _NifIdentifier_, in bool _IsDataLittleEndian_,
			ref string _Error_, out bool _CompletedSuccessfully_)
		{
			// BS Version is a little-endian uint32.
			BSVersion = ValueReaders._ULittle32(_NifRawDataStream_, in _IsDataLittleEndian_);
			Author = "";
			UnknownInt = 0;
			ProcessScript = "";
			ExportScript = "";
			MaxFilepath = "";

			// Next is the NIF's author encoded as an "ExportString" (null-terminated string
			// prefixed with it's length, including the null-terminator)
			if (BytesToString._ReadExportString(_NifRawDataStream_, out string _readText_))
			{
				_Error_ = $"An error occured while attempting to read byte {_NifRawDataStream_.BaseStream.Position} " +
				          $"in the BSStream Header author for: {_NifIdentifier_}\n" +
				          $"{_readText_}";
				_CompletedSuccessfully_ = false;
				return;
			}
			Author = _readText_;

			// Next is an unknown int32 if BS Version is more than 130
			if (BSVersion > 130)
			{
				UnknownInt = ValueReaders._UInt(_NifRawDataStream_, _IsDataLittleEndian_);
			}

			// Next is the NIF's processing script encoded as an "ExportString".
			if (BytesToString._ReadExportString(_NifRawDataStream_, out _readText_))
			{
				_Error_ = $"An error occured while attempting to read byte {_NifRawDataStream_.BaseStream.Position} " +
				          $"in the BSStream Header process script for: {_NifIdentifier_}\n" +
				          $"{_readText_}";
				_CompletedSuccessfully_ = false;
				return;
			}
			ProcessScript = _readText_;

			// Next is the NIF's export script encoded as an "ExportString".
			if (BytesToString._ReadExportString(_NifRawDataStream_, out _readText_))
			{
				_Error_ = $"An error occured while attempting to read byte {_NifRawDataStream_.BaseStream.Position} " +
				          $"in the BSStream Header export script for: {_NifIdentifier_}\n" +
				          $"{_readText_}";
				_CompletedSuccessfully_ = false;
				return;
			}
			ExportScript = _readText_;

			// Next is the NIF's "max filepath" encoded as an "ExportString" if BS Version is equal to 130
			if (BSVersion == 130)
			{
				if (BytesToString._ReadExportString(_NifRawDataStream_, out _readText_))
				{
					_Error_ = $"An error occured while attempting to read byte {_NifRawDataStream_.BaseStream.Position} " +
					          $"in the BSStream Header max filepath for: {_NifIdentifier_}\n" +
						      $"{_readText_}";
					_CompletedSuccessfully_ = false;
					return;
				}
				MaxFilepath = _readText_;
			}

			_CompletedSuccessfully_ = true;
		}

		/// <summary>
		/// Method that can be used to read only the BS Version from the BS Stream Header and skip past all the other data in that header.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_IsDataLittleEndian_">Set to false if the data is big-endian. Stays True if little-endian.</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <param name="_BsVersion_">The value for BS Version read from the data.</param>
		/// <returns>True if the BS Version was read without any errors occurring. False otherwise.</returns>
		internal static bool _ReadOnlyVersionAndSkipEverythingElse(BinaryReader _NifRawDataStream_, in string _NifIdentifier_,
			in bool _IsDataLittleEndian_, ref string _Error_, out uint _BsVersion_)
		{
			// BS Version is a little-endian uint32.
			_BsVersion_ = ValueReaders._ULittle32(_NifRawDataStream_, in _IsDataLittleEndian_);

			// Next is the NIF's author encoded as an "ExportString" (null-terminated string
			// prefixed with it's length, including the null-terminator)
			if (SkipBytes._SkipExportString(_NifRawDataStream_, ref _Error_))
			{
				_Error_ = $"An error occured while attempting to skip byte {_NifRawDataStream_.BaseStream.Position} " +
				          $"in the BSStream Header author for: {_NifIdentifier_}";
				return false;
			}

			// Next is an unknown int32 if BS Version is more than 130
			if (_BsVersion_ > 130)
			{
				_NifRawDataStream_.BaseStream.Position += 4;
			}

			// Next is the NIF's processing script encoded as an "ExportString".
			if (SkipBytes._SkipExportString(_NifRawDataStream_, ref _Error_))
			{
				_Error_ = $"An error occured while attempting to skip byte {_NifRawDataStream_.BaseStream.Position} " +
				          $"in the BSStream Header process script for: {_NifIdentifier_}";
				return false;
			}

			// Next is the NIF's export script encoded as an "ExportString".
			if (SkipBytes._SkipExportString(_NifRawDataStream_, ref _Error_))
			{
				_Error_ = $"An error occured while attempting to skip byte {_NifRawDataStream_.BaseStream.Position} " +
				          $"in the BSStream Header export script for: {_NifIdentifier_}";
				return false;
			}

			// Next is the NIF's "max filepath" encoded as an "ExportString" if BS Version is equal to 130
			// ReSharper disable InvertIf
			if (_BsVersion_ == 130)
			{
				if (SkipBytes._SkipExportString(_NifRawDataStream_, ref _Error_))
				{
					_Error_ = $"An error occured while attempting to skip byte {_NifRawDataStream_.BaseStream.Position} " +
					          $"in the BSStream Header max filepath for: {_NifIdentifier_}";
					return false;
				}
			}
			// ReSharper restore InvertIf
			return true;
		}
	}
}
