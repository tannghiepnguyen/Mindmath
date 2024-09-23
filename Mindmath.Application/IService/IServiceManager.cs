using Mindmath.Application.Users;

namespace Mindmath.Application.IService
{
	public interface IServiceManager
	{
		IAuthenticationService AuthenticationService { get; }
	}
}
