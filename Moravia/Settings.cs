using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Moravia
{
	public class Settings
	{
        private const string _DestinationFileNameElemente = "DestinationFile";
        private const string _SettingFileName = "appsettings.json";
        private const string _SourceFileNameElement = "SourceFile";
        private const string _IsRemoteElement = "Remote";
        private const string _UrlPathElement = "Remote";

        private static IConfigurationRoot fBuilder;

        public static string GetSourceFilePath() {
            if (fBuilder == null)
                createBuilder();
            return fBuilder.GetSection(_SourceFileNameElement).Value;
        }

        public static string GetDestinationFilePath() {
            if (fBuilder == null)
                createBuilder();
            return fBuilder.GetSection(_DestinationFileNameElemente).Value;
        }

        public static string GetUrlPath()
        {
            if (fBuilder == null)
                createBuilder();
            return fBuilder.GetSection(_UrlPathElement).Value;
        }

        public static bool IsRemote()
        {
            if (fBuilder == null)
                createBuilder();
            return bool.Parse(fBuilder.GetSection(_IsRemoteElement).Value);
        }

        private static void createBuilder()
        {
            fBuilder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                                .AddJsonFile(_SettingFileName, optional: false, reloadOnChange: true)
                                .Build();
        }
    }
}
