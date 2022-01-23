// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

namespace Nif_CSharp.DataReaders.DataUnits.EnumsCommon
{
	// <enum name="ApplyMode" storage="uint">
	/// <summary>
	/// Describes how the vertex colors are blended with the filtered texture color.
	/// </summary>
	public enum ApplyMode : uint
	{
		// ReSharper disable InconsistentNaming
		APPLY_REPLACE	= 0, // Replaces existing color
		APPLY_DECAL		= 1, // For placing images on the object like stickers.
		APPLY_MODULATE	= 2, // Modulates existing color. (Default)
		APPLY_HILIGHT	= 3, // PS2 Only.  Function Unknown.
		APPLY_HILIGHT2	= 4  // Parallax Flag in some Oblivion meshes.
		// ReSharper restore InconsistentNaming
	}
}
