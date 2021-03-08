using log4net;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Moravia.Services
{
	public class ApiService : IIoService
	{
		private static HttpClient fClient = new HttpClient();
		private static readonly ILog fLog = LogManager.GetLogger(typeof(ApiService));

		public string GetDestinationDocumentType() => throw new NotImplementedException();
		public string GetSourceDocumentType() => throw new NotImplementedException();

		public async Task<string> ReadFromSourceAsync()
		{
			throw new NotImplementedException(); //can't be used yet

			fClient.DefaultRequestHeaders.Accept.Clear();
			fClient.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			fClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

			// to test this I would need to find API, found Google api, but need to generate token yet
			return await fClient.GetStringAsync(Settings.GetUrlPath());
		}
		public async Task SaveToDestinationAsync(string serializedDoc, CancellationToken cancellationToken)
		{
			if (String.IsNullOrEmpty(serializedDoc))
				throw new ArgumentException($"{serializedDoc} is empty or null!");

			throw new NotImplementedException(); //can't be used yet

			string url = Settings.GetUrlPath();
			HttpResponseMessage response = await fClient.
				PostAsync(url, new StringContent(serializedDoc, Encoding.UTF8, "application/json"), cancellationToken);

			if (response != null)
				fLog.Info($"Response from the URL {url} is: {response}");
		}
	}
}
