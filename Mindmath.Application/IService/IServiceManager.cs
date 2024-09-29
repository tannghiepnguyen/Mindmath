using Mindmath.Application.Chapters;
using Mindmath.Application.Subjects;
using Mindmath.Application.Topics;
using Mindmath.Application.Users;

namespace Mindmath.Application.IService
{
	public interface IServiceManager
	{
		ISubjectService SubjectService { get; }
		IChapterService ChapterService { get; }
		IAuthenticationService AuthenticationService { get; }
		ITopicService TopicService { get; }
	}
}
