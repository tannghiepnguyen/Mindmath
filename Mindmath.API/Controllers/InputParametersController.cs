using Microsoft.AspNetCore.Mvc;
using Mindmath.Service.InputParameters.DTO;
using Mindmath.Service.IService;

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
		public async Task<IActionResult> CreateInputParameter([FromRoute] string userId, [FromRoute] Guid problemTypeId, [FromBody] InputParameterForCreationDto inputParameterForCreationDto)
		{
			if (inputParameterForCreationDto is null) return BadRequest();
			var inputParameterDto = await serviceManager.InputParameterService.CreateInputParameter(inputParameterForCreationDto, problemTypeId, userId, trackChange: false);
			return CreatedAtRoute("InputParameterById", new { problemTypeId, userId, inputParameterId = inputParameterDto.Id }, inputParameterDto);
		}

		[HttpGet("{inputParameterId:guid}", Name = "InputParameterById")]
		public async Task<IActionResult> GetInputParameter([FromRoute] Guid inputParameterId, [FromRoute] Guid problemTypeId, [FromRoute] string userId)
		{
			var inputParameterDto = await serviceManager.InputParameterService.GetInputParameter(problemTypeId, userId, inputParameterId, trackChange: false);
			return Ok(inputParameterDto);
		}

		[HttpGet]
		public async Task<IActionResult> GetInputParameters([FromRoute] string userId, [FromRoute] Guid problemTypeId)
		{
			var inputParametersDto = await serviceManager.InputParameterService.GetInputParameters(problemTypeId, userId, trackChange: false);
			return Ok(inputParametersDto);
		}

		[HttpGet("active")]
		public async Task<IActionResult> GetActiveInputParameters([FromRoute] string userId, [FromRoute] Guid problemTypeId)
		{
			var inputParametersDto = await serviceManager.InputParameterService.GetActiveInputParameters(problemTypeId, userId, trackChange: false);
			return Ok(inputParametersDto);
		}

		[HttpPut("{inputParameterId:guid}")]
		public async Task<IActionResult> UpdateInputParameter([FromRoute] string userId, [FromRoute] Guid problemTypeId, [FromRoute] Guid inputParameterId, [FromBody] InputParameterForUpdateDto inputParameterForUpdateDto)
		{
			await serviceManager.InputParameterService.UpdateInputParameter(problemTypeId, userId, inputParameterId, inputParameterForUpdateDto, inputParameterTrackChange: true, problemTypeTrackChange: false);
			return NoContent();
		}
	}
}
