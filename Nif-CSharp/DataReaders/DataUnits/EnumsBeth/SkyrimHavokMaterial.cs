// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

namespace Nif_CSharp.DataReaders.DataUnits.EnumsBeth
{
	// <enum name="SkyrimHavokMaterial" storage="uint" versions="#SKY_AND_LATER#">
	/// <summary>
	/// Bethesda Havok. Material descriptor for a Havok shape in Skyrim.
	/// </summary>
	public enum SkyrimHavokMaterial : uint
	{
		// ReSharper disable InconsistentNaming
		SKY_HAV_MAT_BROKEN_STONE				=  131151687, // Broken Stone
		SKY_HAV_MAT_LIGHT_WOOD					=  365420259, // Light Wood
		SKY_HAV_MAT_SNOW						=  398949039, // Snow
		SKY_HAV_MAT_GRAVEL						=  428587608, // Gravel
		SKY_HAV_MAT_MATERIAL_CHAIN_METAL		=  438912228, // Material Chain Metal
		SKY_HAV_MAT_BOTTLE						=  493553910, // Bottle
		SKY_HAV_MAT_WOOD						=  500811281, // Wood
		SKY_HAV_MAT_SKIN						=  591247106, // Skin
		SKY_HAV_MAT_UNKNOWN_617099282			=  617099282, // Unknown in Creation Kit v1.9.32.0. Found in Dawnguard DLC in meshes\dlc01\clutter\dlc01deerskin.nif.
		SKY_HAV_MAT_BARREL						=  732141076, // Barrel
		SKY_HAV_MAT_MATERIAL_CERAMIC_MEDIUM		=  781661019, // Material Ceramic Medium
		SKY_HAV_MAT_MATERIAL_BASKET				=  790784366, // Material Basket
		SKY_HAV_MAT_ICE							=  873356572, // Ice
		SKY_HAV_MAT_STAIRS_STONE				=  899511101, // Stairs Stone
		SKY_HAV_MAT_WATER						= 1024582599, // Water
		SKY_HAV_MAT_UNKNOWN_1028101969			= 1028101969, // Unknown in Creation Kit v1.6.89.0. Found in actors\draugr\character assets\skeletons.nif.
		SKY_HAV_MAT_MATERIAL_BLADE_1HAND		= 1060167844, // Material Blade 1 Hand
		SKY_HAV_MAT_MATERIAL_BOOK				= 1264672850, // Material Book
		SKY_HAV_MAT_MATERIAL_CARPET				= 1286705471, // Material Carpet
		SKY_HAV_MAT_SOLID_METAL					= 1288358971, // Solid Metal
		SKY_HAV_MAT_MATERIAL_AXE_1HAND			= 1305674443, // Material Axe 1Hand
		SKY_HAV_MAT_UNKNOWN_1440721808			= 1440721808, // Unknown in Creation Kit v1.6.89.0. Found in armor\draugr\draugrbootsfemale_go.nif or armor\amuletsandrings\amuletgnd.nif.
		SKY_HAV_MAT_STAIRS_WOOD					= 1461712277, // Stairs Wood
		SKY_HAV_MAT_MUD							= 1486385281, // Mud
		SKY_HAV_MAT_MATERIAL_BOULDER_SMALL		= 1550912982, // Material Boulder Small
		SKY_HAV_MAT_STAIRS_SNOW					= 1560365355, // Stairs Snow
		SKY_HAV_MAT_HEAVY_STONE					= 1570821952, // Heavy Stone
		SKY_HAV_MAT_UNKNOWN_1574477864			= 1574477864, // Unknown in Creation Kit v1.6.89.0. Found in actors\dragon\character assets\skeleton.nif.
		SKY_HAV_MAT_UNKNOWN_1591009235			= 1591009235, // Unknown in Creation Kit v1.6.89.0. Found in trap objects or clutter\displaycases\displaycaselgangled01.nif or actors\deer\character assets\skeleton.nif.
		SKY_HAV_MAT_MATERIAL_BOWS_STAVES		= 1607128641, // Material Bows Staves
		SKY_HAV_MAT_MATERIAL_WOOD_AS_STAIRS		= 1803571212, // Material Wood As Stairs
		SKY_HAV_MAT_GRASS						= 1848600814, // Grass
		SKY_HAV_MAT_MATERIAL_BOULDER_LARGE		= 1885326971, // Material Boulder Large
		SKY_HAV_MAT_MATERIAL_STONE_AS_STAIRS	= 1886078335, // Material Stone As Stairs
		SKY_HAV_MAT_MATERIAL_BLADE_2HAND		= 2022742644, // Material Blade 2Hand
		SKY_HAV_MAT_MATERIAL_BOTTLE_SMALL		= 2025794648, // Material Bottle Small
		SKY_HAV_MAT_SAND						= 2168343821, // Sand
		SKY_HAV_MAT_HEAVY_METAL					= 2229413539, // Heavy Metal
		SKY_HAV_MAT_UNKNOWN_2290050264			= 2290050264, // Unknown in Creation Kit v1.9.32.0. Found in Dawnguard DLC in meshes\dlc01\clutter\dlc01sabrecatpelt.nif.
		SKY_HAV_MAT_DRAGON						= 2518321175, // Dragon
		SKY_HAV_MAT_MATERIAL_BLADE_1HAND_SMALL	= 2617944780, // Material Blade 1Hand Small
		SKY_HAV_MAT_MATERIAL_SKIN_SMALL			= 2632367422, // Material Skin Small
		SKY_HAV_MAT_STAIRS_BROKEN_STONE			= 2892392795, // Stairs Broken Stone
		SKY_HAV_MAT_MATERIAL_SKIN_LARGE			= 2965929619, // Material Skin Large
		SKY_HAV_MAT_ORGANIC						= 2974920155, // Organic
		SKY_HAV_MAT_MATERIAL_BONE				= 3049421844, // Material Bone
		SKY_HAV_MAT_HEAVY_WOOD					= 3070783559, // Heavy Wood
		SKY_HAV_MAT_MATERIAL_CHAIN				= 3074114406, // Material Chain
		SKY_HAV_MAT_DIRT						= 3106094762, // Dirt
		SKY_HAV_MAT_MATERIAL_ARMOR_LIGHT		= 3424720541, // Material Armor Light
		SKY_HAV_MAT_MATERIAL_SHIELD_LIGHT		= 3448167928, // Material Shield Light
		SKY_HAV_MAT_MATERIAL_COIN				= 3589100606, // Material Coin
		SKY_HAV_MAT_MATERIAL_SHIELD_HEAVY		= 3702389584, // Material Shield Heavy
		SKY_HAV_MAT_MATERIAL_ARMOR_HEAVY		= 3708432437, // Material Armor Heavy
		SKY_HAV_MAT_MATERIAL_ARROW				= 3725505938, // Material Arrow
		SKY_HAV_MAT_GLASS						= 3739830338, // Glass
		SKY_HAV_MAT_STONE						= 3741512247, // Stone
		SKY_HAV_MAT_CLOTH						= 3839073443, // Cloth
		SKY_HAV_MAT_MATERIAL_BLUNT_2HAND		= 3969592277, // Material Blunt 2Hand
		SKY_HAV_MAT_UNKNOWN_4239621792			= 4239621792, // Unknown in Creation Kit v1.9.32.0. Found in Dawnguard DLC in meshes\dlc01\prototype\dlc1protoswingingbridge.nif.
		SKY_HAV_MAT_MATERIAL_BOULDER_MEDIUM		= 4283869410  // Material Boulder Medium
		// ReSharper restore InconsistentNaming

	}
}
