using Mindmath.Repository.Models;

namespace Mindmath.Repository.IRepository
{
	public interface IWalletRepository
	{
		Task<Wallet?> GetWalletByUserId(string userId, bool trackChange);
		void CreateWallet(Wallet wallet);
	}
}
