using log4net;
using Moravia.Services;

namespace Moravia
{
	public class Program
	{

		private static readonly ILog fLog = LogManager.GetLogger(typeof(Program));

		public static void Main(string[] args)
		{
			fLog.Info("Started to process the data...");

			IIoService ioService;
			ITransformationService transformationService;
			if (Settings.IsRemote())
				ioService = new ApiService();
			else
				ioService = new FileSystemService();

			string input = ioService.ReadFromSource();

			transformationService = new TransformFileService();
			string output = transformationService.Transform(ioService.GetSourceDocumentType(), ioService.GetDestinationDocumentType(), input);

			ioService.SaveToDestination(output);
			fLog.Info("Finished the processing...");
		}
	}
}
