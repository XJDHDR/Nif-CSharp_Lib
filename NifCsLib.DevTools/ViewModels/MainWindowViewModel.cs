using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NifCsLib.DevTools.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{
		private static readonly Action? convertXmlToEnumsConvertMethod;

		static MainWindowViewModel()
		{
			convertXmlToEnumsConvertMethod = findClassMethod("NifCsLib.DevTools.Models.ConvertXmlToEnums", "Convert");
		}

		private static Action? findClassMethod(string TypeName, string MethodName)
		{
			Type? classType = Type.GetType(TypeName);

			// ReSharper disable once UseNullPropagation
			if (classType == null)
				return null;

			MethodInfo? classMethodInfo = classType.GetMethod(MethodName);

			return (Action?)classMethodInfo?.CreateDelegate(classType);
		}

		public static void ConvertXmlToEnumsButtonClickedEventHandler()
		{
			if (convertXmlToEnumsConvertMethod == null)
			{
				Console.WriteLine("ConvertXmlToEnumsButtonClickedEventHandler: cachedMethod is null.");
				return;
			}

			convertXmlToEnumsConvertMethod.Invoke();
		}
	}
}
