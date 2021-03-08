using System;
using Moravia.Services;
using Moravia.Utils;
using NUnit.Framework;

namespace Moravia.Test.Services
{
	[TestFixture]
	public class IoServiceTest
	{
		[Test]
		public void ReadSystemIOTest()
		{
			IIoService ioService = new FileSystemService();

			Assume.That(!String.IsNullOrEmpty(FileUtil.ReadFileAsync(Settings.GetSourceFilePath()).Result));

			Assert.IsNotNull(ioService.ReadFromSourceAsync());
		}
	}
}
