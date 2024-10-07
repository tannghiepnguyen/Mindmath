using AutoMapper;
using Mindmath.Repository.Models;

namespace Mindmath.Service.Transactions.DTO
{
	public class TransactionProfile : Profile
	{
		public TransactionProfile()
		{
			CreateMap<Transaction, TransactionReturnDto>();
		}
	}
}
