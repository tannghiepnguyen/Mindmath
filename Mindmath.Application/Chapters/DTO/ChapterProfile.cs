using AutoMapper;
using Mindmath.Domain.Models;

namespace Mindmath.Application.Chapters.DTO
{
	public class ChapterProfile : Profile
	{
		public ChapterProfile()
		{
			CreateMap<ChapterForCreationDto, Chapter>();
			CreateMap<ChapterForUpdateDto, Chapter>();
			CreateMap<Chapter, ChapterReturnDto>();

		}
	}
}
