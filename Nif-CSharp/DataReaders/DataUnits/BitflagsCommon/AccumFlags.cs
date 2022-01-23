// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

using System;

namespace Nif_CSharp.DataReaders.DataUnits.BitflagsCommon
{
	// <bitflags name="AccumFlags" storage="uint">
	/// <summary>
	/// Describes the options for the accum root on NiControllerSequence.
	/// </summary>
	[Flags]
	public enum AccumFlags : uint
	{
		// ReSharper disable InconsistentNaming
		ACCUM_X_TRANS	= 0b0000000001, // X Translation will be accumulated.
		ACCUM_Y_TRANS	= 0b0000000010, // Y Translation will be accumulated.
		ACCUM_Z_TRANS	= 0b0000000100, // Z Translation will be accumulated.
		ACCUM_X_ROT		= 0b0000001000, // X Rotation will be accumulated.
		ACCUM_Y_ROT		= 0b0000010000, // Y Rotation will be accumulated.
		ACCUM_Z_ROT		= 0b0000100000, // Z Rotation will be accumulated.
		ACCUM_X_FRONT	= 0b0001000000, // +X is front facing. (Default)
		ACCUM_Y_FRONT	= 0b0010000000, // +Y is front facing.
		ACCUM_Z_FRONT	= 0b0100000000, // +Z is front facing.
		ACCUM_NEG_FRONT	= 0b1000000000  // -X is front facing.
		// ReSharper restore InconsistentNaming
	}
}
