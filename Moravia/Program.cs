using log4net;
using log4net.Config;
using Moravia.Services;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Moravia
{
	public class Program
	{

		private static readonly ILog fLog = LogManager.GetLogger(typeof(Program));

		//TODO make write async also - not such usable in this case
		public async static Task Main(string[] args)
		{
			var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

			fLog.Info("Started to process the data...");

			IIoService ioService;
			ITransformationService transformationService;
			if (Settings.IsRemote())
				ioService = new ApiService();
			else
				ioService = new FileSystemService();

			string input = await ioService.ReadFromSourceAsync();
			fLog.Info($"Input file : {input}");

			transformationService = new TransformFileService();
			string output = transformationService.Transform(ioService.GetSourceDocumentType(), ioService.GetDestinationDocumentType(), input);

			ioService.SaveToDestination(output);
			fLog.Info($"Finished the processing with: {output}...");
		}
	}
}
