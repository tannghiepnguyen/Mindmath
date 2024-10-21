using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mindmath.Repository.Constant;
using Mindmath.Repository.Parameters;
using Mindmath.Service.IService;
using System.Text.Json;

namespace Mindmath.API.Controllers
{
	[Route("api/transactions")]
	[ApiController]
	public class TransactionsController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public TransactionsController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet]
		[Authorize(Roles = Roles.Admin)]
		public async Task<IActionResult> GetTransactions([FromQuery] TransactionParameters transactionParameters)
		{
			var transactions = await serviceManager.TransactionService.GetTransactions(transactionParameters, false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(transactions.metaData));
			return Ok(transactions.transactions);
		}

		[HttpGet("{userId}")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> GetTransactionsByUserId([FromRoute] string userId, [FromQuery] TransactionParameters transactionParameters)
		{
			var transactions = await serviceManager.TransactionService.GetTransactionsByUserId(userId, transactionParameters, false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(transactions.metaData));
			return Ok(transactions.transactions);
		}
	}
}
