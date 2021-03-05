using log4net;
using Moravia.Utils;
using System;

namespace Moravia.Services
{
	public class FileSystemService: IIoService
	{
		private static readonly string fSourceFileName = Settings.GetSourceFilePath();
		private static readonly string fTargetFileName = Settings.GetDestinationFilePath();

		public string ReadFromSource() => FileUtil.ReadFile(fSourceFileName);

		public void SaveToDestination(string serializedDoc)
		{
			if (String.IsNullOrEmpty(serializedDoc))
				throw new ArgumentException($"{serializedDoc} is empty or null!");

			FileUtil.WriteFile(fTargetFileName, serializedDoc);
		}
	}
}
