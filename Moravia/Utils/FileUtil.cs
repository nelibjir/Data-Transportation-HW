using log4net;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Moravia.Utils
{
	public class FileUtil
	{
		private static readonly ILog fLog = LogManager.GetLogger(typeof(FileUtil));

		public static async Task<string> ReadFileAsync(string sourceFileName)
		{
			try
			{
				using FileStream sourceStream = File.Open(sourceFileName, FileMode.Open);
				using (StreamReader reader = new StreamReader(sourceStream))
				{
					return await reader.ReadToEndAsync();
				}
			}
			catch (FileNotFoundException ex) 
			{
				fLog.Error("File not found while trying to read it", ex);
				throw;
			}
			catch (ArgumentException ex)
			{
				fLog.Error("Not valid argument, can be invalid string or null", ex);
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
				fLog.Error("Unauthorized access to a location on disk, write operation is not allowed", ex);
				throw;
			}
			catch (ArgumentException ex)
			{
				fLog.Error("Not valid argument, can be invalid string or null", ex);
				throw;
			}
		}
	}
}
