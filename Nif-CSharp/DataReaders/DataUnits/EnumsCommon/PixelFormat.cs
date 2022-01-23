// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

namespace Nif_CSharp.DataReaders.DataUnits.EnumsCommon
{
	// <enum name="PixelFormat" storage="uint" prefix="PX">
	/// <summary>
	/// Describes the pixel format used by the NiPixelData object to store a texture.
	/// </summary>
	public enum PixelFormat : uint
	{
		// ReSharper disable InconsistentNaming
		FMT_RGB				=  0, // 24-bit RGB. 8 bits per red, blue, and green component.
		FMT_RGBA			=  1, // 32-bit RGB with alpha. 8 bits per red, blue, green, and alpha component.
		FMT_PAL				=  2, // 8-bit palette index.
		FMT_PALA			=  3, // 8-bit palette index with alpha.
		FMT_DXT1			=  4, // DXT1 compressed texture.
		FMT_DXT3			=  5, // DXT3 compressed texture.
		FMT_DXT5			=  6, // DXT5 compressed texture.
		FMT_RGB24NONINT		=  7, // (Deprecated) 24-bit noninterleaved texture, an old PS2 format.
		FMT_BUMP			=  8, // Uncompressed dU/dV gradient bump map.
		FMT_BUMPLUMA		=  9, // Uncompressed dU/dV gradient bump map with luma channel representing shininess.
		FMT_RENDERSPEC		= 10, // Generic descriptor for any renderer-specific format not described by other formats.
		FMT_1CH				= 11, // Generic descriptor for formats with 1 component.
		FMT_2CH				= 12, // Generic descriptor for formats with 2 components.
		FMT_3CH				= 13, // Generic descriptor for formats with 3 components.
		FMT_4CH				= 14, // Generic descriptor for formats with 4 components.
		FMT_DEPTH_STENCIL	= 15, // Indicates the NiPixelFormat is meant to be used on a depth/stencil surface.
		FMT_UNKNOWN			= 16
		// ReSharper restore InconsistentNaming
	}
}
