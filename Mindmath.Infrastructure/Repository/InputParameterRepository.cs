using Microsoft.EntityFrameworkCore;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
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

		public async Task<IEnumerable<InputParameter>> GetActiveInputParameters(string userId, Guid problemTypeId, bool trackChange) =>
			await FindByCondition(x => x.UserId == userId && x.ProblemTypeId == problemTypeId && x.Active, trackChange).ToListAsync();

		public async Task<InputParameter?> GetInputParameter(string userId, Guid problemTypeId, Guid inputParameterId, bool trackChange) =>
			await FindByCondition(x => x.UserId == userId && x.ProblemTypeId == problemTypeId && x.Id == inputParameterId, trackChange).SingleOrDefaultAsync();

		public async Task<InputParameter?> GetInputParameter(Guid inputParameterId, bool trackChange) => await FindByCondition(x => x.Id == inputParameterId, trackChange).SingleOrDefaultAsync();

		public async Task<IEnumerable<InputParameter>> GetInputParameters(string userId, Guid problemTypeId, bool trackChange) =>
			await FindByCondition(x => x.UserId == userId && x.ProblemTypeId == problemTypeId, trackChange).ToListAsync();
	}
}
