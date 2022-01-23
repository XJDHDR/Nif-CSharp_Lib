// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

namespace Nif_CSharp.DataReaders.DataUnits.EnumsBeth
{
	// <enum name="SkyrimLayer" storage="byte" versions="#SKY_AND_LATER#">
	/// <summary>
	/// Bethesda Havok. Describes the collision layer a body belongs to in Skyrim.
	/// </summary>
	public enum SkyrimLayer : byte
	{
		// ReSharper disable InconsistentNaming
		SKYL_UNIDENTIFIED			=  0, // Unidentified
		SKYL_STATIC					=  1, // Static
		SKYL_ANIMSTATIC				=  2, // Anim Static
		SKYL_TRANSPARENT			=  3, // Transparent
		SKYL_CLUTTER				=  4, // Clutter. Object with this layer will float on water surface.
		SKYL_WEAPON					=  5, // Weapon
		SKYL_PROJECTILE				=  6, // Projectile
		SKYL_SPELL					=  7, // Spell
		SKYL_BIPED					=  8, // Biped. Seems to apply to all creatures/NPCs
		SKYL_TREES					=  9, // Trees
		SKYL_PROPS					= 10, // Props
		SKYL_WATER					= 11, // Water
		SKYL_TRIGGER				= 12, // Trigger
		SKYL_TERRAIN				= 13, // Terrain
		SKYL_TRAP					= 14, // Trap
		SKYL_NONCOLLIDABLE			= 15, // NonCollidable
		SKYL_CLOUD_TRAP				= 16, // CloudTrap
		SKYL_GROUND					= 17, // Ground. It seems that produces no sound when collide.
		SKYL_PORTAL					= 18, // Portal
		SKYL_DEBRIS_SMALL			= 19, // Debris Small
		SKYL_DEBRIS_LARGE			= 20, // Debris Large
		SKYL_ACOUSTIC_SPACE			= 21, // Acoustic Space
		SKYL_ACTORZONE				= 22, // Actor Zone
		SKYL_PROJECTILEZONE			= 23, // Projectile Zone
		SKYL_GASTRAP				= 24, // Gas Trap
		SKYL_SHELLCASING			= 25, // Shell Casing
		SKYL_TRANSPARENT_SMALL		= 26, // Transparent Small
		SKYL_INVISIBLE_WALL			= 27, // Invisible Wall
		SKYL_TRANSPARENT_SMALL_ANIM	= 28, // Transparent Small Anim
		SKYL_WARD					= 29, // Ward
		SKYL_CHARCONTROLLER			= 30, // Char Controller
		SKYL_STAIRHELPER			= 31, // Stair Helper
		SKYL_DEADBIP				= 32, // Dead Bip
		SKYL_BIPED_NO_CC			= 33, // Biped No CC
		SKYL_AVOIDBOX				= 34, // Avoid Box
		SKYL_COLLISIONBOX			= 35, // Collision Box
		SKYL_CAMERASHPERE			= 36, // Camera Sphere
		SKYL_DOORDETECTION			= 37, // Door Detection
		SKYL_CONEPROJECTILE			= 38, // Cone Projectile
		SKYL_CAMERAPICK				= 39, // Camera Pick
		SKYL_ITEMPICK				= 40, // Item Pick
		SKYL_LINEOFSIGHT			= 41, // Line of Sight
		SKYL_PATHPICK				= 42, // Path Pick
		SKYL_CUSTOMPICK1			= 43, // Custom Pick 1
		SKYL_CUSTOMPICK2			= 44, // Custom Pick 2
		SKYL_SPELLEXPLOSION			= 45, // Spell Explosion
		SKYL_DROPPINGPICK			= 46, // Dropping Pick
		SKYL_NULL					= 47  // Null
		// ReSharper restore InconsistentNaming
	}
}
