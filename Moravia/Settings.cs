using Microsoft.Extensions.Configuration;
using System.IO;

namespace Moravia
{
	public class Settings
	{
        private static IConfigurationBuilder fBuilder;
        public static string GetSourceFilePath() {
            if (fBuilder == null)
                createBuilder();
            return fBuilder.Build().GetSection("SourceFile").Value;
        }

        public static string GetDestinationFilePath() {
            if (fBuilder == null)
                createBuilder();
            return fBuilder.Build().GetSection("DestinationFile").Value;
        }

        private static void createBuilder()
        {
			fBuilder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsetings.json", optional: true, reloadOnChange: true);
        }
    }
}
