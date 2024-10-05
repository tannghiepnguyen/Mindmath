﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Mindmath.Application.Users;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Service.Chapters;
using Mindmath.Service.InputParameters;
using Mindmath.Service.IService;
using Mindmath.Service.ProblemTypes;
using Mindmath.Service.Subjects;
using Mindmath.Service.Topics;
using Mindmath.Service.Users;

namespace Mindmath.Service.Service
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<IAuthenticationService> authenticationService;
		private readonly Lazy<ISubjectService> subjectService;
		private readonly Lazy<IChapterService> chapterService;
		private readonly Lazy<ITopicService> topicService;
		private readonly Lazy<IProblemTypeService> problemTypeService;
		private readonly Lazy<IInputParameterService> inputParameterService;
		public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, mapper, configuration, roleManager, repositoryManager));
			subjectService = new Lazy<ISubjectService>(() => new SubjectService(repositoryManager, mapper));
			chapterService = new Lazy<IChapterService>(() => new ChapterService(repositoryManager, mapper));
			topicService = new Lazy<ITopicService>(() => new TopicService(repositoryManager, mapper));
			problemTypeService = new Lazy<IProblemTypeService>(() => new ProblemTypeService(repositoryManager, mapper));
			inputParameterService = new Lazy<IInputParameterService>(() => new InputParameterService(repositoryManager, mapper, userManager, configuration));
		}
		public IAuthenticationService AuthenticationService => authenticationService.Value;

		public ISubjectService SubjectService => subjectService.Value;

		public IChapterService ChapterService => chapterService.Value;

		public ITopicService TopicService => topicService.Value;

		public IProblemTypeService ProblemTypeService => problemTypeService.Value;

		public IInputParameterService InputParameterService => inputParameterService.Value;
	}
}
