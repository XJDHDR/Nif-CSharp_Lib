// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/
//

// <token name="verexpr" attrs="vercond">

namespace Nif_CSLib_CommonCode
{
	/// <summary>
	/// This struct holds a number of common version checks that are documented in the VerExpr token.
	/// </summary>
	public struct BlockVersionChecks
	{
		/// <summary>
		/// Used to check if the current NIF does not have a BSStream Header and hence, is not a Bethesda model.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version indicates that this isn't a Bethesda model. False otherwise.</returns>
		public static bool _NiStream(in uint _BsVersion_)
		{
			return (_BsVersion_ == 0);
		}

		/// <summary>
		/// Used to check if the current NIF has a BSStream Header and hence, is a Bethesda model.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version indicates that this is a Bethesda model. False otherwise.</returns>
		public static bool _BsStream(in uint _BsVersion_)
		{
			return (_BsVersion_ > 0);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version less than or equal to 16.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is less than or equal to 16. False otherwise.</returns>
		public static bool _Ni_Bs_Lte_16(in uint _BsVersion_)
		{
			return (_BsVersion_ <= 16);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's before Fallout 3 or not Bethesda.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is before Fallout 3 or not Bethesda. False otherwise.</returns>
		public static bool _Ni_Bs_Lt_FO3(in uint _BsVersion_)
		{
			return (_BsVersion_ < 34);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's up to Fallout 3 or not Bethesda.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is up to Fallout 3 or not Bethesda. False otherwise.</returns>
		public static bool _Ni_Bs_Lte_FO3(in uint _BsVersion_)
		{
			return (_BsVersion_ <= 34);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's before Skyrim SE or not Bethesda.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is before Skyrim SE or not Bethesda. False otherwise.</returns>
		public static bool _Ni_Bs_Lt_SSE(in uint _BsVersion_)
		{
			return (_BsVersion_ < 100);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's before Fallout 4 or not Bethesda.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is before Fallout 4 or not Bethesda. False otherwise.</returns>
		public static bool _Ni_Bs_Lt_FO4(in uint _BsVersion_)
		{
			return (_BsVersion_ < 130);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's up to Fallout 4 or not Bethesda.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is up to Fallout 4 or not Bethesda. False otherwise.</returns>
		public static bool _Ni_Bs_Lte_FO4(in uint _BsVersion_)
		{
			return (_BsVersion_ <= 130);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's after Fallout 3.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is after Fallout 3. False otherwise.</returns>
		public static bool _Bs_Gt_FO3(in uint _BsVersion_)
		{
			return (_BsVersion_ > 34);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's at or after Fallout 3.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is at or after Fallout 3. False otherwise.</returns>
		public static bool _Bs_Gte_FO3(in uint _BsVersion_)
		{
			return (_BsVersion_ >= 34);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's at or after Skyrim.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is at or after Skyrim. False otherwise.</returns>
		public static bool _Bs_Gte_Sky(in uint _BsVersion_)
		{
			return (_BsVersion_ >= 83);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's at or after Skyrim SE.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is at or after Skyrim SE. False otherwise.</returns>
		public static bool _Bs_Gte_SSE(in uint _BsVersion_)
		{
			return (_BsVersion_ >= 100);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's a Skyrim SE NIF.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is a Skyrim SE NIF. False otherwise.</returns>
		public static bool _Bs_SSE(in uint _BsVersion_)
		{
			return (_BsVersion_ == 100);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's a Fallout 4 NIF.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is a Fallout 4 NIF. False otherwise.</returns>
		public static bool _Bs_FO4(in uint _BsVersion_)
		{
			return (_BsVersion_ == 130);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's at or after Fallout 4.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is at or after Fallout 4. False otherwise.</returns>
		public static bool _Bs_Gte_FO4(in uint _BsVersion_)
		{
			return (_BsVersion_ >= 130);
		}

		/// <summary>
		/// Used to check if the current NIF has a BS Version indicating that it's a Fallout 76 NIF.
		/// </summary>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the BS Version is a Fallout 76 NIF. False otherwise.</returns>
		public static bool _Bs_F76(in uint _BsVersion_)
		{
			return (_BsVersion_ == 155);
		}

		/// <summary>
		/// Used to check if the current NIF is a Bethesda v20.2 model.
		/// </summary>
		/// <param name="_NifVersion_">The model's Nif Version.</param>
		/// <param name="_BsVersion_">The model's BS Version.</param>
		/// <returns>True if the NIF is a Bethesda v20.2 model. False otherwise.</returns>
		public static bool _Bs202(in uint _NifVersion_, in uint _BsVersion_)
		{
			return ((_NifVersion_ == 0x14020007) && (_BsVersion_ > 0)); // 20.2.0.7
		}

		/// <summary>
		/// Used to check if the current NIF is a Divinity 2 model.
		/// </summary>
		/// <param name="_UserVersion_">The model's User Version.</param>
		/// <returns>True if the NIF is a Divinity 2 model. False otherwise.</returns>
		public static bool _Divinity2(in uint _UserVersion_)
		{
			switch (_UserVersion_)
			{
				case 0x20000:
				case 0x30000:
					return true;

				default:
					return false;
			}
		}
	}
}
