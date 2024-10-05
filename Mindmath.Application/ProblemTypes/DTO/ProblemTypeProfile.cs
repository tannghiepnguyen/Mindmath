using AutoMapper;
using Mindmath.Repository.Models;
using Mindmath.Service.ProblemTypes.DTO;

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
