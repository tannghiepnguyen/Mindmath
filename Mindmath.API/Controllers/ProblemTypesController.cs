using Microsoft.AspNetCore.Mvc;
using Mindmath.Application.IService;
using Mindmath.Application.ProblemTypes.DTO;

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
		public async Task<IActionResult> GetProblemTypes(Guid topicId)
		{
			var problemTypes = await serviceManager.ProblemTypeService.GetProblemTypes(topicId, trackChange: false);
			return Ok(problemTypes);
		}

		[HttpGet("active")]
		public async Task<IActionResult> GetActiveProblemTypes(Guid topicId)
		{
			var problemTypes = await serviceManager.ProblemTypeService.GetActiveProblemTypes(topicId, trackChange: false);
			return Ok(problemTypes);
		}

		[HttpGet("{problemTypeId:guid}", Name = "ProblemTypeById")]
		public async Task<IActionResult> GetProblemType(Guid topicId, Guid problemTypeId)
		{
			var problemType = await serviceManager.ProblemTypeService.GetProblemType(topicId, problemTypeId, trackChange: false);
			return Ok(problemType);
		}

		[HttpPost]
		public async Task<IActionResult> AddProblemType(Guid topicId, [FromBody] ProblemTypeForCreationDto problemTypeForCreation)
		{
			if (problemTypeForCreation is null) return BadRequest();
			var problemType = await serviceManager.ProblemTypeService.CreateProblemType(topicId, problemTypeForCreation, trackChange: false);
			return CreatedAtRoute("ProblemTypeById", new { problemTypeId = problemType.Id, topicId = Guid.Empty }, problemType);
		}

		[HttpPut("{problemTypeId:guid}")]
		public async Task<IActionResult> UpdateProblemType(Guid topicId, Guid problemTypeId, [FromBody] ProblemTypeForUpdateDto problemTypeForUpdate)
		{
			await serviceManager.ProblemTypeService.UpdateProblemType(topicId, problemTypeId, problemTypeForUpdate, topicTrackChange: false, problemTypeTrackChange: true);
			return NoContent();
		}


	}
}
