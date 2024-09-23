using AutoMapper;
using Mindmath.Domain.Models;

namespace Mindmath.Application.Users.DTO
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserForRegistrationDTO, User>();
		}
	}
}
