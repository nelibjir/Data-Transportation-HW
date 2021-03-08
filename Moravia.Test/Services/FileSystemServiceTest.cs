using Moravia.Services;
using NUnit.Framework;
using System.Xml.Linq;

namespace Moravia.Test.Services
{
	[TestFixture]
	class FileSystemServiceTest
	{

		[Test]
		public void TransformFileXmlJsonTest()
		{
			string from = ".xml";
			string to = ".json";

			XElement xml = new XElement("Document", new XElement("Title", "Titulek"), new XElement("Text", "Tohle je testovaci text v cestine!"));
			string source = xml.ToString();

			TransformFileService transformFileService = new TransformFileService();

			Assert.AreEqual("{\"Title\":\"Titulek\",\"Text\":\"Tohle je testovaci text v cestine!\"}", transformFileService.Transform(from, to, source));
		}

		[Test]
		public void TranformFileJsonXmlTest()
		{
			string to = ".xml";
			string from = ".json";
			string source = "{\"Title\":\"Titulek\",\"Text\":\"Tohle je testovaci text v cestine!\"}";

			TransformFileService transformFileService = new TransformFileService();

			Assert.AreEqual("<Document>\r\n  <Title>Titulek</Title>\r\n  <Text>Tohle je testovaci text v cestine!</Text>\r\n</Document>", transformFileService.Transform(from, to, source));
		}
	}
}
