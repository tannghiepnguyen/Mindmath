using Mindmath.Service.Wallets.DTO;

namespace Mindmath.Service.Wallets
{
	public interface IWalletService
	{
		Task<WalletReturnDto> GetWalletByUserId(string userId, bool trackChange);
	}
}
