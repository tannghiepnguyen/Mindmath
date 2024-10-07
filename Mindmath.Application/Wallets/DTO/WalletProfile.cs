using AutoMapper;
using Mindmath.Repository.Models;

namespace Mindmath.Service.Wallets.DTO
{
	public class WalletProfile : Profile
	{
		public WalletProfile()
		{
			CreateMap<Wallet, WalletReturnDto>();
		}
	}
}
