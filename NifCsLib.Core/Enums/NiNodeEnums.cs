// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/

// ReSharper disable InconsistentNaming
namespace NifCsLib.Core.Enums
{
	/// <summary> Describes how the vertex colors are blended with the filtered texture color. </summary>
	public enum ApplyMode : uint
	{
		/// <summary> Replaces existing color. </summary>
		APPLY_REPLACE	= 0,

		/// <summary> For placing images on the object like stickers. </summary>
		APPLY_DECAL		= 1,

		/// <summary> Modulates existing color. </summary>
		APPLY_MODULATE	= 2,

		/// <summary> PS2 Only. </summary>
		APPLY_HILIGHT	= 3,

		/// <summary> Parallax Flag in some Oblivion meshes. </summary>
		APPLY_HILIGHT2	= 4,
	}

	/// <summary> The type of texture. </summary>
	public enum TexType : uint
	{
		/// <summary> The basic texture used by most meshes. </summary>
		BASE_MAP		= 0,

		/// <summary> Used to darken the model with false lighting. </summary>
		DARK_MAP		= 1,

		/// <summary> Combined with base map for added detail. Usually tiled over the mesh many times for close-up view. </summary>
		DETAIL_MAP		= 2,

		/// <summary> Allows the specularity (glossyness) of an object to differ across its surface. </summary>
		GLOSS_MAP		= 3,

		/// <summary> Creates a glowing effect. Basically an incandescence map. </summary>
		GLOW_MAP		= 4,

		/// <summary> Used to make the object appear to have more detail than it really does. </summary>
		BUMP_MAP		= 5,

		/// <summary> Used to make the object appear to have more detail than it really does. </summary>
		NORMAL_MAP		= 6,

		/// <summary> Parallax map. </summary>
		PARALLAX_MAP	= 7,

		/// <summary> For placing images on the object like stickers. </summary>
		DECAL_0_MAP		= 8,

		/// <summary> For placing images on the object like stickers. </summary>
		DECAL_1_MAP		= 9,

		/// <summary> For placing images on the object like stickers. </summary>
		DECAL_2_MAP		= 10,

		/// <summary> For placing images on the object like stickers. </summary>
		DECAL_3_MAP		= 11,
	}

	/// <summary> The type of animation interpolation (blending) that will be used on the associated key frames. </summary>
	public enum KeyType : uint
	{
		/// <summary> Use linear interpolation. </summary>
		LINEAR_KEY			= 1,

		/// <summary> Use quadratic interpolation.  Forward and back tangents will be stored. </summary>
		QUADRATIC_KEY		= 2,

		/// <summary> Use Tension Bias Continuity interpolation.  Tension, bias, and continuity will be stored. </summary>
		TBC_KEY				= 3,

		/// <summary> For use only with rotation data.  Separate X, Y, and Z keys will be stored instead of using quaternions. </summary>
		XYZ_ROTATION_KEY	= 4,

		/// <summary> Step function. Used for visibility keys in NiBoolData. </summary>
		CONST_KEY			= 5,
	}

	/// <summary> Bethesda Havok. Material descriptor for a Havok shape in Oblivion. </summary>
	public enum OblivionHavokMaterial : uint
	{
		/// <summary> Stone </summary>
		OB_HAV_MAT_STONE				= 0,

		/// <summary> Cloth </summary>
		OB_HAV_MAT_CLOTH				= 1,

		/// <summary> Dirt </summary>
		OB_HAV_MAT_DIRT					= 2,

		/// <summary> Glass </summary>
		OB_HAV_MAT_GLASS				= 3,

		/// <summary> Grass </summary>
		OB_HAV_MAT_GRASS				= 4,

		/// <summary> Metal </summary>
		OB_HAV_MAT_METAL				= 5,

		/// <summary> Organic </summary>
		OB_HAV_MAT_ORGANIC				= 6,

		/// <summary> Skin </summary>
		OB_HAV_MAT_SKIN					= 7,

		/// <summary> Water </summary>
		OB_HAV_MAT_WATER				= 8,

		/// <summary> Wood </summary>
		OB_HAV_MAT_WOOD					= 9,

		/// <summary> Heavy Stone </summary>
		OB_HAV_MAT_HEAVY_STONE			= 10,

		/// <summary> Heavy Metal </summary>
		OB_HAV_MAT_HEAVY_METAL			= 11,

		/// <summary> Heavy Wood </summary>
		OB_HAV_MAT_HEAVY_WOOD			= 12,

		/// <summary> Chain </summary>
		OB_HAV_MAT_CHAIN				= 13,

		/// <summary> Snow </summary>
		OB_HAV_MAT_SNOW					= 14,

		/// <summary> Stone Stairs </summary>
		OB_HAV_MAT_STONE_STAIRS			= 15,

		/// <summary> Cloth Stairs </summary>
		OB_HAV_MAT_CLOTH_STAIRS			= 16,

		/// <summary> Dirt Stairs </summary>
		OB_HAV_MAT_DIRT_STAIRS			= 17,

		/// <summary> Glass Stairs </summary>
		OB_HAV_MAT_GLASS_STAIRS			= 18,

		/// <summary> Grass Stairs </summary>
		OB_HAV_MAT_GRASS_STAIRS			= 19,

		/// <summary> Metal Stairs </summary>
		OB_HAV_MAT_METAL_STAIRS			= 20,

		/// <summary> Organic Stairs </summary>
		OB_HAV_MAT_ORGANIC_STAIRS		= 21,

		/// <summary> Skin Stairs </summary>
		OB_HAV_MAT_SKIN_STAIRS			= 22,

		/// <summary> Water Stairs </summary>
		OB_HAV_MAT_WATER_STAIRS			= 23,

		/// <summary> Wood Stairs </summary>
		OB_HAV_MAT_WOOD_STAIRS			= 24,

		/// <summary> Heavy Stone Stairs </summary>
		OB_HAV_MAT_HEAVY_STONE_STAIRS	= 25,

		/// <summary> Heavy Metal Stairs </summary>
		OB_HAV_MAT_HEAVY_METAL_STAIRS	= 26,

		/// <summary> Heavy Wood Stairs </summary>
		OB_HAV_MAT_HEAVY_WOOD_STAIRS	= 27,

		/// <summary> Chain Stairs </summary>
		OB_HAV_MAT_CHAIN_STAIRS			= 28,

		/// <summary> Snow Stairs </summary>
		OB_HAV_MAT_SNOW_STAIRS			= 29,

		/// <summary> Elevator </summary>
		OB_HAV_MAT_ELEVATOR				= 30,

		/// <summary> Rubber </summary>
		OB_HAV_MAT_RUBBER				= 31,
	}

	/// <summary> Bethesda Havok. Material descriptor for a Havok shape in Fallout 3 and Fallout NV. </summary>
	public enum Fallout3HavokMaterial : uint
	{
		/// <summary> Stone </summary>
		FO_HAV_MAT_STONE								= 0,

		/// <summary> Cloth </summary>
		FO_HAV_MAT_CLOTH								= 1,

		/// <summary> Dirt </summary>
		FO_HAV_MAT_DIRT									= 2,

		/// <summary> Glass </summary>
		FO_HAV_MAT_GLASS								= 3,

		/// <summary> Grass </summary>
		FO_HAV_MAT_GRASS								= 4,

		/// <summary> Metal </summary>
		FO_HAV_MAT_METAL								= 5,

		/// <summary> Organic </summary>
		FO_HAV_MAT_ORGANIC								= 6,

		/// <summary> Skin </summary>
		FO_HAV_MAT_SKIN									= 7,

		/// <summary> Water </summary>
		FO_HAV_MAT_WATER								= 8,

		/// <summary> Wood </summary>
		FO_HAV_MAT_WOOD									= 9,

		/// <summary> Heavy Stone </summary>
		FO_HAV_MAT_HEAVY_STONE							= 10,

		/// <summary> Heavy Metal </summary>
		FO_HAV_MAT_HEAVY_METAL							= 11,

		/// <summary> Heavy Wood </summary>
		FO_HAV_MAT_HEAVY_WOOD							= 12,

		/// <summary> Chain </summary>
		FO_HAV_MAT_CHAIN								= 13,

		/// <summary> Bottlecap </summary>
		FO_HAV_MAT_BOTTLECAP							= 14,

		/// <summary> Elevator </summary>
		FO_HAV_MAT_ELEVATOR								= 15,

		/// <summary> Hollow Metal </summary>
		FO_HAV_MAT_HOLLOW_METAL							= 16,

		/// <summary> Sheet Metal </summary>
		FO_HAV_MAT_SHEET_METAL							= 17,

		/// <summary> Sand </summary>
		FO_HAV_MAT_SAND									= 18,

		/// <summary> Broken Concrete </summary>
		FO_HAV_MAT_BROKEN_CONCRETE						= 19,

		/// <summary> Vehicle Body </summary>
		FO_HAV_MAT_VEHICLE_BODY							= 20,

		/// <summary> Vehicle Part Solid </summary>
		FO_HAV_MAT_VEHICLE_PART_SOLID					= 21,

		/// <summary> Vehicle Part Hollow </summary>
		FO_HAV_MAT_VEHICLE_PART_HOLLOW					= 22,

		/// <summary> Barrel </summary>
		FO_HAV_MAT_BARREL								= 23,

		/// <summary> Bottle </summary>
		FO_HAV_MAT_BOTTLE								= 24,

		/// <summary> Soda Can </summary>
		FO_HAV_MAT_SODA_CAN								= 25,

		/// <summary> Pistol </summary>
		FO_HAV_MAT_PISTOL								= 26,

		/// <summary> Rifle </summary>
		FO_HAV_MAT_RIFLE								= 27,

		/// <summary> Shopping Cart </summary>
		FO_HAV_MAT_SHOPPING_CART						= 28,

		/// <summary> Lunchbox </summary>
		FO_HAV_MAT_LUNCHBOX								= 29,

		/// <summary> Baby Rattle </summary>
		FO_HAV_MAT_BABY_RATTLE							= 30,

		/// <summary> Rubber Ball </summary>
		FO_HAV_MAT_RUBBER_BALL							= 31,

		/// <summary> Stone </summary>
		FO_HAV_MAT_STONE_PLATFORM						= 32,

		/// <summary> Cloth </summary>
		FO_HAV_MAT_CLOTH_PLATFORM						= 33,

		/// <summary> Dirt </summary>
		FO_HAV_MAT_DIRT_PLATFORM						= 34,

		/// <summary> Glass </summary>
		FO_HAV_MAT_GLASS_PLATFORM						= 35,

		/// <summary> Grass </summary>
		FO_HAV_MAT_GRASS_PLATFORM						= 36,

		/// <summary> Metal </summary>
		FO_HAV_MAT_METAL_PLATFORM						= 37,

		/// <summary> Organic </summary>
		FO_HAV_MAT_ORGANIC_PLATFORM						= 38,

		/// <summary> Skin </summary>
		FO_HAV_MAT_SKIN_PLATFORM						= 39,

		/// <summary> Water </summary>
		FO_HAV_MAT_WATER_PLATFORM						= 40,

		/// <summary> Wood </summary>
		FO_HAV_MAT_WOOD_PLATFORM						= 41,

		/// <summary> Heavy Stone </summary>
		FO_HAV_MAT_HEAVY_STONE_PLATFORM					= 42,

		/// <summary> Heavy Metal </summary>
		FO_HAV_MAT_HEAVY_METAL_PLATFORM					= 43,

		/// <summary> Heavy Wood </summary>
		FO_HAV_MAT_HEAVY_WOOD_PLATFORM					= 44,

		/// <summary> Chain </summary>
		FO_HAV_MAT_CHAIN_PLATFORM						= 45,

		/// <summary> Bottlecap </summary>
		FO_HAV_MAT_BOTTLECAP_PLATFORM					= 46,

		/// <summary> Elevator </summary>
		FO_HAV_MAT_ELEVATOR_PLATFORM					= 47,

		/// <summary> Hollow Metal </summary>
		FO_HAV_MAT_HOLLOW_METAL_PLATFORM				= 48,

		/// <summary> Sheet Metal </summary>
		FO_HAV_MAT_SHEET_METAL_PLATFORM					= 49,

		/// <summary> Sand </summary>
		FO_HAV_MAT_SAND_PLATFORM						= 50,

		/// <summary> Broken Concrete </summary>
		FO_HAV_MAT_BROKEN_CONCRETE_PLATFORM				= 51,

		/// <summary> Vehicle Body </summary>
		FO_HAV_MAT_VEHICLE_BODY_PLATFORM				= 52,

		/// <summary> Vehicle Part Solid </summary>
		FO_HAV_MAT_VEHICLE_PART_SOLID_PLATFORM			= 53,

		/// <summary> Vehicle Part Hollow </summary>
		FO_HAV_MAT_VEHICLE_PART_HOLLOW_PLATFORM			= 54,

		/// <summary> Barrel </summary>
		FO_HAV_MAT_BARREL_PLATFORM						= 55,

		/// <summary> Bottle </summary>
		FO_HAV_MAT_BOTTLE_PLATFORM						= 56,

		/// <summary> Soda Can </summary>
		FO_HAV_MAT_SODA_CAN_PLATFORM					= 57,

		/// <summary> Pistol </summary>
		FO_HAV_MAT_PISTOL_PLATFORM						= 58,

		/// <summary> Rifle </summary>
		FO_HAV_MAT_RIFLE_PLATFORM						= 59,

		/// <summary> Shopping Cart </summary>
		FO_HAV_MAT_SHOPPING_CART_PLATFORM				= 60,

		/// <summary> Lunchbox </summary>
		FO_HAV_MAT_LUNCHBOX_PLATFORM					= 61,

		/// <summary> Baby Rattle </summary>
		FO_HAV_MAT_BABY_RATTLE_PLATFORM					= 62,

		/// <summary> Rubber Ball </summary>
		FO_HAV_MAT_RUBBER_BALL_PLATFORM					= 63,

		/// <summary> Stone </summary>
		FO_HAV_MAT_STONE_STAIRS							= 64,

		/// <summary> Cloth </summary>
		FO_HAV_MAT_CLOTH_STAIRS							= 65,

		/// <summary> Dirt </summary>
		FO_HAV_MAT_DIRT_STAIRS							= 66,

		/// <summary> Glass </summary>
		FO_HAV_MAT_GLASS_STAIRS							= 67,

		/// <summary> Grass </summary>
		FO_HAV_MAT_GRASS_STAIRS							= 68,

		/// <summary> Metal </summary>
		FO_HAV_MAT_METAL_STAIRS							= 69,

		/// <summary> Organic </summary>
		FO_HAV_MAT_ORGANIC_STAIRS						= 70,

		/// <summary> Skin </summary>
		FO_HAV_MAT_SKIN_STAIRS							= 71,

		/// <summary> Water </summary>
		FO_HAV_MAT_WATER_STAIRS							= 72,

		/// <summary> Wood </summary>
		FO_HAV_MAT_WOOD_STAIRS							= 73,

		/// <summary> Heavy Stone </summary>
		FO_HAV_MAT_HEAVY_STONE_STAIRS					= 74,

		/// <summary> Heavy Metal </summary>
		FO_HAV_MAT_HEAVY_METAL_STAIRS					= 75,

		/// <summary> Heavy Wood </summary>
		FO_HAV_MAT_HEAVY_WOOD_STAIRS					= 76,

		/// <summary> Chain </summary>
		FO_HAV_MAT_CHAIN_STAIRS							= 77,

		/// <summary> Bottlecap </summary>
		FO_HAV_MAT_BOTTLECAP_STAIRS						= 78,

		/// <summary> Elevator </summary>
		FO_HAV_MAT_ELEVATOR_STAIRS						= 79,

		/// <summary> Hollow Metal </summary>
		FO_HAV_MAT_HOLLOW_METAL_STAIRS					= 80,

		/// <summary> Sheet Metal </summary>
		FO_HAV_MAT_SHEET_METAL_STAIRS					= 81,

		/// <summary> Sand </summary>
		FO_HAV_MAT_SAND_STAIRS							= 82,

		/// <summary> Broken Concrete </summary>
		FO_HAV_MAT_BROKEN_CONCRETE_STAIRS				= 83,

		/// <summary> Vehicle Body </summary>
		FO_HAV_MAT_VEHICLE_BODY_STAIRS					= 84,

		/// <summary> Vehicle Part Solid </summary>
		FO_HAV_MAT_VEHICLE_PART_SOLID_STAIRS			= 85,

		/// <summary> Vehicle Part Hollow </summary>
		FO_HAV_MAT_VEHICLE_PART_HOLLOW_STAIRS			= 86,

		/// <summary> Barrel </summary>
		FO_HAV_MAT_BARREL_STAIRS						= 87,

		/// <summary> Bottle </summary>
		FO_HAV_MAT_BOTTLE_STAIRS						= 88,

		/// <summary> Soda Can </summary>
		FO_HAV_MAT_SODA_CAN_STAIRS						= 89,

		/// <summary> Pistol </summary>
		FO_HAV_MAT_PISTOL_STAIRS						= 90,

		/// <summary> Rifle </summary>
		FO_HAV_MAT_RIFLE_STAIRS							= 91,

		/// <summary> Shopping Cart </summary>
		FO_HAV_MAT_SHOPPING_CART_STAIRS					= 92,

		/// <summary> Lunchbox </summary>
		FO_HAV_MAT_LUNCHBOX_STAIRS						= 93,

		/// <summary> Baby Rattle </summary>
		FO_HAV_MAT_BABY_RATTLE_STAIRS					= 94,

		/// <summary> Rubber Ball </summary>
		FO_HAV_MAT_RUBBER_BALL_STAIRS					= 95,

		/// <summary> Stone </summary>
		FO_HAV_MAT_STONE_STAIRS_PLATFORM				= 96,

		/// <summary> Cloth </summary>
		FO_HAV_MAT_CLOTH_STAIRS_PLATFORM				= 97,

		/// <summary> Dirt </summary>
		FO_HAV_MAT_DIRT_STAIRS_PLATFORM					= 98,

		/// <summary> Glass </summary>
		FO_HAV_MAT_GLASS_STAIRS_PLATFORM				= 99,

		/// <summary> Grass </summary>
		FO_HAV_MAT_GRASS_STAIRS_PLATFORM				= 100,

		/// <summary> Metal </summary>
		FO_HAV_MAT_METAL_STAIRS_PLATFORM				= 101,

		/// <summary> Organic </summary>
		FO_HAV_MAT_ORGANIC_STAIRS_PLATFORM				= 102,

		/// <summary> Skin </summary>
		FO_HAV_MAT_SKIN_STAIRS_PLATFORM					= 103,

		/// <summary> Water </summary>
		FO_HAV_MAT_WATER_STAIRS_PLATFORM				= 104,

		/// <summary> Wood </summary>
		FO_HAV_MAT_WOOD_STAIRS_PLATFORM					= 105,

		/// <summary> Heavy Stone </summary>
		FO_HAV_MAT_HEAVY_STONE_STAIRS_PLATFORM			= 106,

		/// <summary> Heavy Metal </summary>
		FO_HAV_MAT_HEAVY_METAL_STAIRS_PLATFORM			= 107,

		/// <summary> Heavy Wood </summary>
		FO_HAV_MAT_HEAVY_WOOD_STAIRS_PLATFORM			= 108,

		/// <summary> Chain </summary>
		FO_HAV_MAT_CHAIN_STAIRS_PLATFORM				= 109,

		/// <summary> Bottlecap </summary>
		FO_HAV_MAT_BOTTLECAP_STAIRS_PLATFORM			= 110,

		/// <summary> Elevator </summary>
		FO_HAV_MAT_ELEVATOR_STAIRS_PLATFORM				= 111,

		/// <summary> Hollow Metal </summary>
		FO_HAV_MAT_HOLLOW_METAL_STAIRS_PLATFORM			= 112,

		/// <summary> Sheet Metal </summary>
		FO_HAV_MAT_SHEET_METAL_STAIRS_PLATFORM			= 113,

		/// <summary> Sand </summary>
		FO_HAV_MAT_SAND_STAIRS_PLATFORM					= 114,

		/// <summary> Broken Concrete </summary>
		FO_HAV_MAT_BROKEN_CONCRETE_STAIRS_PLATFORM		= 115,

		/// <summary> Vehicle Body </summary>
		FO_HAV_MAT_VEHICLE_BODY_STAIRS_PLATFORM			= 116,

		/// <summary> Vehicle Part Solid </summary>
		FO_HAV_MAT_VEHICLE_PART_SOLID_STAIRS_PLATFORM	= 117,

		/// <summary> Vehicle Part Hollow </summary>
		FO_HAV_MAT_VEHICLE_PART_HOLLOW_STAIRS_PLATFORM	= 118,

		/// <summary> Barrel </summary>
		FO_HAV_MAT_BARREL_STAIRS_PLATFORM				= 119,

		/// <summary> Bottle </summary>
		FO_HAV_MAT_BOTTLE_STAIRS_PLATFORM				= 120,

		/// <summary> Soda Can </summary>
		FO_HAV_MAT_SODA_CAN_STAIRS_PLATFORM				= 121,

		/// <summary> Pistol </summary>
		FO_HAV_MAT_PISTOL_STAIRS_PLATFORM				= 122,

		/// <summary> Rifle </summary>
		FO_HAV_MAT_RIFLE_STAIRS_PLATFORM				= 123,

		/// <summary> Shopping Cart </summary>
		FO_HAV_MAT_SHOPPING_CART_STAIRS_PLATFORM		= 124,

		/// <summary> Lunchbox </summary>
		FO_HAV_MAT_LUNCHBOX_STAIRS_PLATFORM				= 125,

		/// <summary> Baby Rattle </summary>
		FO_HAV_MAT_BABY_RATTLE_STAIRS_PLATFORM			= 126,

		/// <summary> Rubber Ball </summary>
		FO_HAV_MAT_RUBBER_BALL_STAIRS_PLATFORM			= 127,
	}

	/// <summary> Bethesda Havok. Material descriptor for a Havok shape in Skyrim. </summary>
	public enum SkyrimHavokMaterial : uint
	{
		/// <summary> Broken Stone </summary>
		SKY_HAV_MAT_BROKEN_STONE				= 131151687,

		/// <summary> Light Wood </summary>
		SKY_HAV_MAT_LIGHT_WOOD					= 365420259,

		/// <summary> Snow </summary>
		SKY_HAV_MAT_SNOW						= 398949039,

		/// <summary> Gravel </summary>
		SKY_HAV_MAT_GRAVEL						= 428587608,

		/// <summary> Material Chain Metal </summary>
		SKY_HAV_MAT_MATERIAL_CHAIN_METAL		= 438912228,

		/// <summary> Bottle </summary>
		SKY_HAV_MAT_BOTTLE						= 493553910,

		/// <summary> Wood </summary>
		SKY_HAV_MAT_WOOD						= 500811281,

		/// <summary> Skin </summary>
		SKY_HAV_MAT_SKIN						= 591247106,

		/// <summary> Unknown in Creation Kit v1.9.32.0. Found in Dawnguard DLC in meshes\dlc01\clutter\dlc01deerskin.nif. </summary>
		SKY_HAV_MAT_UNKNOWN_617099282			= 617099282,

		/// <summary> Barrel </summary>
		SKY_HAV_MAT_BARREL						= 732141076,

		/// <summary> Material Ceramic Medium </summary>
		SKY_HAV_MAT_MATERIAL_CERAMIC_MEDIUM		= 781661019,

		/// <summary> Material Basket </summary>
		SKY_HAV_MAT_MATERIAL_BASKET				= 790784366,

		/// <summary> Ice </summary>
		SKY_HAV_MAT_ICE							= 873356572,

		/// <summary> Stairs Stone </summary>
		SKY_HAV_MAT_STAIRS_STONE				= 899511101,

		/// <summary> Water </summary>
		SKY_HAV_MAT_WATER						= 1024582599,

		/// <summary> Unknown in Creation Kit v1.6.89.0. Found in actors\draugr\character assets\skeletons.nif. </summary>
		SKY_HAV_MAT_UNKNOWN_1028101969			= 1028101969,

		/// <summary> Material Blade 1 Hand </summary>
		SKY_HAV_MAT_MATERIAL_BLADE_1HAND		= 1060167844,

		/// <summary> Material Book </summary>
		SKY_HAV_MAT_MATERIAL_BOOK				= 1264672850,

		/// <summary> Material Carpet </summary>
		SKY_HAV_MAT_MATERIAL_CARPET				= 1286705471,

		/// <summary> Solid Metal </summary>
		SKY_HAV_MAT_SOLID_METAL					= 1288358971,

		/// <summary> Material Axe 1Hand </summary>
		SKY_HAV_MAT_MATERIAL_AXE_1HAND			= 1305674443,

		/// <summary> Unknown in Creation Kit v1.6.89.0. Found in armor\draugr\draugrbootsfemale_go.nif or armor\amuletsandrings\amuletgnd.nif. </summary>
		SKY_HAV_MAT_UNKNOWN_1440721808			= 1440721808,

		/// <summary> Stairs Wood </summary>
		SKY_HAV_MAT_STAIRS_WOOD					= 1461712277,

		/// <summary> Mud </summary>
		SKY_HAV_MAT_MUD							= 1486385281,

		/// <summary> Material Boulder Small </summary>
		SKY_HAV_MAT_MATERIAL_BOULDER_SMALL		= 1550912982,

		/// <summary> Stairs Snow </summary>
		SKY_HAV_MAT_STAIRS_SNOW					= 1560365355,

		/// <summary> Heavy Stone </summary>
		SKY_HAV_MAT_HEAVY_STONE					= 1570821952,

		/// <summary> Unknown in Creation Kit v1.6.89.0. Found in actors\dragon\character assets\skeleton.nif. </summary>
		SKY_HAV_MAT_UNKNOWN_1574477864			= 1574477864,

		/// <summary> Unknown in Creation Kit v1.6.89.0. Found in trap objects or clutter\displaycases\displaycaselgangled01.nif or actors\deer\character assets\skeleton.nif. </summary>
		SKY_HAV_MAT_UNKNOWN_1591009235			= 1591009235,

		/// <summary> Material Bows Staves </summary>
		SKY_HAV_MAT_MATERIAL_BOWS_STAVES		= 1607128641,

		/// <summary> Material Wood As Stairs </summary>
		SKY_HAV_MAT_MATERIAL_WOOD_AS_STAIRS		= 1803571212,

		/// <summary> Grass </summary>
		SKY_HAV_MAT_GRASS						= 1848600814,

		/// <summary> Material Boulder Large </summary>
		SKY_HAV_MAT_MATERIAL_BOULDER_LARGE		= 1885326971,

		/// <summary> Material Stone As Stairs </summary>
		SKY_HAV_MAT_MATERIAL_STONE_AS_STAIRS	= 1886078335,

		/// <summary> Material Blade 2Hand </summary>
		SKY_HAV_MAT_MATERIAL_BLADE_2HAND		= 2022742644,

		/// <summary> Material Bottle Small </summary>
		SKY_HAV_MAT_MATERIAL_BOTTLE_SMALL		= 2025794648,

		/// <summary> Sand </summary>
		SKY_HAV_MAT_SAND						= 2168343821,

		/// <summary> Heavy Metal </summary>
		SKY_HAV_MAT_HEAVY_METAL					= 2229413539,

		/// <summary> Unknown in Creation Kit v1.9.32.0. Found in Dawnguard DLC in meshes\dlc01\clutter\dlc01sabrecatpelt.nif. </summary>
		SKY_HAV_MAT_UNKNOWN_2290050264			= 2290050264,

		/// <summary> Dragon </summary>
		SKY_HAV_MAT_DRAGON						= 2518321175,

		/// <summary> Material Blade 1Hand Small </summary>
		SKY_HAV_MAT_MATERIAL_BLADE_1HAND_SMALL	= 2617944780,

		/// <summary> Material Skin Small </summary>
		SKY_HAV_MAT_MATERIAL_SKIN_SMALL			= 2632367422,

		/// <summary> Stairs Broken Stone </summary>
		SKY_HAV_MAT_STAIRS_BROKEN_STONE			= 2892392795,

		/// <summary> Material Skin Large </summary>
		SKY_HAV_MAT_MATERIAL_SKIN_LARGE			= 2965929619,

		/// <summary> Organic </summary>
		SKY_HAV_MAT_ORGANIC						= 2974920155,

		/// <summary> Material Bone </summary>
		SKY_HAV_MAT_MATERIAL_BONE				= 3049421844,

		/// <summary> Heavy Wood </summary>
		SKY_HAV_MAT_HEAVY_WOOD					= 3070783559,

		/// <summary> Material Chain </summary>
		SKY_HAV_MAT_MATERIAL_CHAIN				= 3074114406,

		/// <summary> Dirt </summary>
		SKY_HAV_MAT_DIRT						= 3106094762,

		/// <summary> Material Armor Light </summary>
		SKY_HAV_MAT_MATERIAL_ARMOR_LIGHT		= 3424720541,

		/// <summary> Material Shield Light </summary>
		SKY_HAV_MAT_MATERIAL_SHIELD_LIGHT		= 3448167928,

		/// <summary> Material Coin </summary>
		SKY_HAV_MAT_MATERIAL_COIN				= 3589100606,

		/// <summary> Material Shield Heavy </summary>
		SKY_HAV_MAT_MATERIAL_SHIELD_HEAVY		= 3702389584,

		/// <summary> Material Armor Heavy </summary>
		SKY_HAV_MAT_MATERIAL_ARMOR_HEAVY		= 3708432437,

		/// <summary> Material Arrow </summary>
		SKY_HAV_MAT_MATERIAL_ARROW				= 3725505938,

		/// <summary> Glass </summary>
		SKY_HAV_MAT_GLASS						= 3739830338,

		/// <summary> Stone </summary>
		SKY_HAV_MAT_STONE						= 3741512247,

		/// <summary> Cloth </summary>
		SKY_HAV_MAT_CLOTH						= 3839073443,

		/// <summary> Material Blunt 2Hand </summary>
		SKY_HAV_MAT_MATERIAL_BLUNT_2HAND		= 3969592277,

		/// <summary> Unknown in Creation Kit v1.9.32.0. Found in Dawnguard DLC in meshes\dlc01\prototype\dlc1protoswingingbridge.nif. </summary>
		SKY_HAV_MAT_UNKNOWN_4239621792			= 4239621792,

		/// <summary> Material Boulder Medium </summary>
		SKY_HAV_MAT_MATERIAL_BOULDER_MEDIUM		= 4283869410,
	}

	/// <summary> Bethesda Havok. Describes the collision layer a body belongs to in Oblivion. </summary>
	public enum OblivionLayer : byte
	{
		/// <summary> Unidentified (white) </summary>
		OL_UNIDENTIFIED		= 0,

		/// <summary> Static (red) </summary>
		OL_STATIC			= 1,

		/// <summary> AnimStatic (magenta) </summary>
		OL_ANIM_STATIC		= 2,

		/// <summary> Transparent (light pink) </summary>
		OL_TRANSPARENT		= 3,

		/// <summary> Clutter (light blue) </summary>
		OL_CLUTTER			= 4,

		/// <summary> Weapon (orange) </summary>
		OL_WEAPON			= 5,

		/// <summary> Projectile (light orange) </summary>
		OL_PROJECTILE		= 6,

		/// <summary> Spell (cyan) </summary>
		OL_SPELL			= 7,

		/// <summary> Biped (green) Seems to apply to all creatures/NPCs </summary>
		OL_BIPED			= 8,

		/// <summary> Trees (light brown) </summary>
		OL_TREES			= 9,

		/// <summary> Props (magenta) </summary>
		OL_PROPS			= 10,

		/// <summary> Water (cyan) </summary>
		OL_WATER			= 11,

		/// <summary> Trigger (light grey) </summary>
		OL_TRIGGER			= 12,

		/// <summary> Terrain (light yellow) </summary>
		OL_TERRAIN			= 13,

		/// <summary> Trap (light grey) </summary>
		OL_TRAP				= 14,

		/// <summary> NonCollidable (white) </summary>
		OL_NONCOLLIDABLE	= 15,

		/// <summary> CloudTrap (greenish grey) </summary>
		OL_CLOUD_TRAP		= 16,

		/// <summary> Ground (none) </summary>
		OL_GROUND			= 17,

		/// <summary> Portal (green) </summary>
		OL_PORTAL			= 18,

		/// <summary> Stairs (white) </summary>
		OL_STAIRS			= 19,

		/// <summary> CharController (yellow) </summary>
		OL_CHAR_CONTROLLER	= 20,

		/// <summary> AvoidBox (dark yellow) </summary>
		OL_AVOID_BOX		= 21,

		/// <summary> ? (white) </summary>
		OL_UNKNOWN1			= 22,

		/// <summary> ? (white) </summary>
		OL_UNKNOWN2			= 23,

		/// <summary> CameraPick (white) </summary>
		OL_CAMERA_PICK		= 24,

		/// <summary> ItemPick (white) </summary>
		OL_ITEM_PICK		= 25,

		/// <summary> LineOfSight (white) </summary>
		OL_LINE_OF_SIGHT	= 26,

		/// <summary> PathPick (white) </summary>
		OL_PATH_PICK		= 27,

		/// <summary> CustomPick1 (white) </summary>
		OL_CUSTOM_PICK_1	= 28,

		/// <summary> CustomPick2 (white) </summary>
		OL_CUSTOM_PICK_2	= 29,

		/// <summary> SpellExplosion (white) </summary>
		OL_SPELL_EXPLOSION	= 30,

		/// <summary> DroppingPick (white) </summary>
		OL_DROPPING_PICK	= 31,

		/// <summary> Other (white) </summary>
		OL_OTHER			= 32,

		/// <summary> Head </summary>
		OL_HEAD				= 33,

		/// <summary> Body </summary>
		OL_BODY				= 34,

		/// <summary> Spine1 </summary>
		OL_SPINE1			= 35,

		/// <summary> Spine2 </summary>
		OL_SPINE2			= 36,

		/// <summary> LUpperArm </summary>
		OL_L_UPPER_ARM		= 37,

		/// <summary> LForeArm </summary>
		OL_L_FOREARM		= 38,

		/// <summary> LHand </summary>
		OL_L_HAND			= 39,

		/// <summary> LThigh </summary>
		OL_L_THIGH			= 40,

		/// <summary> LCalf </summary>
		OL_L_CALF			= 41,

		/// <summary> LFoot </summary>
		OL_L_FOOT			= 42,

		/// <summary> RUpperArm </summary>
		OL_R_UPPER_ARM		= 43,

		/// <summary> RForeArm </summary>
		OL_R_FOREARM		= 44,

		/// <summary> RHand </summary>
		OL_R_HAND			= 45,

		/// <summary> RThigh </summary>
		OL_R_THIGH			= 46,

		/// <summary> RCalf </summary>
		OL_R_CALF			= 47,

		/// <summary> RFoot </summary>
		OL_R_FOOT			= 48,

		/// <summary> Tail </summary>
		OL_TAIL				= 49,

		/// <summary> SideWeapon </summary>
		OL_SIDE_WEAPON		= 50,

		/// <summary> Shield </summary>
		OL_SHIELD			= 51,

		/// <summary> Quiver </summary>
		OL_QUIVER			= 52,

		/// <summary> BackWeapon </summary>
		OL_BACK_WEAPON		= 53,

		/// <summary> BackWeapon (?) </summary>
		OL_BACK_WEAPON2		= 54,

		/// <summary> PonyTail </summary>
		OL_PONYTAIL			= 55,

		/// <summary> Wing </summary>
		OL_WING				= 56,

		/// <summary> Null </summary>
		OL_NULL				= 57,
	}

	/// <summary> Bethesda Havok. Describes the collision layer a body belongs to in Fallout 3 and Fallout NV. </summary>
	public enum Fallout3Layer : byte
	{
		/// <summary> Unidentified (white) </summary>
		FOL_UNIDENTIFIED			= 0,

		/// <summary> Static (red) </summary>
		FOL_STATIC					= 1,

		/// <summary> AnimStatic (magenta) </summary>
		FOL_ANIM_STATIC				= 2,

		/// <summary> Transparent (light pink) </summary>
		FOL_TRANSPARENT				= 3,

		/// <summary> Clutter (light blue) </summary>
		FOL_CLUTTER					= 4,

		/// <summary> Weapon (orange) </summary>
		FOL_WEAPON					= 5,

		/// <summary> Projectile (light orange) </summary>
		FOL_PROJECTILE				= 6,

		/// <summary> Spell (cyan) </summary>
		FOL_SPELL					= 7,

		/// <summary> Biped (green) Seems to apply to all creatures/NPCs </summary>
		FOL_BIPED					= 8,

		/// <summary> Trees (light brown) </summary>
		FOL_TREES					= 9,

		/// <summary> Props (magenta) </summary>
		FOL_PROPS					= 10,

		/// <summary> Water (cyan) </summary>
		FOL_WATER					= 11,

		/// <summary> Trigger (light grey) </summary>
		FOL_TRIGGER					= 12,

		/// <summary> Terrain (light yellow) </summary>
		FOL_TERRAIN					= 13,

		/// <summary> Trap (light grey) </summary>
		FOL_TRAP					= 14,

		/// <summary> NonCollidable (white) </summary>
		FOL_NONCOLLIDABLE			= 15,

		/// <summary> CloudTrap (greenish grey) </summary>
		FOL_CLOUD_TRAP				= 16,

		/// <summary> Ground (none) </summary>
		FOL_GROUND					= 17,

		/// <summary> Portal (green) </summary>
		FOL_PORTAL					= 18,

		/// <summary> DebrisSmall (white) </summary>
		FOL_DEBRIS_SMALL			= 19,

		/// <summary> DebrisLarge (white) </summary>
		FOL_DEBRIS_LARGE			= 20,

		/// <summary> AcousticSpace (white) </summary>
		FOL_ACOUSTIC_SPACE			= 21,

		/// <summary> Actorzone (white) </summary>
		FOL_ACTORZONE				= 22,

		/// <summary> Projectilezone (white) </summary>
		FOL_PROJECTILEZONE			= 23,

		/// <summary> GasTrap (yellowish green) </summary>
		FOL_GASTRAP					= 24,

		/// <summary> ShellCasing (white) </summary>
		FOL_SHELLCASING				= 25,

		/// <summary> TransparentSmall (white) </summary>
		FOL_TRANSPARENT_SMALL		= 26,

		/// <summary> InvisibleWall (white) </summary>
		FOL_INVISIBLE_WALL			= 27,

		/// <summary> TransparentSmallAnim (white) </summary>
		FOL_TRANSPARENT_SMALL_ANIM	= 28,

		/// <summary> Dead Biped (green) </summary>
		FOL_DEADBIP					= 29,

		/// <summary> CharController (yellow) </summary>
		FOL_CHARCONTROLLER			= 30,

		/// <summary> Avoidbox (orange) </summary>
		FOL_AVOIDBOX				= 31,

		/// <summary> Collisionbox (white) </summary>
		FOL_COLLISIONBOX			= 32,

		/// <summary> Camerasphere (white) </summary>
		FOL_CAMERASPHERE			= 33,

		/// <summary> Doordetection (white) </summary>
		FOL_DOORDETECTION			= 34,

		/// <summary> Camerapick (white) </summary>
		FOL_CAMERAPICK				= 35,

		/// <summary> Itempick (white) </summary>
		FOL_ITEMPICK				= 36,

		/// <summary> LineOfSight (white) </summary>
		FOL_LINEOFSIGHT				= 37,

		/// <summary> Pathpick (white) </summary>
		FOL_PATHPICK				= 38,

		/// <summary> Custompick1 (white) </summary>
		FOL_CUSTOMPICK1				= 39,

		/// <summary> Custompick2 (white) </summary>
		FOL_CUSTOMPICK2				= 40,

		/// <summary> SpellExplosion (white) </summary>
		FOL_SPELLEXPLOSION			= 41,

		/// <summary> Droppingpick (white) </summary>
		FOL_DROPPINGPICK			= 42,

		/// <summary> Null (white) </summary>
		FOL_NULL					= 43,
	}

	/// <summary> Bethesda Havok. Describes the collision layer a body belongs to in Skyrim. </summary>
	public enum SkyrimLayer : byte
	{
		/// <summary> Unidentified </summary>
		SKYL_UNIDENTIFIED			= 0,

		/// <summary> Static </summary>
		SKYL_STATIC					= 1,

		/// <summary> Anim Static </summary>
		SKYL_ANIMSTATIC				= 2,

		/// <summary> Transparent </summary>
		SKYL_TRANSPARENT			= 3,

		/// <summary> Clutter. Object with this layer will float on water surface. </summary>
		SKYL_CLUTTER				= 4,

		/// <summary> Weapon </summary>
		SKYL_WEAPON					= 5,

		/// <summary> Projectile </summary>
		SKYL_PROJECTILE				= 6,

		/// <summary> Spell </summary>
		SKYL_SPELL					= 7,

		/// <summary> Biped. Seems to apply to all creatures/NPCs </summary>
		SKYL_BIPED					= 8,

		/// <summary> Trees </summary>
		SKYL_TREES					= 9,

		/// <summary> Props </summary>
		SKYL_PROPS					= 10,

		/// <summary> Water </summary>
		SKYL_WATER					= 11,

		/// <summary> Trigger </summary>
		SKYL_TRIGGER				= 12,

		/// <summary> Terrain </summary>
		SKYL_TERRAIN				= 13,

		/// <summary> Trap </summary>
		SKYL_TRAP					= 14,

		/// <summary> NonCollidable </summary>
		SKYL_NONCOLLIDABLE			= 15,

		/// <summary> CloudTrap </summary>
		SKYL_CLOUD_TRAP				= 16,

		/// <summary> Ground. It seems that produces no sound when collide. </summary>
		SKYL_GROUND					= 17,

		/// <summary> Portal </summary>
		SKYL_PORTAL					= 18,

		/// <summary> Debris Small </summary>
		SKYL_DEBRIS_SMALL			= 19,

		/// <summary> Debris Large </summary>
		SKYL_DEBRIS_LARGE			= 20,

		/// <summary> Acoustic Space </summary>
		SKYL_ACOUSTIC_SPACE			= 21,

		/// <summary> Actor Zone </summary>
		SKYL_ACTORZONE				= 22,

		/// <summary> Projectile Zone </summary>
		SKYL_PROJECTILEZONE			= 23,

		/// <summary> Gas Trap </summary>
		SKYL_GASTRAP				= 24,

		/// <summary> Shell Casing </summary>
		SKYL_SHELLCASING			= 25,

		/// <summary> Transparent Small </summary>
		SKYL_TRANSPARENT_SMALL		= 26,

		/// <summary> Invisible Wall </summary>
		SKYL_INVISIBLE_WALL			= 27,

		/// <summary> Transparent Small Anim </summary>
		SKYL_TRANSPARENT_SMALL_ANIM	= 28,

		/// <summary> Ward </summary>
		SKYL_WARD					= 29,

		/// <summary> Char Controller </summary>
		SKYL_CHARCONTROLLER			= 30,

		/// <summary> Stair Helper </summary>
		SKYL_STAIRHELPER			= 31,

		/// <summary> Dead Bip </summary>
		SKYL_DEADBIP				= 32,

		/// <summary> Biped No CC </summary>
		SKYL_BIPED_NO_CC			= 33,

		/// <summary> Avoid Box </summary>
		SKYL_AVOIDBOX				= 34,

		/// <summary> Collision Box </summary>
		SKYL_COLLISIONBOX			= 35,

		/// <summary> Camera Sphere </summary>
		SKYL_CAMERASHPERE			= 36,

		/// <summary> Door Detection </summary>
		SKYL_DOORDETECTION			= 37,

		/// <summary> Cone Projectile </summary>
		SKYL_CONEPROJECTILE			= 38,

		/// <summary> Camera Pick </summary>
		SKYL_CAMERAPICK				= 39,

		/// <summary> Item Pick </summary>
		SKYL_ITEMPICK				= 40,

		/// <summary> Line of Sight </summary>
		SKYL_LINEOFSIGHT			= 41,

		/// <summary> Path Pick </summary>
		SKYL_PATHPICK				= 42,

		/// <summary> Custom Pick 1 </summary>
		SKYL_CUSTOMPICK1			= 43,

		/// <summary> Custom Pick 2 </summary>
		SKYL_CUSTOMPICK2			= 44,

		/// <summary> Spell Explosion </summary>
		SKYL_SPELLEXPLOSION			= 45,

		/// <summary> Dropping Pick </summary>
		SKYL_DROPPINGPICK			= 46,

		/// <summary> Null </summary>
		SKYL_NULL					= 47,
	}

	/// <summary> Bethesda Havok. A byte describing if MOPP Data is organized into chunks (PS3) or not (PC) </summary>
	public enum MoppDataBuildType : byte
	{
		/// <summary> Organized in chunks for PS3. </summary>
		BUILT_WITH_CHUNK_SUBDIVISION	= 0,

		/// <summary> Not organized in chunks for PC. (Default) </summary>
		BUILT_WITHOUT_CHUNK_SUBDIVISION	= 1,

		/// <summary> Build type not set yet. </summary>
		BUILD_NOT_SET					= 2,
	}

	/// <summary> Target platform for NiPersistentSrcTextureRendererData (later than 30.1). </summary>
	public enum PlatformID : uint
	{
		ANY		= 0,
		XENON	= 1,
		PS3		= 2,
		DX9		= 3,
		WII		= 4,
		D3D10	= 5,
	}

	/// <summary> Target renderer for NiPersistentSrcTextureRendererData (until 30.1). </summary>
	public enum RendererID : uint
	{
		XBOX360	= 0,
		PS3		= 1,
		DX9		= 2,
		D3D10	= 3,
		WII		= 4,
		GENERIC	= 5,
		D3D11	= 6,
	}

	/// <summary> Describes the pixel format used by the NiPixelData object to store a texture. </summary>
	public enum PixelFormat : uint
	{
		/// <summary> 24-bit RGB. 8 bits per red, blue, and green component. </summary>
		FMT_RGB				= 0,

		/// <summary> 32-bit RGB with alpha. 8 bits per red, blue, green, and alpha component. </summary>
		FMT_RGBA			= 1,

		/// <summary> 8-bit palette index. </summary>
		FMT_PAL				= 2,

		/// <summary> 8-bit palette index with alpha. </summary>
		FMT_PALA			= 3,

		/// <summary> DXT1 compressed texture. </summary>
		FMT_DXT1			= 4,

		/// <summary> DXT3 compressed texture. </summary>
		FMT_DXT3			= 5,

		/// <summary> DXT5 compressed texture. </summary>
		FMT_DXT5			= 6,

		/// <summary> (Deprecated) 24-bit noninterleaved texture, an old PS2 format. </summary>
		FMT_RGB24NONINT		= 7,

		/// <summary> Uncompressed dU/dV gradient bump map. </summary>
		FMT_BUMP			= 8,

		/// <summary> Uncompressed dU/dV gradient bump map with luma channel representing shininess. </summary>
		FMT_BUMPLUMA		= 9,

		/// <summary> Generic descriptor for any renderer-specific format not described by other formats. </summary>
		FMT_RENDERSPEC		= 10,

		/// <summary> Generic descriptor for formats with 1 component. </summary>
		FMT_1CH				= 11,

		/// <summary> Generic descriptor for formats with 2 components. </summary>
		FMT_2CH				= 12,

		/// <summary> Generic descriptor for formats with 3 components. </summary>
		FMT_3CH				= 13,

		/// <summary> Generic descriptor for formats with 4 components. </summary>
		FMT_4CH				= 14,

		/// <summary> Indicates the NiPixelFormat is meant to be used on a depth/stencil surface. </summary>
		FMT_DEPTH_STENCIL	= 15,

		/// <summary>  </summary>
		FMT_UNKNOWN			= 16,
	}

	/// <summary> Describes whether pixels have been tiled from their standard row-major format to a format optimized for a particular platform. </summary>
	public enum PixelTiling : uint
	{
		TILE_NONE			= 0,
		TILE_XENON			= 1,
		TILE_WII			= 2,
		TILE_NV_SWIZZLED	= 3,
	}

	/// <summary> Describes the pixel format used by the NiPixelData object to store a texture. </summary>
	public enum PixelComponent : uint
	{
		COMP_RED		= 0,
		COMP_GREEN		= 1,
		COMP_BLUE		= 2,
		COMP_ALPHA		= 3,
		COMP_COMPRESSED	= 4,
		COMP_OFFSET_U	= 5,
		COMP_OFFSET_V	= 6,
		COMP_OFFSET_W	= 7,
		COMP_OFFSET_Q	= 8,
		COMP_LUMA		= 9,
		COMP_HEIGHT		= 10,
		COMP_VECTOR_X	= 11,
		COMP_VECTOR_Y	= 12,
		COMP_VECTOR_Z	= 13,
		COMP_PADDING	= 14,
		COMP_INTENSITY	= 15,
		COMP_INDEX		= 16,
		COMP_DEPTH		= 17,
		COMP_STENCIL	= 18,
		COMP_EMPTY		= 19,
	}

	/// <summary> Describes how each pixel should be accessed on NiPixelFormat. </summary>
	public enum PixelRepresentation : uint
	{
		REP_NORM_INT	= 0,
		REP_HALF		= 1,
		REP_FLOAT		= 2,
		REP_INDEX		= 3,
		REP_COMPRESSED	= 4,
		REP_UNKNOWN		= 5,
		REP_INT			= 6,
	}

	/// <summary> Describes the color depth in an NiTexture. </summary>
	public enum PixelLayout : uint
	{
		/// <summary> Texture is in 8-bit palettized format. </summary>
		LAY_PALETTIZED_8	= 0,

		/// <summary> Texture is in 16-bit high color format. </summary>
		LAY_HIGH_COLOR_16	= 1,

		/// <summary> Texture is in 32-bit true color format. </summary>
		LAY_TRUE_COLOR_32	= 2,

		/// <summary> Texture is compressed. </summary>
		LAY_COMPRESSED		= 3,

		/// <summary> Texture is a grayscale bump map. </summary>
		LAY_BUMPMAP			= 4,

		/// <summary> Texture is in 4-bit palettized format. </summary>
		LAY_PALETTIZED_4	= 5,

		/// <summary> Use default setting. </summary>
		LAY_DEFAULT			= 6,

		LAY_SINGLE_COLOR_8	= 7,
		LAY_SINGLE_COLOR_16	= 8,
		LAY_SINGLE_COLOR_32	= 9,
		LAY_DOUBLE_COLOR_32	= 10,
		LAY_DOUBLE_COLOR_64	= 11,
		LAY_FLOAT_COLOR_32	= 12,
		LAY_FLOAT_COLOR_64	= 13,
		LAY_FLOAT_COLOR_128	= 14,
		LAY_SINGLE_COLOR_4	= 15,
		LAY_DEPTH_24_X8		= 16,
	}

	/// <summary> Describes how mipmaps are handled in an NiTexture. </summary>
	public enum MipMapFormat : uint
	{
		/// <summary> Texture does not use mip maps. </summary>
		MIP_FMT_NO		= 0,

		/// <summary> Texture uses mip maps. </summary>
		MIP_FMT_YES		= 1,

		/// <summary> Use default setting. </summary>
		MIP_FMT_DEFAULT	= 2,
	}

	/// <summary> Describes how transparency is handled in an NiTexture. </summary>
	public enum AlphaFormat : uint
	{
		/// <summary> No alpha. </summary>
		ALPHA_NONE		= 0,

		/// <summary> 1-bit alpha. </summary>
		ALPHA_BINARY	= 1,

		/// <summary> Interpolated 4- or 8-bit alpha. </summary>
		ALPHA_SMOOTH	= 2,

		/// <summary> Use default setting. </summary>
		ALPHA_DEFAULT	= 3,
	}

	/// <summary> Describes the availiable texture clamp modes, i.e. the behavior of UV mapping outside the [0,1] range. </summary>
	public enum TexClampMode : uint
	{
		/// <summary> Clamp in both directions. </summary>
		CLAMP_S_CLAMP_T	= 0,

		/// <summary> Clamp in the S(U) direction but wrap in the T(V) direction. </summary>
		CLAMP_S_WRAP_T	= 1,

		/// <summary> Wrap in the S(U) direction but clamp in the T(V) direction. </summary>
		WRAP_S_CLAMP_T	= 2,

		/// <summary> Wrap in both directions. </summary>
		WRAP_S_WRAP_T	= 3,
	}

	/// <summary> Describes the availiable texture filter modes, i.e. the way the pixels in a texture are displayed on screen. </summary>
	public enum TexFilterMode : uint
	{
		/// <summary> Nearest neighbor. Uses nearest texel with no mipmapping. </summary>
		FILTER_NEAREST				= 0,

		/// <summary> Bilinear. Linear interpolation with no mipmapping. </summary>
		FILTER_BILERP				= 1,

		/// <summary> Trilinear. Linear intepolation between 8 texels (4 nearest texels between 2 nearest mip levels). </summary>
		FILTER_TRILERP				= 2,

		/// <summary> Nearest texel on nearest mip level. </summary>
		FILTER_NEAREST_MIPNEAREST	= 3,

		/// <summary> Linear interpolates nearest texel between two nearest mip levels. </summary>
		FILTER_NEAREST_MIPLERP		= 4,

		/// <summary> Linear interpolates on nearest mip level. </summary>
		FILTER_BILERP_MIPNEAREST	= 5,

		/// <summary> Anisotropic filtering. One or many trilinear samples depending on anisotropy. </summary>
		FILTER_ANISOTROPIC			= 6,
	}

	/// <summary> Describes how to apply vertex colors for NiVertexColorProperty. </summary>
	public enum VertMode : uint
	{
		/// <summary> Emissive, ambient, and diffuse colors are all specified by the NiMaterialProperty. </summary>
		VERT_MODE_SRC_IGNORE	= 0,

		/// <summary> Emissive colors are specified by the source vertex colors. Ambient+Diffuse are specified by the NiMaterialProperty. </summary>
		VERT_MODE_SRC_EMISSIVE	= 1,

		/// <summary> Ambient+Diffuse colors are specified by the source vertex colors. Emissive is specified by the NiMaterialProperty. (Default) </summary>
		VERT_MODE_SRC_AMB_DIF	= 2,
	}


}
