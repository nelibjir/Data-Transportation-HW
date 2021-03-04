using System;
using System.IO;
using System.Xml.Linq;
using Moravia.Dtos;
using Newtonsoft.Json;

namespace Moravia
{
	class Program
	{
		static void Main(string[] args)
		{
			// TODO check also it exists! 
			string sourceFileName = Path.Combine(Environment.CurrentDirectory, Settings.GetSourceFilePath());
			string targetFileName = Path.Combine(Environment.CurrentDirectory, Settings.GetDestinationFilePath());

			//FIXME put the reader to using, so the stream would be dispatch, closed
			try
			{
				FileStream sourceStream = File.Open(sourceFileName, FileMode.Open); // TODO reduce - this line is needless
				var reader = new StreamReader(sourceStream);
				string input = reader.ReadToEnd();


				// TODO should check this is really xml
				var xdoc = XDocument.Parse(input); //FIXME the input is not seen on scope, should be above catch
				var doc = new DocumentDto
				{
					Title = xdoc.Root.Element("title").Value, /// TODO what if title is null?
					Text = xdoc.Root.Element("text").Value // TODO what if text is null?
				};

				var serializedDoc = JsonConvert.SerializeObject(doc);

				var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
				var sw = new StreamWriter(targetStream); //FIXME again all of this in the using together
				sw.Write(serializedDoc); // FIXME under catch also! 

			}
			catch (Exception ex) // FIXME with exact Exceptions
			{
				throw new Exception(ex.Message); // FIXME on some exact exception, also we don't need to to throw it again maybe, this is now useless
			}
		}
	}
}
