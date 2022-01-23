// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

namespace Nif_CSharp.DataReaders.DataUnits.EnumsCommon
{
	// <enum name="BipedPart" storage="byte">
	/// <summary>
	/// None provided. Probably designates which body part a collection of vertices belongs to.
	/// </summary>
	public enum BipedPart : byte
	{
		// ReSharper disable InconsistentNaming
		P_OTHER			=  0, // Other
		P_HEAD			=  1, // Head
		P_BODY			=  2, // Body
		P_SPINE1		=  3, // Spine1
		P_SPINE2		=  4, // Spine2
		P_L_UPPER_ARM	=  5, // LUpperArm
		P_L_FOREARM		=  6, // LForeArm
		P_L_HAND		=  7, // LHand
		P_L_THIGH		=  8, // LThigh
		P_L_CALF		=  9, // LCalf
		P_L_FOOT		= 10, // LFoot
		P_R_UPPER_ARM	= 11, // RUpperArm
		P_R_FOREARM		= 12, // RForeArm
		P_R_HAND		= 13, // RHand
		P_R_THIGH		= 14, // RThigh
		P_R_CALF		= 15, // RCalf
		P_R_FOOT		= 16, // RFoot
		P_TAIL			= 17, // Tail
		P_SHIELD		= 18, // Shield
		P_QUIVER		= 19, // Quiver
		P_WEAPON		= 20, // Weapon
		P_PONYTAIL		= 21, // Ponytail
		P_WING			= 22, // Wing
		P_PACK			= 23, // Pack
		P_CHAIN			= 24, // Chain
		P_ADDON_HEAD	= 25, // AddonHead
		P_ADDON_CHEST	= 26, // AddonChest
		P_ADDON_LEG		= 27, // AddonLeg
		P_ADDON_ARM		= 28  // AddonArm
		// ReSharper restore InconsistentNaming
	}
}
