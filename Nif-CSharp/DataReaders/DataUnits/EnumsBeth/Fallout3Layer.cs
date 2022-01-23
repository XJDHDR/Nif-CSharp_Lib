// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

namespace Nif_CSharp.DataReaders.DataUnits.EnumsBeth
{
	// <enum name="Fallout3Layer" storage="byte" versions="#BETHESDA#">
	/// <summary>
	/// Bethesda Havok. Describes the collision layer a body belongs to in Fallout 3 and Fallout NV.
	/// </summary>
	public enum Fallout3Layer : byte
	{
		// ReSharper disable InconsistentNaming
		FOL_UNIDENTIFIED			=  0, // Unidentified (white)
		FOL_STATIC					=  1, // Static (red)
		FOL_ANIM_STATIC				=  2, // AnimStatic (magenta)
		FOL_TRANSPARENT				=  3, // Transparent (light pink)
		FOL_CLUTTER					=  4, // Clutter (light blue)
		FOL_WEAPON					=  5, // Weapon (orange)
		FOL_PROJECTILE				=  6, // Projectile (light orange)
		FOL_SPELL					=  7, // Spell (cyan)
		FOL_BIPED					=  8, // Biped (green) Seems to apply to all creatures/NPCs
		FOL_TREES					=  9, // Trees (light brown)
		FOL_PROPS					= 10, // Props (magenta)
		FOL_WATER					= 11, // Water (cyan)
		FOL_TRIGGER					= 12, // Trigger (light grey)
		FOL_TERRAIN					= 13, // Terrain (light yellow)
		FOL_TRAP					= 14, // Trap (light grey)
		FOL_NONCOLLIDABLE			= 15, // NonCollidable (white)
		FOL_CLOUD_TRAP				= 16, // CloudTrap (greenish grey)
		FOL_GROUND					= 17, // Ground (none)
		FOL_PORTAL					= 18, // Portal (green)
		FOL_DEBRIS_SMALL			= 19, // DebrisSmall (white)
		FOL_DEBRIS_LARGE			= 20, // DebrisLarge (white)
		FOL_ACOUSTIC_SPACE			= 21, // AcousticSpace (white)
		FOL_ACTORZONE				= 22, // Actorzone (white)
		FOL_PROJECTILEZONE			= 23, // Projectilezone (white)
		FOL_GASTRAP					= 24, // GasTrap (yellowish green)
		FOL_SHELLCASING				= 25, // ShellCasing (white)
		FOL_TRANSPARENT_SMALL		= 26, // TransparentSmall (white)
		FOL_INVISIBLE_WALL			= 27, // InvisibleWall (white)
		FOL_TRANSPARENT_SMALL_ANIM	= 28, // TransparentSmallAnim (white)
		FOL_DEADBIP					= 29, // Dead Biped (green)
		FOL_CHARCONTROLLER			= 30, // CharController (yellow)
		FOL_AVOIDBOX				= 31, // Avoidbox (orange)
		FOL_COLLISIONBOX			= 32, // Collisionbox (white)
		FOL_CAMERASPHERE			= 33, // Camerasphere (white)
		FOL_DOORDETECTION			= 34, // Doordetection (white)
		FOL_CAMERAPICK				= 35, // Camerapick (white)
		FOL_ITEMPICK				= 36, // Itempick (white)
		FOL_LINEOFSIGHT				= 37, // LineOfSight (white)
		FOL_PATHPICK				= 38, // Pathpick (white)
		FOL_CUSTOMPICK1				= 39, // Custompick1 (white)
		FOL_CUSTOMPICK2				= 40, // Custompick2 (white)
		FOL_SPELLEXPLOSION			= 41, // SpellExplosion (white)
		FOL_DROPPINGPICK			= 42, // Droppingpick (white)
		FOL_NULL					= 43  // Null (white)
		// ReSharper restore InconsistentNaming
	}
}
