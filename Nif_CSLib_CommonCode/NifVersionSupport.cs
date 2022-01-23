// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

namespace Nif_CSLib_CommonCode
{
	/// <summary>
	/// Class used to hold the various recognised NIF versions and indicate whether reading them is currently supported.
	/// </summary>
	public struct NifVersionSupport
	{
		/// <summary>
		/// Test the current NIF version info against a list of known NIF versions to see if reading it is supported.
		/// </summary>
		/// <param name="_NifIdentifier_">String you can use to identify the NIF in error messages (e.g. the path to the NIF file).</param>
		/// <param name="_NifVersion_">NIF's Version</param>
		/// <param name="_UserVersion_">NIF's User Version</param>
		/// <param name="_BsVersion_">NIF's BS Version</param>
		/// <param name="_Error_">Supply a string that will be used to return any errors that occurred while reading the header.</param>
		/// <returns>True if reading the supplied NIF version is supported. False if it is not.</returns>
		public static bool _Test(in string _NifIdentifier_, in uint _NifVersion_, in uint _UserVersion_,
			in uint _BsVersion_, ref string _Error_)
		{
			// This list of checks comes from the long list of <version> tags at the start of the NIFxml
			switch (_NifVersion_)
			{
				// List of recognised versions below. Comments next to each
				// Case or If indicate the game(s) which are known to use that version.
				// Double braces around a game name indicate that this is the primary version used by it.

				case 0x02030000: // 2.3 - Dark Age of Camelot
					_Error_ += $"Error reading {_NifIdentifier_}. NIFs with a version of 2.3 are not supported.";
					return false;

				case 0x03000000: // 3.0 - Star Trek: Bridge Commander
					_Error_ += $"Error reading {_NifIdentifier_}. NIFs with a version of 3.0 are not supported.";
					return false;

				case 0x03030000: // 3.03 - Dark Age of Camelot
					_Error_ += $"Error reading {_NifIdentifier_}. NIFs with a version of 3.03 are not supported.";
					return false;

				case 0x03010000: // 3.1 - Dark Age of Camelot, Star Trek: Bridge Commander
					_Error_ += $"Error reading {_NifIdentifier_}. NIFs with a version of 3.1 are not supported.";
					return false;

				case 0x0303000d: //  3.3.0.13	- {{Munch's Oddysee}}, Oblivion
				case 0x04000000: //  4.0.0.0	- Freedom Force
				case 0x04000002: //  4.0.0.2	- {{Morrowind}}, {{Freedom Force}}
				case 0x0401000c: //  4.1.0.12	- Dark Age of Camelot
				case 0x04020002: //  4.2.0.2	- Civilization IV
				case 0x04020100: //  4.2.1.0	- Dark Age of Camelot, Civilization IV
				case 0x04020200: //  4.2.2.0	- {{Culpa Innata}}, Civilization IV, Dark Age of Camelot, Empire Earth II
				case 0x0a000100: // 10.0.1.0	- {{Zoo Tycoon 2}}, Civilization IV, Oblivion
					return true;

				case 0x0a000102: // 10.0.1.2	- Oblivion
					switch (_BsVersion_)
					{
						case 1:
						case 3:
							return true;

						default:
							_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
							           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
							return false;
					}

				case 0x0a010000: // 10.1.0.0	- {{Freedom Force vs. the 3rd Reich}}, {{Axis and Allies}}, {{Empire Earth II}}, {{Kohan 2}},
					return true;			//    {{Sid Meier's Pirates!}}, Dark Age of Camelot, Civilization IV, Wildlife Park 2, The Guild 2, NeoSteam

				case 0x0a010065: // 10.1.0.101
					if ((_UserVersion_ == 10) && (_BsVersion_ == 4)) // Oblivion
					{
						return true;
					}
					_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
					           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
					return false;

				case 0x0a01006a: // 10.1.0.106
					if ((_UserVersion_ == 10) && (_BsVersion_ == 5)) // Oblivion
					{
						return true;
					}
					_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
					           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
					return false;

				case 0x0a020000: // 10.2.0.0
					switch (_UserVersion_)
					{
						case 0: // {{Pro Cycling Manager}}, {{Prison Tycoon}}, {{Red Ocean}}, {{Wildlife Park 2}}, Civilization IV, Loki
						case 1: // {{Blood Bowl}}
							return true;

						case 10: // Oblivion
							switch (_BsVersion_)
							{
								case 6:
								case 7:
								case 8:
								case 9:
									return true;

								default:
									_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
									           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
									return false;
							}

						default:
							_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
							           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
							return false;
					}

				case 0x0a020001: // 10.2.0.1	- WorldShift
				case 0x0a030001: // 10.3.0.1	- WorldShift
				case 0x0a040001: // 10.4.0.1	- {{WorldShift}}
					return true;

				case 0x14000004: // 20.0.0.4
					switch (_UserVersion_)
					{
						case 0:							// {{Civilization IV}}, {{Sid Meier's Railroads}}, Florensia, Ragnarok Online 2, IRIS Online
						case 10 when _BsVersion_ == 11: // {{Oblivion KF}}
						case 11 when _BsVersion_ == 11: // Fallout 3
							return true;

						default:
							_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
							           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
							return false;
					}

				case 0x14000005: // 20.0.0.5
					if (_UserVersion_ == 10 && _BsVersion_ == 11) // {{Oblivion}}
					{
						return true;
					}
					_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
					           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
					return false;

				case 0x14010003: // 20.1.0.3	- {{Shin Megami Tensei: Imagine}}
					return true;

				case 0x14020007: // 20.2.0.7
					switch (_UserVersion_)
					{
						case 0: // {{Florensia}}, Empire Earth III, Atlantica Online, IRIS Online, Wizard101
							return true;

						case 11:
							switch (_BsVersion_)
							{
								case 14: // Fallout 3, Fallout NV
								case 16: // Fallout 3 - Sometimes has an extension of "rdt"
								case 21: // Fallout 3, Fallout NV
								case 24: // Fallout 3, Fallout NV
								case 25: // Fallout 3, Fallout NV
								case 26: // Fallout 3, Fallout NV
								case 27: // Fallout 3, Fallout NV
								case 28: // Fallout 3, Fallout NV
								case 30: // Fallout 3, Fallout NV
								case 31: // Fallout 3, Fallout NV
								case 32: // Fallout 3, Fallout NV
								case 33: // Fallout 3, Fallout NV
								case 34: // {{Fallout 3}}, {{Fallout NV}} - Sometimes has an extension of "rdt"
									return true;

								default:
									_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
									           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
									return false;
							}

						case 12:
							switch (_BsVersion_)
							{
								case  83: // {{Skyrim}}		- Sometimes has an extension of "bto" or "btr"
								case 100: // {{Skyrim SE}}	- Sometimes has an extension of "bto" or "btr"
								case 130: // {{Fallout 4}}	- Sometimes has an extension of "bto" or "btr"
								case 155: // {{Fallout 76}}	- Sometimes has an extension of "bto"
									return true;

								default:
									_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
									           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
									return false;
							}

						default:
							_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
							           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
							return false;
					}

				case 0x14020008: // 20.2.0.8	- {{Empire Earth III}}, {{FFT Online}}, Atlantica Online, IRIS Online, Wizard101
					return true;			//	- Sometimes has an extension of "nifcache"

				case 0x14030001: // 20.3.0.1	- Emerge
				case 0x14030002: // 20.3.0.2	- Emerge
				case 0x14030003: // 20.3.0.3	- Emerge
				case 0x14030006: // 20.3.0.6	- Emerge
					return true;

				case 0x14030009: // 20.3.0.9
					switch (_UserVersion_)
					{
						case 0: // {{Bully SE}}, Warhammer, Lazeska, Howling Sword, Ragnarok Online 2 - Sometimes has an extension of "nft" or "item"
						case 0x10000: // Divinity 2 - Sometimes has an extension of "nft" or "item"
						case 0x20000: // {{Divinity 2}} - Sometimes has an extension of "item"
						case 0x30000: // {{Divinity 2}} - Sometimes has an extension of "item"
							return true;

						default:
							_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
							           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
							return false;
					}

				case 0x14050000: // 20.5.0.0	- MicroVolts, KrazyRain
				case 0x14060000: // 20.6.0.0	- {{MicroVolts}}, {{IRIS Online}}, {{Ragnarok Online 2}}, KrazyRain, Atlantica Online, Wizard101
					return true;

				case 0x14060500: // 20.6.5.0
					if (_UserVersion_ == 17) // Epic Mickey 2
					{
						_Error_ += $"Error reading {_NifIdentifier_}. NIFs with a version of 20.6.5.0 and User version of 17 are not supported.";
						return false;
					}
					_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
					           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
					return false;

				case 0x1E000002: // 30.0.0.2	- Emerge
				case 0x1E010001: // 30.1.0.1	- Emerge
				case 0x1E010003: // 30.1.0.3	- Rocksmith, Rocksmith 2014
				case 0x1E020003: // 30.2.0.3	- Ghost In The Shell: First Assault, MapleStory 2
					return true;

				default:
					_Error_ += $"Error reading {_NifIdentifier_}. This BSA is an unrecognised version and it is assumed that" +
					           $"it's not supported. Version: {_NifVersion_}. User version: {_UserVersion_}, BS Version: {_BsVersion_}";
					return false;
			}
		}
	}
}
