using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mindmath.Repository.Constant;
using Mindmath.Service.IService;

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
		public async Task<IActionResult> GetTransactions()
		{
			var transactions = await serviceManager.TransactionService.GetTransactions(false);
			return Ok(transactions);
		}

		[HttpGet("{userId}")]
		[Authorize(Roles = Roles.Teacher)]
		public async Task<IActionResult> GetTransactionsByUserId(string userId)
		{
			var transactions = await serviceManager.TransactionService.GetTransactionsByUserId(userId, false);
			return Ok(transactions);
		}
	}
}
