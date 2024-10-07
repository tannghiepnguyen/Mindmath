using Microsoft.AspNetCore.Mvc;
using Mindmath.Service.IService;

namespace Mindmath.API.Controllers
{
	[Route("api/solutions")]
	[ApiController]
	public class SolutionsController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public SolutionsController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet("{inputParameterId:guid}")]
		public async Task<IActionResult> GetSolutionByInputParameterId([FromRoute] Guid inputParameterId)
		{
			var solution = await serviceManager.SolutionService.GetSolutionByInputParameterId(inputParameterId, trackChange: false);
			return Ok(solution);
		}
	}
}
