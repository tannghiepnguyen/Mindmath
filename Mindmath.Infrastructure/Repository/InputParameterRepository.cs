using Microsoft.EntityFrameworkCore;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Repository.Persistence;
using Mindmath.Repository.Repository;

namespace Mindmath.Infrastructure.Repository
{
	internal sealed class InputParameterRepository : RepositoryBase<InputParameter>, IInputParameterRepository
	{
		public InputParameterRepository(MindmathDbContext context) : base(context)
		{
		}

		public void CreateInputParameter(InputParameter inputParameter) => Create(inputParameter);

		public async Task<PagedList<InputParameter>> GetActiveInputParameters(string userId, Guid problemTypeId, InputParameterParameters inputParameterParameters, bool trackChange)
		{
			var inputParameters = FindByCondition(x => x.UserId == userId && x.ProblemTypeId == problemTypeId && x.Active, trackChange);
			return PagedList<InputParameter>.ToPagedList(inputParameters, inputParameterParameters.PageNumber, inputParameterParameters.PageSize);
		}

		public async Task<InputParameter?> GetInputParameter(string userId, Guid problemTypeId, Guid inputParameterId, bool trackChange) =>
			await FindByCondition(x => x.UserId == userId && x.ProblemTypeId == problemTypeId && x.Id == inputParameterId, trackChange).SingleOrDefaultAsync();

		public async Task<InputParameter?> GetInputParameter(Guid inputParameterId, bool trackChange) => await FindByCondition(x => x.Id == inputParameterId, trackChange).SingleOrDefaultAsync();

		public async Task<PagedList<InputParameter>> GetInputParameters(string userId, Guid problemTypeId, InputParameterParameters inputParameterParameters, bool trackChange)
		{
			var inputParameters = FindByCondition(x => x.UserId == userId && x.ProblemTypeId == problemTypeId, trackChange);
			return PagedList<InputParameter>.ToPagedList(inputParameters, inputParameterParameters.PageNumber, inputParameterParameters.PageSize);
		}
	}
}
