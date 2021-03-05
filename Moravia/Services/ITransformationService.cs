using Moravia.Dtos;

namespace Moravia.Services
{
	public interface ITransformationService
	{
		string Transform(string fromFormat, string toFormat, string source);
	}
}
