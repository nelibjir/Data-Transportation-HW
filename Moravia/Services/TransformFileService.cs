using log4net;
using Moravia.Dtos;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Moravia.Services
{
	public class TransformFileService: ITransformationService
	{
		private static readonly string[] _SupportedFromExtensions = new string[] { "xml", "json" };
		private static readonly string[] _SupportedToExtensions = new string[] { "xml", "json" };

		private const string _RootXmlelemnt = "Document";
		private const string _TitleElement = "title";
		private const string _TextElement = "text";

		private static readonly ILog fLog = LogManager.GetLogger(typeof(FileSystemService));

		/// <summary>
		/// Transform the source string from type of format, which is specified in the parameter toFormat,
		///  to format specified in parametr toFormat
		/// </summary>
		/// <param name="fromFormat">Name of the original file format </param>
		/// <param name="toFormat">Name of the final file format</param>
		/// <param name="source">the string source which should be transformed</param>
		/// <returns>Transformed string</returns>
		/// <exception cref="ArgumentException">One of the agruments is invalid, means it's empty or null</exception>
		/// <exception cref="NotSupportedException">On of the formats is not yet supported by our service</exception>
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

			ValidateXml(source);

			XDocument xdoc = XDocument.Parse(source);
			DocumentDto doc = new DocumentDto
			{
				Title = xdoc.Root.Element(_TitleElement).Value,
				Text = xdoc.Root.Element(_TextElement).Value
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
				case ".xml.json":
					return FromXmlToJson(source);
				case ".json.xml":
					return FromJsonToXml(source);
				default:
					fLog.Warn($"This tanformation is not implemented: {typeOfTransformation}");
					return "";
			}
		}

		// later on add all validation methods about files to a special Validator class
		private void ValidateXml(string source)
		{
			//FIXME should later check also mandatory XML documents
			XmlDocument document = new XmlDocument();
			document.Load(source);
		}
	}
}
