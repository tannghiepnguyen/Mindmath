using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Mindmath.Application.Chapters;
using Mindmath.Application.IService;
using Mindmath.Application.Subjects;
using Mindmath.Application.Topics;
using Mindmath.Application.Users;
using Mindmath.Domain.Models;
using Mindmath.Domain.Repository;

namespace Mindmath.Application.Service
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<IAuthenticationService> authenticationService;
		private readonly Lazy<ISubjectService> subjectService;
		private readonly Lazy<IChapterService> chapterService;
		private readonly Lazy<ITopicService> topicService;
		public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, mapper, configuration, roleManager));
			subjectService = new Lazy<ISubjectService>(() => new SubjectService(repositoryManager, mapper));
			chapterService = new Lazy<IChapterService>(() => new ChapterService(repositoryManager, mapper));
			topicService = new Lazy<ITopicService>(() => new TopicService(repositoryManager, mapper));
		}
		public IAuthenticationService AuthenticationService => authenticationService.Value;

		public ISubjectService SubjectService => subjectService.Value;

		public IChapterService ChapterService => chapterService.Value;

		public ITopicService TopicService => topicService.Value;
	}
}
