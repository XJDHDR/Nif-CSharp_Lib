// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

namespace Nif_CSharp.DataReaders.DataUnits.EnumsBeth
{
	// <enum name="OblivionLayer" storage="byte" versions="#BETHESDA#">
	/// <summary>
	/// Bethesda Havok. Describes the collision layer a body belongs to in Oblivion.
	/// </summary>
	public enum OblivionLayer : byte
	{
		// ReSharper disable InconsistentNaming
		OL_UNIDENTIFIED		=  0, // Unidentified (white)
		OL_STATIC			=  1, // Static (red)
		OL_ANIM_STATIC		=  2, // AnimStatic (magenta)
		OL_TRANSPARENT		=  3, // Transparent (light pink)
		OL_CLUTTER			=  4, // Clutter (light blue)
		OL_WEAPON			=  5, // Weapon (orange)
		OL_PROJECTILE		=  6, // Projectile (light orange)
		OL_SPELL			=  7, // Spell (cyan)
		OL_BIPED			=  8, // Biped (green) Seems to apply to all creatures/NPCs
		OL_TREES			=  9, // Trees (light brown)
		OL_PROPS			= 10, // Props (magenta)
		OL_WATER			= 11, // Water (cyan)
		OL_TRIGGER			= 12, // Trigger (light grey)
		OL_TERRAIN			= 13, // Terrain (light yellow)
		OL_TRAP				= 14, // Trap (light grey)
		OL_NONCOLLIDABLE	= 15, // NonCollidable (white)
		OL_CLOUD_TRAP		= 16, // CloudTrap (greenish grey)
		OL_GROUND			= 17, // Ground (none)
		OL_PORTAL			= 18, // Portal (green)
		OL_STAIRS			= 19, // Stairs (white)
		OL_CHAR_CONTROLLER	= 20, // CharController (yellow)
		OL_AVOID_BOX		= 21, // AvoidBox (dark yellow)
		OL_UNKNOWN1			= 22, // ? (white)
		OL_UNKNOWN2			= 23, // ? (white)
		OL_CAMERA_PICK		= 24, // CameraPick (white)
		OL_ITEM_PICK		= 25, // ItemPick (white)
		OL_LINE_OF_SIGHT	= 26, // LineOfSight (white)
		OL_PATH_PICK		= 27, // PathPick (white)
		OL_CUSTOM_PICK_1	= 28, // CustomPick1 (white)
		OL_CUSTOM_PICK_2	= 29, // CustomPick2 (white)
		OL_SPELL_EXPLOSION	= 30, // SpellExplosion (white)
		OL_DROPPING_PICK	= 31, // DroppingPick (white)
		OL_OTHER			= 32, // Other (white)
		OL_HEAD				= 33, // Head
		OL_BODY				= 34, // Body
		OL_SPINE1			= 35, // Spine1
		OL_SPINE2			= 36, // Spine2
		OL_L_UPPER_ARM		= 37, // LUpperArm
		OL_L_FOREARM		= 38, // LForeArm
		OL_L_HAND			= 39, // LHand
		OL_L_THIGH			= 40, // LThigh
		OL_L_CALF			= 41, // LCalf
		OL_L_FOOT			= 42, // LFoot
		OL_R_UPPER_ARM		= 43, // RUpperArm
		OL_R_FOREARM		= 44, // RForeArm
		OL_R_HAND			= 45, // RHand
		OL_R_THIGH			= 46, // RThigh
		OL_R_CALF			= 47, // RCalf
		OL_R_FOOT			= 48, // RFoot
		OL_TAIL				= 49, // Tail
		OL_SIDE_WEAPON		= 50, // SideWeapon
		OL_SHIELD			= 51, // Shield
		OL_QUIVER			= 52, // Quiver
		OL_BACK_WEAPON		= 53, // BackWeapon
		OL_BACK_WEAPON2		= 54, // BackWeapon (?)
		OL_PONYTAIL			= 55, // PonyTail
		OL_WING				= 56, // Wing
		OL_NULL				= 57  // Null
		// ReSharper restore InconsistentNaming
		// ReSharper restore InconsistentNaming
	}
}
