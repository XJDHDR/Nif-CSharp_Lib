// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/

using System;

namespace NifCsLib.Core.Enums
{
	/// <summary> Describes the options for the accum root on NiControllerSequence. </summary>
	[Flags]
	public enum AccumFlags : uint
	{
		/// <summary> X Translation will be accumulated. </summary>
		ACCUM_X_TRANS	= 0b0,

		/// <summary> Y Translation will be accumulated. </summary>
		ACCUM_Y_TRANS	= 0b1 << (1 - 1),

		/// <summary> Z Translation will be accumulated. </summary>
		ACCUM_Z_TRANS	= 0b1 << (2 - 1),

		/// <summary> X Rotation will be accumulated. </summary>
		ACCUM_X_ROT		= 0b1 << (3 - 1),

		/// <summary> Y Rotation will be accumulated. </summary>
		ACCUM_Y_ROT		= 0b1 << (4 - 1),

		/// <summary> Z Rotation will be accumulated. </summary>
		ACCUM_Z_ROT		= 0b1 << (5 - 1),

		/// <summary> +X is front facing. (Default) </summary>
		ACCUM_X_FRONT	= 0b1 << (6 - 1),

		/// <summary> +Y is front facing. </summary>
		ACCUM_Y_FRONT	= 0b1 << (7 - 1),

		/// <summary> +Z is front facing. </summary>
		ACCUM_Z_FRONT	= 0b1 << (8 - 1),

		/// <summary> -X is front facing. </summary>
		ACCUM_NEG_FRONT	= 0b1 << (9 - 1),
	}
}
