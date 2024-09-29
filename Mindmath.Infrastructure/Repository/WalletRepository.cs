using Microsoft.EntityFrameworkCore;
using Mindmath.Domain.Models;
using Mindmath.Domain.Repository;
using Mindmath.Infrastructure.Persistence;

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
