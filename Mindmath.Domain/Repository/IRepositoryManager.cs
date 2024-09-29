namespace Mindmath.Domain.Repository
{
	public interface IRepositoryManager
	{
		ISubjectRepository Subjects { get; }
		IChapterRepository Chapters { get; }
		ITopicRepository Topics { get; }
		IProblemTypeRepository ProblemTypes { get; }
		Task Save();
	}
}
