// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global


using Nif_CSharp.DataReaders.Header;

namespace Nif_CSharp
{
	public static class NifCSharp
	{
		public static bool ReadEntireNif(string PathToNif, long StreamStartPos, string NifIdentifier, ref string Error)
		{
			FileStream? _fileStream = null;
			try
			{
				_fileStream = File.Open(PathToNif, FileMode.Open, FileAccess.Read);
				_fileStream.Position = StreamStartPos;
			}
			catch (Exception e)
			{
				_fileStream?.DisposeAsync();
				Error = e.ToString();
				return false;
			}

			bool _readEntireNifReturn = ReadEntireNif(_fileStream, NifIdentifier, ref Error, true);
			_fileStream.DisposeAsync();
			return _readEntireNifReturn;
		}

		public static bool ReadEntireNif(Stream NifDataStream, string NifIdentifier, ref string Error, bool ShouldBuffer = false)
		{
			BufferedStream _bufferedStream;
			BinaryReader _binaryReader;
			try
			{
				if (ShouldBuffer)
				{
					_bufferedStream = new BufferedStream(NifDataStream, 16384);

					_binaryReader = new BinaryReader(_bufferedStream);
				}
				else
				{
					_binaryReader = new BinaryReader(NifDataStream);
				}
			}
			catch (Exception e)
			{
				Error = e.ToString();
				return false;
			}

			bool _readHeaderReturn;
			NifHeaderSlim _NifHeaderSlim;
			try
			{
				_NifHeaderSlim = new NifHeaderSlim(_binaryReader, NifIdentifier, ref Error, out _readHeaderReturn);
			}
			catch (Exception e)
			{
				Error = e.ToString();
				return false;
			}

			if (_readHeaderReturn)
			{
				if (ReadNifBody(_binaryReader, NifIdentifier, in _NifHeaderSlim, ref Error))
				{
					return true;
				}
			}

			return false;
		}

		public static bool ReadNifHeader(BinaryReader NifRawDataStream, string NifIdentifier, ref string Error, out NifHeaderData _NifHeaderData)
		{
			bool _readHeaderReturn;
			try
			{
				_NifHeaderData = new NifHeaderData(NifRawDataStream, NifIdentifier, ref Error, out _readHeaderReturn);
			}
			catch (Exception e)
			{
				Error = e.ToString();
				_NifHeaderData = new NifHeaderData();
				return false;
			}

			return _readHeaderReturn;
		}

		public static bool ReadNifBody(BinaryReader NifRawDataStream, string NifIdentifier, in NifHeaderSlim _NifHeaderSlim, ref string Error)
		{
			bool _readHeaderReturn;
			try
			{
				_readHeaderReturn = true;
			}
			catch (Exception e)
			{
				Error = e.ToString();
				return false;
			}

			return _readHeaderReturn;
		}
	}
}
