using Microsoft.AspNetCore.Mvc;
using Mindmath.Service.IService;

namespace Mindmath.API.Controllers
{
	[Route("api/wallets")]
	[ApiController]
	public class WalletsController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public WalletsController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetWalletByUserId([FromRoute] string userId)
		{
			var wallets = await serviceManager.WalletService.GetWalletByUserId(userId, trackChange: false);
			return Ok(wallets);
		}
	}
}
