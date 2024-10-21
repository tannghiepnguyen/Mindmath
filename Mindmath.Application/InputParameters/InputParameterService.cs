using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Mindmath.Repository.Exceptions;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.InputParameters.DTO;
using StackExchange.Redis;

namespace Mindmath.Service.InputParameters
{
	internal sealed class InputParameterService : IInputParameterService
	{
		private readonly string RedisConnectionString;
		private readonly ConnectionMultiplexer Connection;
		private readonly RedisChannel Channel;

		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;
		private readonly IConfiguration configuration;

		public InputParameterService(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
			this.userManager = userManager;
			this.configuration = configuration;

			RedisConnectionString = configuration.GetSection("Redis").GetSection("ConnectionString").Value;
			Connection = ConnectionMultiplexer.Connect(RedisConnectionString);
			Channel = new RedisChannel(configuration.GetSection("Redis").GetSection("Channel1").Value, RedisChannel.PatternMode.Literal);
		}

		private async Task CheckUserExist(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			if (user == null) throw new UserNotFoundException(userId);
		}

		private async Task CheckProblemTypeExist(Guid problemTypeId, bool trackChange)
		{
			var problemType = await repositoryManager.ProblemTypes.GetProblemType(problemTypeId, trackChange);
			if (problemType == null) throw new ProblemTypeNotFoundException(problemTypeId);
		}

		public async Task<InputParameterReturnDto> CreateInputParameter(InputParameterForCreationDto inputParameter, Guid problemTypeId, string userId, bool trackChange)
		{
			await CheckUserExist(userId);
			await CheckProblemTypeExist(problemTypeId, trackChange);

			var inputParameterEntity = mapper.Map<InputParameter>(inputParameter);
			inputParameterEntity.Id = Guid.NewGuid();
			inputParameterEntity.CreatedAt = DateTime.Now;
			inputParameterEntity.UpdateAt = DateTime.Now;
			inputParameterEntity.Active = true;
			inputParameterEntity.ProblemTypeId = problemTypeId;
			inputParameterEntity.UserId = userId;

			var problemTypeName = (await repositoryManager.ProblemTypes.GetProblemType(problemTypeId, trackChange)).Name;


			var subscriber = Connection.GetSubscriber();
			var inputParameterJson = $"{problemTypeId.ToString()};{problemTypeName};{inputParameterEntity.Input};{userId}";

			RedisValue redisValue = new RedisValue(inputParameterJson);
			await subscriber.PublishAsync(Channel, redisValue);

			repositoryManager.InputParameters.CreateInputParameter(inputParameterEntity);
			await repositoryManager.Save();
			return mapper.Map<InputParameterReturnDto>(inputParameterEntity);
		}

		public async Task UpdateInputParameter(Guid problemTypeId, string userId, Guid inputParameterId, InputParameterForUpdateDto inputParameter, bool inputParameterTrackChange, bool problemTypeTrackChange)
		{
			await CheckUserExist(userId);
			await CheckProblemTypeExist(problemTypeId, problemTypeTrackChange);

			var inputParameterEntity = await repositoryManager.InputParameters.GetInputParameter(userId, problemTypeId, inputParameterId, inputParameterTrackChange);
			if (inputParameterEntity == null) throw new InputParameterNotFoundException(inputParameterId);

			mapper.Map(inputParameter, inputParameterEntity);
			inputParameterEntity.UpdateAt = DateTime.Now;

			await repositoryManager.Save();
		}

		public async Task<InputParameterReturnDto?> GetInputParameter(Guid problemTypeId, string userId, Guid inputParameterId, bool trackChange)
		{
			await CheckUserExist(userId);
			await CheckProblemTypeExist(problemTypeId, trackChange);

			var inputParameterEntity = await repositoryManager.InputParameters.GetInputParameter(userId, problemTypeId, inputParameterId, trackChange);
			if (inputParameterEntity == null) throw new InputParameterNotFoundException(inputParameterId);

			return mapper.Map<InputParameterReturnDto>(inputParameterEntity);
		}

		public async Task<(IEnumerable<InputParameterReturnDto> inputParameters, MetaData metaData)> GetInputParameters(Guid problemTypeId, string userId, InputParameterParameters inputParameterParameters, bool trackChange)
		{
			await CheckUserExist(userId);
			await CheckProblemTypeExist(problemTypeId, trackChange);

			var inputParametersMetaData = await repositoryManager.InputParameters.GetInputParameters(userId, problemTypeId, inputParameterParameters, trackChange);
			var inputParameters = mapper.Map<IEnumerable<InputParameterReturnDto>>(inputParametersMetaData);
			return (inputParameters, inputParametersMetaData.MetaData);
		}

		public async Task<(IEnumerable<InputParameterReturnDto> inputParameters, MetaData metaData)> GetActiveInputParameters(Guid problemTypeId, string userId, InputParameterParameters inputParameterParameters, bool trackChange)
		{
			await CheckUserExist(userId);
			await CheckProblemTypeExist(problemTypeId, trackChange);

			var inputParametersMetaData = await repositoryManager.InputParameters.GetActiveInputParameters(userId, problemTypeId, inputParameterParameters, trackChange);
			var inputParameters = mapper.Map<IEnumerable<InputParameterReturnDto>>(inputParametersMetaData);
			return (inputParameters, inputParametersMetaData.MetaData);
		}
	}
}
