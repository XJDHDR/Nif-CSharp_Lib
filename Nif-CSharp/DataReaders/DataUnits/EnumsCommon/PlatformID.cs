// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

namespace Nif_CSharp.DataReaders.DataUnits.EnumsCommon
{
	// <enum name="PlatformID" storage="uint" prefix="PLATFORM">
	/// <summary>
	/// Target platform for NiPersistentSrcTextureRendererData (later than 30.1).
	/// </summary>
	public enum PlatformID : uint
	{
		// ReSharper disable InconsistentNaming
		ANY		= 0,
		XENON	= 1,
		PS3		= 2,
		DX9		= 3,
		WII		= 4,
		D3D10	= 5
		// ReSharper restore InconsistentNaming
	}
}
