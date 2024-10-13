using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mindmath.Repository.Constant;
using Mindmath.Service.IService;
using Mindmath.Service.Subjects.DTO;

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
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> Add([FromBody] SubjectForCreationDto subjectForCreationDto)
		{
			if (subjectForCreationDto is null) return BadRequest();
			var subjectDto = await serviceManager.SubjectService.CreateSubject(subjectForCreationDto);
			return CreatedAtRoute("SubjectById", new { subjectId = subjectDto.Id }, subjectDto);
		}

		[HttpGet]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> GetAll()
		{
			var subjects = await serviceManager.SubjectService.GetSubjects(trackChange: false);
			return Ok(subjects);
		}

		[HttpGet("{subjectId:guid}", Name = "SubjectById")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> GetById(Guid subjectId)
		{
			var subject = await serviceManager.SubjectService.GetSubject(subjectId, trackChange: false);
			return Ok(subject);
		}

		[HttpGet("active")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> GetActive()
		{
			var activeSubjects = await serviceManager.SubjectService.GetActiveSubjects(trackChange: false);
			return Ok(activeSubjects);
		}

		[HttpPut("{subjectId:guid}")]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> Update(Guid subjectId, [FromBody] SubjectForUpdateDto subjectForUpdate)
		{
			await serviceManager.SubjectService.UpdateSubject(subjectId, subjectForUpdate, trackChange: true);
			return NoContent();
		}
	}
}
