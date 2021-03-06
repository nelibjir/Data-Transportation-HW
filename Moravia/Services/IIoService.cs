namespace Moravia.Services
{
	public interface IIoService
	{
		string GetDestinationDocumentType();
		string GetSourceDocumentType();
		string ReadFromSource();
		void SaveToDestination(string serializedDoc);
	}
}
