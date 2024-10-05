using Microsoft.AspNetCore.Mvc;
using Mindmath.Service.IService;
using Mindmath.Service.Topics.DTO;

namespace Mindmath.API.Controllers
{
	[Route("api/chapters/{chapterId:guid}/topics")]
	[ApiController]
	public class TopicsController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public TopicsController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] TopicForCreationDto topicForCreationDto, [FromRoute] Guid chapterId)
		{
			if (topicForCreationDto is null) return BadRequest();
			var topicDto = await serviceManager.TopicService.CreateTopic(chapterId, topicForCreationDto, trackChange: false);
			return CreatedAtRoute("TopicById", new { topicId = topicDto.Id, chapterId }, topicDto);
		}

		[HttpGet]
		public async Task<IActionResult> GetAll([FromRoute] Guid chapterId)
		{
			var topics = await serviceManager.TopicService.GetTopics(chapterId, trackChange: false);
			return Ok(topics);
		}

		[HttpGet("active")]
		public async Task<IActionResult> GetActive([FromRoute] Guid chapterId)
		{
			var topics = await serviceManager.TopicService.GetActiveTopics(chapterId, trackChange: false);
			return Ok(topics);
		}

		[HttpGet("{topicId:guid}", Name = "TopicById")]
		public async Task<IActionResult> GetById([FromRoute] Guid topicId, [FromRoute] Guid chapterId)
		{
			var topic = await serviceManager.TopicService.GetTopic(chapterId, topicId, trackChange: false);
			return Ok(topic);
		}

		[HttpPut("{topicId:guid}")]
		public async Task<IActionResult> Update([FromRoute] Guid topicId, [FromBody] TopicForUpdateDto topicForUpdate, [FromRoute] Guid chapterId)
		{
			await serviceManager.TopicService.UpdateTopic(chapterId, topicId, topicForUpdate, chapterTrackChange: false, topicTrackChange: true);
			return NoContent();
		}
	}
}
