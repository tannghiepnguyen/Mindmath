using AutoMapper;
using Mindmath.Repository.Models;
using Mindmath.Service.Subjects.DTO;

namespace Mindmath.Application.Subjects.DTO
{
	public class SubjectProfile : Profile
	{
		public SubjectProfile()
		{
			CreateMap<SubjectForCreationDto, Subject>();
			CreateMap<SubjectForUpdateDto, Subject>();
			CreateMap<Subject, SubjectReturnDto>();
		}
	}
}
