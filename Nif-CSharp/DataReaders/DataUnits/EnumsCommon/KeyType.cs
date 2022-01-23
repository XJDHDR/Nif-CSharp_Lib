// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

namespace Nif_CSharp.DataReaders.DataUnits.EnumsCommon
{
	// <enum name="KeyType" storage="uint">
	/// <summary>
	/// The type of animation interpolation (blending) that will be used on the associated key frames.
	/// </summary>
	public enum KeyType : uint
	{
		// ReSharper disable InconsistentNaming
		LINEAR_KEY			= 1, // Use linear interpolation.
		QUADRATIC_KEY		= 2, // Use quadratic interpolation.  Forward and back tangents will be stored.
		TBC_KEY				= 3, // Use Tension Bias Continuity interpolation.  Tension, bias, and continuity will be stored.
		XYZ_ROTATION_KEY	= 4, // For use only with rotation data.  Separate X, Y, and Z keys will be stored instead of using quaternions.
		CONST_KEY			= 5  // Step function. Used for visibility keys in NiBoolData.
		// ReSharper restore InconsistentNaming
	}
}
