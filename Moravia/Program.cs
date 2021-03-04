using System;
using System.IO;
using System.Xml.Linq;
using Moravia.Dtos;
using Moravia.Utils;
using Newtonsoft.Json;

namespace Moravia
{
	public class Program
	{

		private static readonly log4net.ILog fLog = log4net.LogManager.GetLogger(typeof(Program));

		public static void Main(string[] args)
		{
			fLog.Info("Started to process the data...");
			string sourceFileName = Settings.GetSourceFilePath();
			string targetFileName = Settings.GetDestinationFilePath();

			string input = FileUtil.ReadFile(sourceFileName);
			

			XDocument xdoc = XDocument.Parse(input); //should check this is really xml DEBUG
			DocumentDto doc = new DocumentDto
			{
				Title = xdoc.Root.Element("title").Value, // check  when it not exists
				Text = xdoc.Root.Element("text").Value
			};

			string serializedDoc = JsonConvert.SerializeObject(doc);
			FileUtil.WriteFile(targetFileName, serializedDoc);
			fLog.Info("Finished the processing...");
		}
	}
}
