using Microsoft.EntityFrameworkCore;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.Persistence;
using Mindmath.Repository.Repository;

namespace Mindmath.Infrastructure.Repository
{
	internal sealed class WalletRepository : RepositoryBase<Wallet>, IWalletRepository
	{
		public WalletRepository(MindmathDbContext context) : base(context)
		{
		}

		public void CreateWallet(Wallet wallet) => Create(wallet);

		public async Task<Wallet?> GetWalletByUserId(string userId, bool trackChange) => await
			FindByCondition(w => w.UserId == userId, trackChange).SingleOrDefaultAsync();
	}
}
