using Moravia.Services;
using NUnit.Framework;
namespace Moravia.Test.Services
{
	[TestFixture]
	class FileSystemServiceTest
	{

		[Test]
		public void TransformFileXmlJsonTest()
		{
			string from = "xml";
			string to = "json";
			string source = "<document>\r\n<title>Titulek</title>\r\n<text>Tohle je testovaci text v cestine!</text>\r\n</document>";

			TransformFileService transformFileService = new TransformFileService();

			Assert.AreEqual("{\"Title\":\"Titulek\",\"Text\":\"Tohle je testovaci text v cestine!\"}", transformFileService.Transform(from, to, source));
		}

		[Test]
		public void TranformFileJsonXmlTest()
		{
			string to = "xml";
			string from = "json";
			string source = "{\"Title\":\"Titulek\",\"Text\":\"Tohle je testovaci text v cestine!\"}";

			TransformFileService transformFileService = new TransformFileService();

			Assert.AreEqual("<document>\r\n<title>Titulek</title>\r\n<text>Tohle je testovaci text v cestine!</text>\r\n</document>", transformFileService.Transform(from, to, source));
		}
	}
}
