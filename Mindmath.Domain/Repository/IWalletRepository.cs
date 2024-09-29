using Mindmath.Domain.Models;

namespace Mindmath.Domain.Repository
{
	public interface IWalletRepository
	{
		Task<Wallet?> GetWalletByUserId(string userId, bool trackChange);
		void CreateWallet(Wallet wallet);
	}
}
