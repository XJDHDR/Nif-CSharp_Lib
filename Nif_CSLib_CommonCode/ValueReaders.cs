// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

using System;
using System.Buffers.Binary;
using System.IO;

namespace Nif_CSLib_CommonCode
{
	/// <summary>
	/// Struct used to hold methods that can be used to read binary data into C# value types, taking the NIF's endianness
	/// into account.
	/// </summary>
	public struct ValueReaders
	{
		/// <summary>
		/// Read a UInt64 value from a BinaryReader, taking the data and system's endianness into account.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_IsDataLittleEndian_">Set to True if the data being read is in little-endian format.
		/// Set to false if it's big-endian.</param>
		/// <returns>The UInt64 that was read.</returns>
		public static ulong _UInt64(BinaryReader _NifRawDataStream_, in bool _IsDataLittleEndian_)
		{
			if (_IsDataLittleEndian_ == BitConverter.IsLittleEndian)
			{
				return _NifRawDataStream_.ReadUInt64();
			}

			ulong _bigEndianValueRead_ = _NifRawDataStream_.ReadUInt64();
			return BinaryPrimitives.ReverseEndianness(_bigEndianValueRead_);
		}

		/// <summary>
		/// Read an Int64 value from a BinaryReader, taking the data and system's endianness into account.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_IsDataLittleEndian_">Set to True if the data being read is in little-endian format.
		/// Set to false if it's big-endian.</param>
		/// <returns>The Int64 that was read.</returns>
		public static long _Int64(BinaryReader _NifRawDataStream_, in bool _IsDataLittleEndian_)
		{
			if (_IsDataLittleEndian_ == BitConverter.IsLittleEndian)
			{
				return _NifRawDataStream_.ReadInt64();
			}

			long _bigEndianValueRead_ = _NifRawDataStream_.ReadInt64();
			return BinaryPrimitives.ReverseEndianness(_bigEndianValueRead_);
		}

		/// <summary>
		/// Read a little-endian UInt32 value from a BinaryReader, taking the system's endianness into account.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_IsDataLittleEndian_">Set to True if the data being read is in little-endian format.
		/// Set to false if it's big-endian.</param>
		/// <returns>The UInt32 that was read.</returns>
		public static uint _ULittle32(BinaryReader _NifRawDataStream_, in bool _IsDataLittleEndian_)
		{
			if (BitConverter.IsLittleEndian)
			{
				return _NifRawDataStream_.ReadUInt32();
			}

			uint _bigEndianValueRead_ = _NifRawDataStream_.ReadUInt32();
			return BinaryPrimitives.ReverseEndianness(_bigEndianValueRead_);
		}

		/// <summary>
		/// Read a UInt32 value from a BinaryReader, taking the data and system's endianness into account.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_IsDataLittleEndian_">Set to True if the data being read is in little-endian format.
		/// Set to false if it's big-endian.</param>
		/// <returns>The UInt32 that was read.</returns>
		public static uint _UInt(BinaryReader _NifRawDataStream_, in bool _IsDataLittleEndian_)
		{
			if (_IsDataLittleEndian_ == BitConverter.IsLittleEndian)
			{
				return _NifRawDataStream_.ReadUInt32();
			}

			uint _bigEndianValueRead_ = _NifRawDataStream_.ReadUInt32();
			return BinaryPrimitives.ReverseEndianness(_bigEndianValueRead_);
		}

		/// <summary>
		/// Read an Int32 value from a BinaryReader, taking the data and system's endianness into account.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_IsDataLittleEndian_">Set to True if the data being read is in little-endian format.
		/// Set to false if it's big-endian.</param>
		/// <returns>The Int32 that was read.</returns>
		public static int _Int(BinaryReader _NifRawDataStream_, in bool _IsDataLittleEndian_)
		{
			if (_IsDataLittleEndian_ == BitConverter.IsLittleEndian)
			{
				return _NifRawDataStream_.ReadInt32();
			}

			int _bigEndianValueRead_ = _NifRawDataStream_.ReadInt32();
			return BinaryPrimitives.ReverseEndianness(_bigEndianValueRead_);
		}

		/// <summary>
		/// Read a UInt16 value from a BinaryReader, taking the data and system's endianness into account.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_IsDataLittleEndian_">Set to True if the data being read is in little-endian format.
		/// Set to false if it's big-endian.</param>
		/// <returns>The UInt16 that was read.</returns>
		public static ushort _UShort(BinaryReader _NifRawDataStream_, in bool _IsDataLittleEndian_)
		{
			if (_IsDataLittleEndian_ == BitConverter.IsLittleEndian)
			{
				return _NifRawDataStream_.ReadUInt16();
			}

			ushort _bigEndianValueRead_ = _NifRawDataStream_.ReadUInt16();
			return BinaryPrimitives.ReverseEndianness(_bigEndianValueRead_);
		}

		/// <summary>
		/// Read an Int16 value from a BinaryReader, taking the data and system's endianness into account.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_IsDataLittleEndian_">Set to True if the data being read is in little-endian format.
		/// Set to false if it's big-endian.</param>
		/// <returns>The Int16 that was read.</returns>
		public static short _Short(BinaryReader _NifRawDataStream_, in bool _IsDataLittleEndian_)
		{
			if (_IsDataLittleEndian_ == BitConverter.IsLittleEndian)
			{
				return _NifRawDataStream_.ReadInt16();
			}

			short _bigEndianValueRead_ = _NifRawDataStream_.ReadInt16();
			return BinaryPrimitives.ReverseEndianness(_bigEndianValueRead_);
		}

		/// <summary>
		/// Read a boolean from a BinaryReader, taking the data and system's endianness into account.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_NifVersion_">The NIF's version that was read from the Header String.</param>
		/// <param name="_IsDataLittleEndian_">Set to True if the data being read is in little-endian format.
		/// Set to false if it's big-endian.</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <param name="_ReadBool_">The boolean that was read.</param>
		/// <returns></returns>
		public static bool _Bool(BinaryReader _NifRawDataStream_, in string _NifIdentifier_, in uint _NifVersion_,
			in bool _IsDataLittleEndian_, ref string _Error_,  out bool _ReadBool_)
		{
			uint _readBoolVal_;
			if (_NifVersion_ >= 0x04010001)
			{
				_readBoolVal_ = _NifRawDataStream_.ReadUInt32();
				if (_IsDataLittleEndian_ != BitConverter.IsLittleEndian)
				{
					_readBoolVal_ = BinaryPrimitives.ReverseEndianness(_readBoolVal_);
				}
			}
			else
			{
				_readBoolVal_ = _NifRawDataStream_.ReadByte();
			}

			switch (_readBoolVal_)
			{
				case 1:
					_ReadBool_ = true;
					return true;

				case 0:
					_ReadBool_ = false;
					return true;

				default:
					_Error_ += $"Error while reading byte {_NifRawDataStream_.BaseStream.Position} in " +
					           $"Nif: {_NifIdentifier_}\n" +
					           "The boolean value that was read is supposed to be equal to " +
					           $"either 1 or 0 but {_readBoolVal_} was read instead";
					_ReadBool_ = false;
					return false;
			}
		}

		/// <summary>
		/// Read a single precision float value from a BinaryReader, taking the data and system's endianness into account.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_IsDataLittleEndian_">Set to True if the data being read is in little-endian format.
		/// Set to false if it's big-endian.</param>
		/// <returns>The Float that was read.</returns>
		public static float _Float(BinaryReader _NifRawDataStream_, in bool _IsDataLittleEndian_)
		{
			if (_IsDataLittleEndian_ == BitConverter.IsLittleEndian)
			{
				return _NifRawDataStream_.ReadSingle();
			}

			byte[] _floatBytes_ = _NifRawDataStream_.ReadBytes(4);
			return BitConverter.ToSingle(_floatBytes_, 0);
		}

		/// <summary>
		/// Read a half precision float value from a BinaryReader, taking the data and system's endianness into account.
		/// </summary>
		/// <param name="_NifRawDataStream_">Supply a BinaryReader that contains the NIF data.</param>
		/// <param name="_IsDataLittleEndian_">Set to True if the data being read is in little-endian format.
		/// Set to false if it's big-endian.</param>
		/// <returns>The Half Float that was read.</returns>
		public static float _HFloat(BinaryReader _NifRawDataStream_, in bool _IsDataLittleEndian_)
		{
			// TODO: Convert this to use the "Half" value type if and when .NET 5 support is added.
			if (_IsDataLittleEndian_ == BitConverter.IsLittleEndian)
			{
				return _NifRawDataStream_.ReadSingle();
			}

			byte[] _floatBytes_ = _NifRawDataStream_.ReadBytes(2);
			return BitConverter.ToSingle(_floatBytes_, 0);
		}

	}
}
