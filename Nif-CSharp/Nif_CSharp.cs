// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


// ReSharper disable MemberCanBePrivate.Global


using Nif_CSharp.DataReaders.Header;

namespace Nif_CSharp
{
	public static class NifCSharp
	{
		public static bool ReadEntireNif(string _PathToNif_, long _StreamStartPos_, string _NifIdentifier_, ref string _Error_)
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
				_nifHeaderSlim_ = new NifHeaderSlim(_binaryReader_, _NifIdentifier_, ref _Error_, out _readHeaderReturn_);
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

		public static bool ReadNifHeader(BinaryReader _NifRawDataStream_, string _NifIdentifier_, ref string _Error_, out NifHeaderData _NifHeaderData_)
		{
			bool _readHeaderReturn_;
			try
			{
				_NifHeaderData_ = new NifHeaderData(_NifRawDataStream_, _NifIdentifier_, ref _Error_, out _readHeaderReturn_);
			}
			catch (Exception _e_)
			{
				_Error_ = _e_.ToString();
				_NifHeaderData_ = new NifHeaderData();
				return false;
			}

			return _readHeaderReturn_;
		}

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
