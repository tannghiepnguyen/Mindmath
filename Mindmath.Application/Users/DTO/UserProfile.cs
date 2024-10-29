using AutoMapper;
using Mindmath.Repository.Models;

namespace Mindmath.Service.Users.DTO
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserForRegistrationDTO, User>();
			CreateMap<UserForUpdateDto, User>().ForSourceMember(c => c.File, opt => opt.DoNotValidate());
			CreateMap<User, UserReturnDto>();
		}
	}
}
