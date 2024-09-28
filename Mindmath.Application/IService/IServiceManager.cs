using Mindmath.Application.Subjects;
using Mindmath.Application.Users;

namespace Mindmath.Application.IService
{
	public interface IServiceManager
	{
		ISubjectService SubjectService { get; }
		IAuthenticationService AuthenticationService { get; }
	}
}
