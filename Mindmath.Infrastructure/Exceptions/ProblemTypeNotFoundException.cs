namespace Mindmath.Repository.Exceptions
{
	public class ProblemTypeNotFoundException : NotFoundException
	{
		public ProblemTypeNotFoundException(Guid problemTypeId) : base($"The problem type with id: {problemTypeId} doesn't exist in the database")
		{
		}
	}
}
