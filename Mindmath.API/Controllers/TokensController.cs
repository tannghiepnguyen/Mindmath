using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mindmath.Repository.Constant;
using Mindmath.Service.IService;
using Mindmath.Service.Users.DTO;

namespace Mindmath.API.Controllers
{
	[Route("api/tokens")]
	[ApiController]
	public class TokensController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public TokensController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpPost]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
		{
			var tokenDtoToReturn = await this.serviceManager.AuthenticationService.RefreshToken(tokenDto);

			return Ok(tokenDtoToReturn);
		}
	}
}
