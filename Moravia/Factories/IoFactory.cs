using Moravia.Services;

namespace Moravia.Factories
{
	public class IoFactory
	{
		private static ApiService fApiService;
		private static FileSystemService fFileSystemService;

		public IIoService GetIoService(bool setSource)
		{ 
			if ((Settings.IsRemoteSource() && setSource) || (Settings.IsRemoteTarget() && !setSource))
			{
				if (fApiService == null)
					fApiService = new ApiService();
				return fApiService;
			}
			else
			{
				if (fFileSystemService == null)
					fFileSystemService = new FileSystemService();
				return fFileSystemService;
			}
		} 
	}
}
