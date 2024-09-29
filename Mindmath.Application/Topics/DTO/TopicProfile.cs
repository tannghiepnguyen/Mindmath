using AutoMapper;
using Mindmath.Domain.Models;

namespace Mindmath.Application.Topics.DTO
{
	public class TopicProfile : Profile
	{
		public TopicProfile()
		{
			CreateMap<Topic, TopicReturnDto>();
			CreateMap<TopicForCreationDto, Topic>();
			CreateMap<TopicForUpdateDto, Topic>();
		}
	}
}
