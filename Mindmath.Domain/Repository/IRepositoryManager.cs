namespace Mindmath.Domain.Repository
{
	public interface IRepositoryManager
	{
		ISubjectRepository Subjects { get; }
		IChapterRepository Chapters { get; }
		Task Save();
	}
}
