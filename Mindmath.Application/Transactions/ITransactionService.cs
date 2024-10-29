using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mindmath.Repository.PagedList;
using Mindmath.Repository.Parameters;
using Mindmath.Service.Transactions.DTO;

namespace Mindmath.Service.Transactions
{
	public interface ITransactionService
	{
		Task<string> CreatePaymentAsync(Guid userId, TransactionForCreationDto transactionDto);
		Task<IActionResult> IPNAsync(IQueryCollection query);
		Task<(IEnumerable<TransactionReturnDto> transactions, MetaData metaData)> GetTransactions(TransactionParameters transactionParameters, bool trackChange);
		Task<(IEnumerable<TransactionReturnDto> transactions, MetaData metaData)> GetTransactionsByUserId(string userId, TransactionParameters transactionParameters, bool trackChange);
    }
}
