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

			Assume.That(!String.IsNullOrEmpty(FileUtil.ReadFile(Settings.GetSourceFilePath())));

			Assert.IsNotNull(ioService.ReadFromSource());
		}
	}
}
