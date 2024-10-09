namespace Mindmath.Repository.Exceptions
{
	public abstract class BadRequestException : Exception
	{
		protected BadRequestException(string message) : base(message)
		{
		}
	}
}
