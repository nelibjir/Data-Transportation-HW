using System.Threading.Tasks;

namespace Moravia.Services
{
	public interface IIoService
	{
		string GetDestinationDocumentType();
		string GetSourceDocumentType();
		Task<string> ReadFromSourceAsync();
		void SaveToDestination(string serializedDoc);
	}
}
