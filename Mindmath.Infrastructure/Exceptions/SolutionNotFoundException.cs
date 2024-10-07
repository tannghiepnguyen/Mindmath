namespace Mindmath.Repository.Exceptions
{
	public class SolutionNotFoundException : NotFoundException
	{
		public SolutionNotFoundException(Guid inputParameterId) : base($"The solution with input parameter id: {inputParameterId} doesn't exist in the database")
		{
		}
	}
}
