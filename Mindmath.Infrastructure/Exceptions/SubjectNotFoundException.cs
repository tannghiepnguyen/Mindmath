namespace Mindmath.Repository.Exceptions
{
	public sealed class SubjectNotFoundException : NotFoundException
	{
		public SubjectNotFoundException(Guid subjectId) : base($"The subject with id: {subjectId} doesn't exist in the database")
		{
		}
	}
}
