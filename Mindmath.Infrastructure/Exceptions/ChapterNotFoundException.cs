namespace Mindmath.Repository.Exceptions
{
	public class ChapterNotFoundException : NotFoundException
	{
		public ChapterNotFoundException(Guid chapterId) : base($"The chapter with id: {chapterId} doesn't exist in the database")
		{
		}
	}
}
