using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mindmath.Repository.Constant;
using Mindmath.Repository.Parameters;
using Mindmath.Service.Chapters.DTO;
using Mindmath.Service.IService;
using System.Text.Json;

namespace Mindmath.API.Controllers
{
	[Route("api/subjects/{subjectId:guid}/chapters")]
	[ApiController]
	public class ChaptersController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public ChaptersController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}
		[HttpPost]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> Add([FromBody] ChapterForCreationDto chapterForCreationDto, [FromRoute] Guid subjectId)
		{
			if (chapterForCreationDto is null) return BadRequest();
			var chapterDto = await serviceManager.ChapterService.CreateChapter(subjectId, chapterForCreationDto, trackChange: false);
			return CreatedAtRoute("ChapterById", new { chapterId = chapterDto.Id, subjectId }, chapterDto);
		}

		[HttpGet]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> GetAll([FromRoute] Guid subjectId, [FromQuery] ChapterParameters chapterParameters)
		{
			var chapters = await serviceManager.ChapterService.GetChapters(subjectId, chapterParameters, trackChange: false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(chapters.metaData));
			return Ok(chapters.chapters);
		}

		[HttpGet("active")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> GetActive([FromRoute] Guid subjectId, [FromQuery] ChapterParameters chapterParameters)
		{
			var chapters = await serviceManager.ChapterService.GetActiveChapters(subjectId, chapterParameters, trackChange: false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(chapters.metaData));
			return Ok(chapters.chapters);
		}

		[HttpGet("{chapterId:guid}", Name = "ChapterById")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> GetById([FromRoute] Guid chapterId, [FromRoute] Guid subjectId)
		{
			var chapter = await serviceManager.ChapterService.GetChapter(subjectId, chapterId, trackChange: false);
			return Ok(chapter);
		}

		[HttpPut("{chapterId:guid}")]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> Update([FromRoute] Guid chapterId, [FromBody] ChapterForUpdateDto chapterForUpdate, [FromRoute] Guid subjectId)
		{
			await serviceManager.ChapterService.UpdateChapter(subjectId, chapterId, chapterForUpdate, chapterTrackChange: true, subjectTrackChange: false);
			return NoContent();
		}

		[HttpDelete("{chapterId:guid}")]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> Delete([FromRoute] Guid chapterId, [FromRoute] Guid subjectId)
		{
			await serviceManager.ChapterService.DeleteChapter(subjectId, chapterId, chapterTrackChange: true, subjectTrackChange: false);
			return NoContent();
		}
	}
}
