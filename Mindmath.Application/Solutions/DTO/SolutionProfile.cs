using AutoMapper;
using Mindmath.Repository.Models;
using Mindmath.Service.Solutions.DTO;

namespace Mindmath.Application.Solutions.DTO
{
	public class SolutionProfile : Profile
	{
		public SolutionProfile()
		{
			CreateMap<Solution, SolutionReturnDto>();
		}
	}
}
