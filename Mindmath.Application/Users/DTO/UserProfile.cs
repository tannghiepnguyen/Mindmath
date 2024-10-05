using AutoMapper;
using Mindmath.Repository.Models;

namespace Mindmath.Service.Users.DTO
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserForRegistrationDTO, User>();
			CreateMap<UserForUpdateDto, User>();
			CreateMap<User, UserReturnDto>();
		}
	}
}
