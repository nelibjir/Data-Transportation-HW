using log4net;
using System;
using System.IO;

namespace Moravia.Utils
{
	public class FileUtil
	{
		private static readonly ILog fLog = LogManager.GetLogger(typeof(FileUtil));

		public static string ReadFile(string sourceFileName)
		{
			try
			{
				using FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
				using (StreamReader reader = new StreamReader(sourceStream))
				{
					return reader.ReadToEnd();
				}
			}
			catch (FileNotFoundException ex) 
			{
				fLog.Error("asd", ex);
				throw;
			}
			catch (ArgumentException ex)
			{
				fLog.Error("asd", ex);
				throw;
			}
		}

		public static void WriteFile(string targetFileName, string content)
		{
			try
			{
				using FileStream targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write);
				using (StreamWriter sw = new StreamWriter(targetStream))
				{
					sw.Write(content);
				}
			}
			catch (UnauthorizedAccessException ex) 
			{
				fLog.Error("asd", ex);
				throw;
			}
			catch (ArgumentException ex)
			{
				fLog.Error("asd", ex);
				throw;
			}
		}
	}
}
