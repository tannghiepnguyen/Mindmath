using Microsoft.AspNetCore.Mvc;
using Mindmath.Application.IService;
using Mindmath.Application.Subjects.DTO;

namespace Mindmath.API.Controllers
{
	[Route("api/subjects")]
	[ApiController]
	public class SubjectsController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public SubjectsController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] SubjectForCreationDto subjectForCreationDto)
		{
			if (subjectForCreationDto is null) return BadRequest();
			var subjectDto = await serviceManager.SubjectService.CreateSubject(subjectForCreationDto);
			return CreatedAtRoute("SubjectById", new { subjectId = subjectDto.Id }, subjectDto);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var subjects = await serviceManager.SubjectService.GetSubjects(trackChange: false);
			return Ok(subjects);
		}

		[HttpGet("{subjectId:guid}", Name = "SubjectById")]
		public async Task<IActionResult> GetById(Guid subjectId)
		{
			var subject = await serviceManager.SubjectService.GetSubject(subjectId, trackChange: false);
			return Ok(subject);
		}

		[HttpGet("active")]
		public async Task<IActionResult> GetActive()
		{
			var activeSubjects = await serviceManager.SubjectService.GetActiveSubjects(trackChange: false);
			return Ok(activeSubjects);
		}

		[HttpPut("{subjectId:guid}")]
		public async Task<IActionResult> Update(Guid subjectId, [FromBody] SubjectForUpdateDto subjectForUpdate)
		{
			await serviceManager.SubjectService.UpdateSubject(subjectId, subjectForUpdate, trackChange: true);
			return NoContent();
		}
	}
}
