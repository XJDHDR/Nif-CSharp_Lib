// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


// ReSharper disable MemberCanBePrivate.Global


using System;
using System.IO;
using Nif_CSharp.DataReaders.Header;

namespace Nif_CSharp
{
	/// <summary>
	/// Class used to provide a public frontend for reading the header and/or blocks of an NIF model.
	/// </summary>
	public static class NifCSharp
	{
		/// <summary>
		/// Used to read the entire contents of an NIF file from a file path.
		/// </summary>
		/// <param name="_PathToNif_">Path to the NIF model to be read.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <param name="_StreamStartPos_">Use this to set the starting position of the NIF data, if it's not at the file's start pos.</param>
		/// <returns>True if the model's data was successfully read. False if an error occurred.</returns>
		public static bool ReadEntireNif(string _PathToNif_, string _NifIdentifier_, ref string _Error_, long _StreamStartPos_ = 0)
		{
			FileStream? _fileStream_ = null;
			try
			{
				_fileStream_ = File.Open(_PathToNif_, FileMode.Open, FileAccess.Read);
				_fileStream_.Position = _StreamStartPos_;
			}
			catch (Exception _e_)
			{
				_fileStream_?.DisposeAsync();
				_Error_ = _e_.ToString();
				return false;
			}

			bool _readEntireNifReturn_ = ReadEntireNif(_fileStream_, _NifIdentifier_, ref _Error_, true);
			_fileStream_.DisposeAsync();
			return _readEntireNifReturn_;
		}

		/// <summary>
		/// Used to read the entire contents of an NIF file from one of C#'s Stream classes.
		/// </summary>
		/// <param name="_NifDataStream_">Supply a seekable Stream pointing to the raw NIF data.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <param name="_ShouldBuffer_">Set to True is you want to use a BufferedStream to cache the contents of the NIF data stream.
		/// Recommended if you are supplying NIF data from a slow and uncached stream.</param>
		/// <returns>True if the model's data was successfully read. False if an error occurred.</returns>
		public static bool ReadEntireNif(Stream _NifDataStream_, string _NifIdentifier_, ref string _Error_, bool _ShouldBuffer_ = false)
		{
			BinaryReader _binaryReader_;
			try
			{
				if (_ShouldBuffer_)
				{
					BufferedStream _bufferedStream_ = new BufferedStream(_NifDataStream_, 16384);

					_binaryReader_ = new BinaryReader(_bufferedStream_);
				}
				else
				{
					_binaryReader_ = new BinaryReader(_NifDataStream_);
				}
			}
			catch (Exception _e_)
			{
				_Error_ = _e_.ToString();
				return false;
			}

			bool _readHeaderReturn_;
			NifHeaderSlim _nifHeaderSlim_;

			try
			{
				_nifHeaderSlim_ = new NifHeaderSlim(_binaryReader_, in _NifIdentifier_, ref _Error_, out _readHeaderReturn_);
			}
			catch (Exception _e_)
			{
				_Error_ = _e_.ToString();
				return false;
			}

			if (_readHeaderReturn_)
			{
				if (ReadNifBody(_binaryReader_, _NifIdentifier_, in _nifHeaderSlim_, ref _Error_))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Read all of the NIF's header data into a struct.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <param name="_NifHeaderData_">Struct containing the full contents of the NIF's header.</param>
		/// <returns>True if the model's data was successfully read. False if an error occurred.</returns>
		public static bool ReadNifHeader(BinaryReader _NifRawDataStream_, string _NifIdentifier_, ref string _Error_, out NifHeaderData _NifHeaderData_)
		{
			bool _readHeaderReturn_;

			try
			{
				_NifHeaderData_ = new NifHeaderData(_NifRawDataStream_, in _NifIdentifier_, ref _Error_, out _readHeaderReturn_);
			}
			catch (Exception _e_)
			{
				_Error_ = _e_.ToString();
				_NifHeaderData_ = new NifHeaderData();
				return false;
			}

			return _readHeaderReturn_;
		}

		/// <summary>
		/// Read all of the blocks contained in an NIF model's body.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_NifHeaderSlim_">Supply a Slim NIF Header struct containing only the data needed to read the blocks for this model.</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <returns>True if the model's data was successfully read. False if an error occurred.</returns>
		public static bool ReadNifBody(BinaryReader _NifRawDataStream_, string _NifIdentifier_, in NifHeaderSlim _NifHeaderSlim_, ref string _Error_)
		{
			bool _readHeaderReturn_;

			try
			{
				_readHeaderReturn_ = true;
			}
			catch (Exception _e_)
			{
				_Error_ = _e_.ToString();
				return false;
			}

			return _readHeaderReturn_;
		}
	}
}
