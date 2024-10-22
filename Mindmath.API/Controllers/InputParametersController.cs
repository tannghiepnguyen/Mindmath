using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mindmath.Repository.Constant;
using Mindmath.Repository.Parameters;
using Mindmath.Service.InputParameters.DTO;
using Mindmath.Service.IService;
using System.Text.Json;

namespace Mindmath.API.Controllers
{
	[Route("api/problem-types/{problemTypeId:guid}/users/{userId}/input-parameters")]
	[ApiController]
	public class InputParametersController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public InputParametersController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpPost]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> CreateInputParameter([FromRoute] string userId, [FromRoute] Guid problemTypeId, [FromBody] InputParameterForCreationDto inputParameterForCreationDto)
		{
			if (inputParameterForCreationDto is null) return BadRequest();
			var inputParameterDto = await serviceManager.InputParameterService.CreateInputParameter(inputParameterForCreationDto, problemTypeId, userId, trackChange: false);
			return CreatedAtRoute("InputParameterById", new { problemTypeId, userId, inputParameterId = inputParameterDto.Id }, inputParameterDto);
		}

		[HttpGet("{inputParameterId:guid}", Name = "InputParameterById")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> GetInputParameter([FromRoute] Guid inputParameterId, [FromRoute] Guid problemTypeId, [FromRoute] string userId)
		{
			var inputParameterDto = await serviceManager.InputParameterService.GetInputParameter(problemTypeId, userId, inputParameterId, trackChange: false);
			return Ok(inputParameterDto);
		}

		[HttpGet]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> GetInputParameters([FromRoute] string userId, [FromRoute] Guid problemTypeId, [FromQuery] InputParameterParameters inputParameterParameters)
		{
			var inputParametersDto = await serviceManager.InputParameterService.GetInputParameters(problemTypeId, userId, inputParameterParameters, trackChange: false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(inputParametersDto.metaData));
			return Ok(inputParametersDto.inputParameters);
		}

		[HttpGet("active")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> GetActiveInputParameters([FromRoute] string userId, [FromRoute] Guid problemTypeId, [FromQuery] InputParameterParameters inputParameterParameters)
		{
			var inputParametersDto = await serviceManager.InputParameterService.GetActiveInputParameters(problemTypeId, userId, inputParameterParameters, trackChange: false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(inputParametersDto.metaData));
			return Ok(inputParametersDto.inputParameters);
		}

		[HttpDelete("{inputParameterId:guid}")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> UpdateInputParameter([FromRoute] string userId, [FromRoute] Guid problemTypeId, [FromRoute] Guid inputParameterId)
		{
			await serviceManager.InputParameterService.DeleteInputParameter(problemTypeId, userId, inputParameterId, inputParameterTrackChange: true, problemTypeTrackChange: false);
			return NoContent();
		}
	}
}
