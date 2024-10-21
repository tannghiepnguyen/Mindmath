using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Mindmath.Repository.Exceptions;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
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

		public async Task<(IEnumerable<TransactionReturnDto> transactions, MetaData metaData)> GetTransactions(TransactionParameters transactionParameters, bool trackChange)
		{
			var transactionsMetaData = await repositoryManager.Transactions.GetTransactions(transactionParameters, trackChange);
			var transactions = mapper.Map<IEnumerable<TransactionReturnDto>>(transactionsMetaData);
			return (transactions, transactionsMetaData.MetaData);
		}

		public async Task<(IEnumerable<TransactionReturnDto> transactions, MetaData metaData)> GetTransactionsByUserId(string userId, TransactionParameters transactionParameters, bool trackChange)
		{
			var transactionsMetaData = await repositoryManager.Transactions.GetTransactionsByUserId(userId, transactionParameters, trackChange);
			var transactions = mapper.Map<IEnumerable<TransactionReturnDto>>(transactionsMetaData);
			return (transactions, transactionsMetaData.MetaData);
		}
	}
}
