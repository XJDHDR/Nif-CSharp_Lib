// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

namespace Nif_CSharp.DataReaders.DataUnits.EnumsBeth
{
	// <enum name="hkMoppCodeBuildType" storage="byte" versions="#SKY_AND_LATER#">
	/// <summary>
	/// hkpMoppCode::BuildType - A byte describing if MOPP Data is organized into chunks (PS3) or not (PC)
	/// </summary>
	public enum hkMoppCodeBuildType : byte
	{
		// ReSharper disable InconsistentNaming
		BUILT_WITH_CHUNK_SUBDIVISION	= 0, // Organized in chunks for PS3.
		BUILT_WITHOUT_CHUNK_SUBDIVISION	= 1, // Not organized in chunks for PC. (Default)
		BUILD_NOT_SET					= 2  // Build type not set yet.
		// ReSharper restore InconsistentNaming
	}
}
