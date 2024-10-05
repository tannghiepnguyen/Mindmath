using AutoMapper;
using Mindmath.Repository.Models;
using Mindmath.Service.InputParameters.DTO;

namespace Mindmath.Application.InputParameters.DTO
{
	public class InputParameterProfile : Profile
	{
		public InputParameterProfile()
		{
			CreateMap<InputParameterForCreationDto, InputParameter>();
			CreateMap<InputParameterForUpdateDto, InputParameter>();
			CreateMap<InputParameter, InputParameterReturnDto>();
		}
	}
}
