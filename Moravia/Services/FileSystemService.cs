using Moravia.Utils;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Moravia.Services
{
	public class FileSystemService: IIoService
	{
		private static readonly string fSourceFileName = Settings.GetSourceFilePath();
		private static readonly string fDestinationFileName = Settings.GetDestinationFilePath();

		public string GetDestinationDocumentType() => Path.GetExtension(fDestinationFileName);

		public string GetSourceDocumentType() => Path.GetExtension(fSourceFileName);

		public async Task<string> ReadFromSourceAsync() => await FileUtil.ReadFileAsync(fSourceFileName);

		public async Task SaveToDestinationAsync(string serializedDoc, CancellationToken cancellationToken)
		{
			if (String.IsNullOrEmpty(serializedDoc))
				throw new ArgumentException($"{serializedDoc} is empty or null!");

			await FileUtil.WriteFileAsync(fDestinationFileName, serializedDoc, cancellationToken);
		}
	}
}
