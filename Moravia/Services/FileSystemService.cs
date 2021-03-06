using log4net;
using Moravia.Utils;
using System;
using System.IO;

namespace Moravia.Services
{
	public class FileSystemService: IIoService
	{
		private static readonly string fSourceFileName = Settings.GetSourceFilePath();
		private static readonly string fDestinationFileName = Settings.GetDestinationFilePath();

		public string GetDestinationDocumentType() => Path.GetExtension(fDestinationFileName);

		public string GetSourceDocumentType() => Path.GetExtension(fSourceFileName);

		public string ReadFromSource() => FileUtil.ReadFile(fSourceFileName);

		public void SaveToDestination(string serializedDoc)
		{
			if (String.IsNullOrEmpty(serializedDoc))
				throw new ArgumentException($"{serializedDoc} is empty or null!");

			FileUtil.WriteFile(fDestinationFileName, serializedDoc);
		}
	}
}
