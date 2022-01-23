// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

namespace Nif_CSharp.DataReaders.DataUnits.EnumsCommon
{
	// <enum name="RendererID" storage="uint" prefix="RENDERER">
	/// <summary>
	/// Target renderer for NiPersistentSrcTextureRendererData (until 30.1).
	/// </summary>
	public enum RendererID : uint
	{
		// ReSharper disable InconsistentNaming
		XBOX360	= 0,
		PS3		= 1,
		DX9		= 2,
		D3D10	= 3,
		WII		= 4,
		GENERIC	= 5,
		D3D11	= 6
		// ReSharper restore InconsistentNaming
	}
}
