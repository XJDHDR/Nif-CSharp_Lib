// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here:

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

using Nif_CSharp.DataReaders;

namespace Nif_CSharp
{
	public static class NifCSharp
	{
		public static bool ReadEntireNif(string PathToNif, long StreamStartPos, ref string Error)
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

			bool _readEntireNifReturn = ReadEntireNif(_fileStream, ref Error);
			_fileStream.DisposeAsync();
			return _readEntireNifReturn;
		}

		public static bool ReadEntireNif(Stream NifDataStream, ref string Error, bool ShouldBuffer = false)
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

			if (ReadNifHeader(_binaryReader, ref Error))
			{
				if (ReadNifBody(_binaryReader, ref Error))
				{
					return true;
				}
			}

			return false;
		}

		public static bool ReadNifHeader(BinaryReader NifRawDataStream, ref string Error)
		{
			bool _readHeaderReturn;
			try
			{
				_readHeaderReturn = Header.read();
			}
			catch (Exception e)
			{
				Error = e.ToString();
				return false;
			}

			return _readHeaderReturn;
		}

		public static bool ReadNifBody(BinaryReader NifRawDataStream, ref string Error)
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
