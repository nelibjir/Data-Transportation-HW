using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Moravia.Services
{
	public class ApiService : IIoService
	{
		//TODO IoC here? 
		private static readonly HttpClient client = new HttpClient();

		public string GetDestinationDocumentType() => throw new System.NotImplementedException();
		public string GetSourceDocumentType() => throw new System.NotImplementedException();
		public async Task<string> ReadFromSourceAsync()
		{
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

			return await client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
		}
		public void SaveToDestination(string serializedDoc) => throw new System.NotImplementedException();
	}
}
