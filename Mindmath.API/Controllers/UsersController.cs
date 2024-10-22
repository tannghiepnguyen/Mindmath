using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mindmath.Repository.Constant;
using Mindmath.Repository.Parameters;
using Mindmath.Service.IService;
using Mindmath.Service.Users.DTO;
using System.Text.Json;

namespace Mindmath.API.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public UsersController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> GetUsers([FromQuery] UserParameters userParameters)
		{
			var users = await serviceManager.AuthenticationService.GetUsers(userParameters);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(users.MetaData));
			return Ok(users.users);
		}

		[HttpGet("{id}")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> GetUserById(string id)
		{
			var user = await serviceManager.AuthenticationService.GetUserById(id);
			return Ok(user);
		}

		[HttpPut("{userId}")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> UpdateUser([FromRoute] string userId, [FromBody] UserForUpdateDto userForRegistrationDTO)
		{
			var result = await serviceManager.AuthenticationService.UpdateUser(userId, userForRegistrationDTO);

			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}

			return NoContent();
		}

		[HttpPut("{userId}/password")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> UpdateUserPassword([FromRoute] string userId, [FromBody] UserForUpdatePasswordDto userForUpdatePasswordDto)
		{
			var result = await serviceManager.AuthenticationService.UpdateUserPassword(userId, userForUpdatePasswordDto);

			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}

			return NoContent();
		}

		[HttpDelete("{userId}")]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> DeleteUser(string userId)
		{
			var result = await serviceManager.AuthenticationService.DeleteUser(userId);

			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}

			return NoContent();
		}
	}
}
