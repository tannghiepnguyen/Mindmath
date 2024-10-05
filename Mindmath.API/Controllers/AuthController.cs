using Microsoft.AspNetCore.Mvc;
using Mindmath.Service.IService;
using Mindmath.Service.Users.DTO;

namespace Mindmath.API.Controllers
{
	[Route("api/auths")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public AuthController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpPost("register")]
		public IActionResult Register([FromBody] UserForRegistrationDTO userForRegistrationDTO)
		{
			var result = serviceManager.AuthenticationService.RegisterUser(userForRegistrationDTO);

			if (!result.Result.Succeeded)
			{
				foreach (var error in result.Result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}

			return StatusCode(201);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDTO userForAuthenticationDTO)
		{
			if (!await serviceManager.AuthenticationService.ValidateUser(userForAuthenticationDTO))
			{
				return Unauthorized();
			}

			return Ok(new { Token = serviceManager.AuthenticationService.CreateToken() });
		}
	}
}
