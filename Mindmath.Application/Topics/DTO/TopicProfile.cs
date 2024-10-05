using AutoMapper;
using Mindmath.Repository.Models;
using Mindmath.Service.Topics.DTO;

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
