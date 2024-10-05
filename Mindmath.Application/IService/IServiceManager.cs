using Mindmath.Service.Chapters;
using Mindmath.Service.InputParameters;
using Mindmath.Service.ProblemTypes;
using Mindmath.Service.Subjects;
using Mindmath.Service.Topics;
using Mindmath.Service.Users;

namespace Mindmath.Service.IService
{
	public interface IServiceManager
	{
		ISubjectService SubjectService { get; }
		IChapterService ChapterService { get; }
		IAuthenticationService AuthenticationService { get; }
		ITopicService TopicService { get; }
		IProblemTypeService ProblemTypeService { get; }
		IInputParameterService InputParameterService { get; }
	}
}
