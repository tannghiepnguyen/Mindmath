namespace Mindmath.Domain.Repository
{
	public interface IRepositoryManager
	{
		ISubjectRepository Subjects { get; }
		Task Save();
	}
}
