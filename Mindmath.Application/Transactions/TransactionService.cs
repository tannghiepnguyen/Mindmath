using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Mindmath.Repository.Exceptions;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Service.Transactions.DTO;

namespace Mindmath.Service.Transactions
{
	internal sealed class TransactionService : ITransactionService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;

		public TransactionService(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
			this.userManager = userManager;
		}

		private async Task CheckUserExist(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			if (user == null) throw new UserNotFoundException(userId);
		}

		public async Task<IEnumerable<TransactionReturnDto>> GetTransactions(bool trackChange)
		{
			var transactions = await repositoryManager.Transactions.GetTransactions(trackChange);
			return mapper.Map<IEnumerable<TransactionReturnDto>>(transactions);
		}

		public async Task<IEnumerable<TransactionReturnDto>> GetTransactionsByUserId(string userId, bool trackChange)
		{
			var transactions = await repositoryManager.Transactions.GetTransactionsByUserId(userId, trackChange);
			return mapper.Map<IEnumerable<TransactionReturnDto>>(transactions);
		}
	}
}
