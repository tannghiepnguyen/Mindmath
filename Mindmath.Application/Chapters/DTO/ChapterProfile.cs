using AutoMapper;
using Mindmath.Repository.Models;
using Mindmath.Service.Chapters.DTO;

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
