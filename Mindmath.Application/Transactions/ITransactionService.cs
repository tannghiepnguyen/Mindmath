using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mindmath.Service.Transactions.DTO;

namespace Mindmath.Service.Transactions
{
	public interface ITransactionService
	{
		Task<IEnumerable<TransactionReturnDto>> GetTransactions(bool trackChange);
		Task<IEnumerable<TransactionReturnDto>> GetTransactionsByUserId(string userId, bool trackChange);
        Task<string> CreatePaymentAsync(Guid userId, TransactionReturnDto transactionDto);
        Task<IActionResult> IPNAsync(IQueryCollection query);
    }
}
