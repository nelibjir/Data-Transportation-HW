using log4net;
using log4net.Config;
using log4net.Repository;
using Moravia.Services;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Moravia
{
	public class Program
	{

		private static readonly ILog fLog = LogManager.GetLogger(typeof(Program));

		public async static Task Main(string[] args)
		{
			ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
			XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
			CancellationTokenSource cts = new CancellationTokenSource();

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

			await ioService.SaveToDestinationAsync(output, cts.Token); //TODO make write async also - not such usable in this case
			fLog.Info($"Finished the processing with: {output}...");
		}
	}
}
