using Microsoft.AspNetCore.Mvc;
using Mindmath.Service.Chapters.DTO;
using Mindmath.Service.IService;

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
		public async Task<IActionResult> Add([FromBody] ChapterForCreationDto chapterForCreationDto, [FromRoute] Guid subjectId)
		{
			if (chapterForCreationDto is null) return BadRequest();
			var chapterDto = await serviceManager.ChapterService.CreateChapter(subjectId, chapterForCreationDto, trackChange: false);
			return CreatedAtRoute("ChapterById", new { chapterId = chapterDto.Id, subjectId }, chapterDto);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromRoute] Guid subjectId)
		{
			var chapters = await serviceManager.ChapterService.GetChapters(subjectId, trackChange: false);
			return Ok(chapters);
		}

		[HttpGet("active")]
		public async Task<IActionResult> GetActive([FromRoute] Guid subjectId)
		{
			var chapters = await serviceManager.ChapterService.GetActiveChapters(subjectId, trackChange: false);
			return Ok(chapters);
		}

		[HttpGet("{chapterId:guid}", Name = "ChapterById")]
		public async Task<IActionResult> GetById([FromRoute] Guid chapterId, [FromRoute] Guid subjectId)
		{
			var chapter = await serviceManager.ChapterService.GetChapter(subjectId, chapterId, trackChange: false);
			return Ok(chapter);
		}

		[HttpPut("{chapterId:guid}")]
		public async Task<IActionResult> Update([FromRoute] Guid chapterId, [FromBody] ChapterForUpdateDto chapterForUpdate, [FromRoute] Guid subjectId)
		{
			await serviceManager.ChapterService.UpdateChapter(subjectId, chapterId, chapterForUpdate, chapterTrackChange: true, subjectTrackChange: false);
			return NoContent();
		}


	}
}
