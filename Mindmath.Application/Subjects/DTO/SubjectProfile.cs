using AutoMapper;
using Mindmath.Domain.Models;

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
