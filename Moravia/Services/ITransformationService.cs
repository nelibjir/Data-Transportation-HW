namespace Moravia.Services
{
	// transform file, transform data ... 
	public interface ITransformationService
	{
		string Transform(string fromFormat, string toFormat, string source);
	}
}
