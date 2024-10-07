using AutoMapper;
using Mindmath.Repository.IRepository;
using Mindmath.Service.Wallets.DTO;

namespace Mindmath.Service.Wallets
{
	internal sealed class WalletService : IWalletService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;

		public WalletService(IRepositoryManager repositoryManager, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
		}

		public async Task<WalletReturnDto> GetWalletByUserId(string userId, bool trackChange)
		{
			var wallet = await repositoryManager.Wallets.GetWalletByUserId(userId, trackChange);
			return mapper.Map<WalletReturnDto>(wallet);
		}
	}
}
