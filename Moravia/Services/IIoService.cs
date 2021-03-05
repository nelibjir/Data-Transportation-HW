namespace Moravia.Services
{
	public interface IIoService
	{
		string ReadFromSource();
		void SaveToDestination(string serializedDoc);
	}
}
