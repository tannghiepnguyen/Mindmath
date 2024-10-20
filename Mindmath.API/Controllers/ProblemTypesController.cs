using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mindmath.Repository.Constant;
using Mindmath.Repository.Parameters;
using Mindmath.Service.IService;
using Mindmath.Service.ProblemTypes.DTO;
using System.Text.Json;

namespace Mindmath.API.Controllers
{
	[Route("api/topics/{topicId:guid}/problem-types")]
	[ApiController]
	public class ProblemTypesController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public ProblemTypesController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> GetProblemTypes([FromRoute] Guid topicId, [FromQuery] ProblemTypeParameters problemTypeParameters)
		{
			var problemTypes = await serviceManager.ProblemTypeService.GetProblemTypes(topicId, problemTypeParameters, trackChange: false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(problemTypes.metaData));
			return Ok(problemTypes.problemTypes);
		}

		[HttpGet("active")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> GetActiveProblemTypes([FromRoute] Guid topicId, [FromQuery] ProblemTypeParameters problemTypeParameters)
		{
			var problemTypes = await serviceManager.ProblemTypeService.GetActiveProblemTypes(topicId, problemTypeParameters, trackChange: false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(problemTypes.metaData));
			return Ok(problemTypes.problemTypes);
		}

		[HttpGet("{problemTypeId:guid}", Name = "ProblemTypeById")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> GetProblemType([FromRoute] Guid topicId, [FromRoute] Guid problemTypeId)
		{
			var problemType = await serviceManager.ProblemTypeService.GetProblemType(topicId, problemTypeId, trackChange: false);
			return Ok(problemType);
		}

		[HttpPost]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> AddProblemType([FromRoute] Guid topicId, [FromBody] ProblemTypeForCreationDto problemTypeForCreation)
		{
			if (problemTypeForCreation is null) return BadRequest();
			var problemType = await serviceManager.ProblemTypeService.CreateProblemType(topicId, problemTypeForCreation, trackChange: false);
			return CreatedAtRoute("ProblemTypeById", new { problemTypeId = problemType.Id, topicId }, problemType);
		}

		[HttpPut("{problemTypeId:guid}")]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> UpdateProblemType(Guid topicId, Guid problemTypeId, [FromBody] ProblemTypeForUpdateDto problemTypeForUpdate)
		{
			await serviceManager.ProblemTypeService.UpdateProblemType(topicId, problemTypeId, problemTypeForUpdate, topicTrackChange: false, problemTypeTrackChange: true);
			return NoContent();
		}


	}
}
