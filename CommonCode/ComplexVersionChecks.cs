// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


namespace CommonCode
{
	/// <summary>
	/// Holds various methods used to perform the more complicated version tests documented in the NIF xml specification
	/// </summary>
	internal struct ComplexVersionChecks
	{
		/// <summary>
		/// Tests whether the current NIF has (or should have) a BS Stream Header.
		/// </summary>
		/// <param name="_NifVersion_">NIF's Version</param>
		/// <param name="_UserVersion_">NIF's User Version</param>
		/// <returns>True if the model's header has a BS Stream Header. False otherwise.</returns>
		internal static bool _BSStreamHeader(in uint _NifVersion_, in uint _UserVersion_)
		{
			switch (_NifVersion_)
			{
				case 0x0A000102: // 10.0.1.2
					return true;

				case 0x14000005: // 20.0.0.5
					return true;

				case 0x14020007: // 20.2.0.7
					return true;

				default:
					if ((0x0A010000 <= _NifVersion_ && _NifVersion_ <= 0x14000004) && (3 <= _UserVersion_ && _UserVersion_ <= 11))
					{
						// If (10.1.0.0 <= NifVer <= 20.0.0.4) && (3 <= UserVer <= 11)
						return true;
					}
					return false;
			}
		}
	}
}
