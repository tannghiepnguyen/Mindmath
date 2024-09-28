using Microsoft.AspNetCore.Mvc;
using Mindmath.Application.IService;
using Mindmath.Application.Subjects.DTO;

namespace Mindmath.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubjectController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public SubjectController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] SubjectForCreationDto subjectForCreationDto)
		{
			if (subjectForCreationDto is null) return BadRequest();
			var subjectDto = await serviceManager.SubjectService.CreateSubject(subjectForCreationDto);
			return CreatedAtRoute("SubjectById", new { id = subjectDto.Id }, subjectDto);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll(bool trackChange = false)
		{
			var subjects = await serviceManager.SubjectService.GetSubjects(trackChange);
			return Ok(subjects);
		}

		[HttpGet("{id}", Name = "SubjectById")]
		public async Task<IActionResult> GetById(Guid id, bool trackChange = false)
		{
			var subject = await serviceManager.SubjectService.GetSubject(id, trackChange);
			return Ok(subject);
		}

		[HttpGet("active")]
		public async Task<IActionResult> GetActive(bool trackChange = false)
		{
			var activeSubjects = await serviceManager.SubjectService.GetActiveSubjects(trackChange);
			return Ok(activeSubjects);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] SubjectForUpdateDto subjectForUpdate, bool trackChange = true)
		{
			await serviceManager.SubjectService.UpdateSubject(id, subjectForUpdate, trackChange);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id, bool trackChange = false)
		{
			await serviceManager.SubjectService.DeleteSubject(id, trackChange);
			return NoContent();
		}
	}
}
