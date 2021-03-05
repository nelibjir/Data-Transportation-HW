using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Moravia
{
    // TODO add here the literals to constants
	public class Settings
	{
        private static IConfigurationRoot fBuilder;
        public static string GetSourceFilePath() {
            if (fBuilder == null)
                createBuilder();
            return fBuilder.GetSection("SourceFile").Value;
        }

        public static string GetDestinationFilePath() {
            if (fBuilder == null)
                createBuilder();
            return fBuilder.GetSection("DestinationFile").Value;
        }

        public static bool IsRemote()
        {
            if (fBuilder == null)
                createBuilder();
            return bool.Parse(fBuilder.GetSection("IsRemote").Value);
        }

        private static void createBuilder()
        {
            fBuilder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();
        }
    }
}
