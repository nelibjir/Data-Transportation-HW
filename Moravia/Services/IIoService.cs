using System.Threading;
using System.Threading.Tasks;

namespace Moravia.Services
{
	public interface IIoService
	{
		string GetDestinationDocumentType();
		string GetSourceDocumentType();
		Task<string> ReadFromSourceAsync();
		Task SaveToDestinationAsync(string serializedDoc, CancellationToken cancellationToken);
	}
}
