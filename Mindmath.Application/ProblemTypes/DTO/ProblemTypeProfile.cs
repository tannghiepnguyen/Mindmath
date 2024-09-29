using AutoMapper;
using Mindmath.Domain.Models;

namespace Mindmath.Application.ProblemTypes.DTO
{
	public class ProblemTypeProfile : Profile
	{
		public ProblemTypeProfile()
		{
			CreateMap<ProblemType, ProblemTypeReturnDto>();
			CreateMap<ProblemTypeForCreationDto, ProblemType>();
			CreateMap<ProblemTypeForUpdateDto, ProblemType>();
		}
	}
}
