using log4net;
using Moravia.Dtos;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Xml.Linq;

namespace Moravia.Services
{
	public class TransformFileService: ITransformationService
	{
		private static readonly string[] _SupportedFromExtensions = new string[] { "xml", "json" };
		private static readonly string[] _SupportedToExtensions = new string[] { "xml", "json" };

		private const string _RootXmlelemnt = "Document";

		private static readonly ILog fLog = LogManager.GetLogger(typeof(FileSystemService));

		public string Transform(string fromFormat, string toFormat, string source)
		{
			if (String.IsNullOrEmpty(fromFormat) || String.IsNullOrEmpty(toFormat))
				throw new ArgumentException($"source {fromFormat} or target {toFormat} is empty or null!");
			if (!_SupportedFromExtensions.Any(fromFormat.Contains) || !_SupportedToExtensions.Any(toFormat.Contains))
				throw new NotSupportedException($"The {fromFormat} format or {toFormat} format is not supported for transformation");

			if (toFormat == fromFormat)
				return toFormat;

			string typeOfTransformation = fromFormat + toFormat;
			return Process(typeOfTransformation, source);
		}

		public string FromXmlToJson(string source)
		{
			if (String.IsNullOrEmpty(source))
			{
				fLog.Warn("source to transform from XML is empty!");
				return "";
			}

			XDocument xdoc = XDocument.Parse(source); //should check this is really xml DEBUG - Not only XML
			DocumentDto doc = new DocumentDto
			{
				Title = xdoc.Root.Element("title").Value, // check  when it not exists
				Text = xdoc.Root.Element("text").Value
			};

			return JsonConvert.SerializeObject(doc);
		}

		public string FromJsonToXml(string source)
		{
			if (String.IsNullOrEmpty(source))
			{
				fLog.Warn("source to transform from JSON is empty!");
				return "";
			}

			XNode node = JsonConvert.DeserializeXNode(source, _RootXmlelemnt);

			return node.ToString();
		}

		private string Process(string typeOfTransformation, string source)
		{
			switch (typeOfTransformation)
			{
				case "xmljson":
					return FromXmlToJson(source);
				case "jsonxml":
					return FromJsonToXml(source);
				default:
					fLog.Warn($"This tanformation is not implemented: {typeOfTransformation}");
					return "";
			}
		}
	}
}
