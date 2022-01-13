// This file is or was originally a part of the Nif - C# Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
// This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
// The code in this file was written almost entirely thanks to the file format specification provided by the
// NIFxml project: https://github.com/niftools/nifxml/
//


namespace CommonCode
{
	internal struct ComplexVersionChecks
	{
		internal static bool _BSStreamHeader(in uint _NifVersion, in uint _UserVersion)
		{
			switch (_NifVersion)
			{
				case 0x0A000102: // 10.0.1.2
					return true;

				case 0x14000005: // 20.0.0.5
					return true;

				case 0x14020007: // 20.2.0.7
					return true;

				default:
					if ((0x0A010000 <= _NifVersion && _NifVersion <= 0x14000004) && (3 <= _UserVersion && _UserVersion <= 11))
					{
						// If (10.1.0.0 <= NifVer <= 20.0.0.4) && (3 <= UserVer <= 11)
						return true;
					}
					return false;
			}
		}
	}
}
