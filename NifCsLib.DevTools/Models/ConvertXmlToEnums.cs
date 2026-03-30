// This file is or was originally a part of the Nif - CSharp Lib project, which can be found here: https://github.com/XJDHDR/Nif-CSharp_Lib
//  This code is provided under the license found here: https://github.com/XJDHDR/Nif-CSharp_Lib/blob/main/LICENSE.md
//
//  The code in this file was written almost entirely thanks to the file format specification provided by the
//  NIFxml project: https://github.com/niftools/nifxml/

using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace NifCsLib.DevTools.Models;

public partial class ConvertXmlToEnums
{
	[XmlRoot("niftoolsxml")]
	public struct NifToolsXml
	{
		[XmlText]
		public string? Description { get; set; }

		[XmlElement("enum")]
		public List<EnumDefinition> EnumDefinitions { get; set; }
	}

	public struct EnumDefinition
	{
		[XmlAttribute("name")]
		public string? Name { get; set; }

		[XmlAttribute("storage")]
		public string? Storage { get; set; }

		[XmlElement("option")]
		public List<EnumOption> Options { get; set; }

		[XmlText]
		public string? Description { get; set; }
	}

	public struct EnumOption
	{
		[XmlAttribute("value")]
		public string? Value { get; set; }

		[XmlAttribute("name")]
		public string? Name { get; set; }

		[XmlText]
		public string? Description { get; set; }
	}

	public static void Convert()
	{
		if (!File.Exists("input.txt"))
		{
			File.WriteAllBytes("input.txt", Array.Empty<byte>());
			return;
		}

		string xmlText = File.ReadAllText("input.txt");
		XmlSerializer serializer = new(typeof(NifToolsXml));
		NifToolsXml nifToolsXml;
		using (StringReader reader = new(xmlText))
		{
			nifToolsXml = (NifToolsXml)(serializer.Deserialize(reader) ?? throw new NullReferenceException());
		}

		StringBuilder outputStringBuilder = new();
		for (int i = 0; i < nifToolsXml.EnumDefinitions.Count; i++)
		{
			writeEnumDefinitionToFile(nifToolsXml.EnumDefinitions[i], (i == 0), in outputStringBuilder);
		}

		File.WriteAllText("output.txt", outputStringBuilder.ToString());
	}

	private static void writeEnumDefinitionToFile(EnumDefinition EnumDefinition, bool IsFirstDefinition, in StringBuilder OutputStringBuilder)
	{
		int lengthOfLongestOptionName = 0;

		for (int i = 0; i < EnumDefinition.Options.Count; i++)
		{
			int lengthOfCurrentOptionNameWithSpaceAppended = (!string.IsNullOrEmpty(EnumDefinition.Options[i].Name)) ?
				EnumDefinition.Options[i].Name.Length + 1 :
				1;

			if (lengthOfCurrentOptionNameWithSpaceAppended > lengthOfLongestOptionName)
			{
				lengthOfLongestOptionName = lengthOfCurrentOptionNameWithSpaceAppended;
			}
		}

		int tabLengthOfLongestOptionName = lengthOfLongestOptionName / 4;
		if (lengthOfLongestOptionName % 4 != 0)
		{
			tabLengthOfLongestOptionName++;
		}

		if (!IsFirstDefinition)
		{
			OutputStringBuilder.AppendLine();
		}

		if (!string.IsNullOrEmpty(EnumDefinition.Description))
		{
			string sanitisedEnumDescription = findAllWhitespacesAndLineBreaksRegex().Replace(EnumDefinition.Description.Trim(), " ");
			OutputStringBuilder.AppendLine($"\t/// <summary> {sanitisedEnumDescription} </summary>");
		}

		OutputStringBuilder.AppendLine($"\tpublic enum {EnumDefinition.Name} : {EnumDefinition.Storage}");
		OutputStringBuilder.AppendLine("\t{");

		for (int i = 0; i < EnumDefinition.Options.Count; i++)
		{
			writeEnumOptionToFile(EnumDefinition.Options[i], (i == 0), (i == EnumDefinition.Options.Count - 1), in tabLengthOfLongestOptionName, in OutputStringBuilder);
		}
	}

	private static void writeEnumOptionToFile(EnumOption EnumOption, bool IsFirstOption, bool IsLastOption, in int TabLengthOfLongestOptionName, in StringBuilder OutputStringBuilder)
	{
		if (!string.IsNullOrEmpty(EnumOption.Description))
		{
			if (!IsFirstOption)
			{
				OutputStringBuilder.AppendLine();
			}

			OutputStringBuilder.AppendLine($"\t\t/// <summary> {EnumOption.Description} </summary>");
		}

		OutputStringBuilder.Append($"\t\t{EnumOption.Name}");

		int numberOfTabsRequired = calculateRequiredNumberOfTabs(TabLengthOfLongestOptionName, EnumOption.Name.Length);
		for (int j = 0; j < numberOfTabsRequired; j++)
		{
			OutputStringBuilder.Append('\t');
		}

		OutputStringBuilder.AppendLine($"= {EnumOption.Value},");

		if (IsLastOption)
		{
			OutputStringBuilder.AppendLine("\t}");
		}
		else
		{
			OutputStringBuilder.AppendLine();
		}
	}

	private static int calculateRequiredNumberOfTabs(int TabLengthOfLongestOptionName, int CurrentOptionNameLength)
	{
		int tabLengthOfCurrentOptionName = CurrentOptionNameLength / 4;
		if (CurrentOptionNameLength % 4 != 0)
		{
			tabLengthOfCurrentOptionName++;
		}

		int differenceInTabLengths = TabLengthOfLongestOptionName - tabLengthOfCurrentOptionName;

		if (CurrentOptionNameLength % 4 != 0)
		{
			differenceInTabLengths++;
		}

		return differenceInTabLengths;
	}

	[GeneratedRegex(@"\s+")]
	private static partial Regex findAllWhitespacesAndLineBreaksRegex();

}
