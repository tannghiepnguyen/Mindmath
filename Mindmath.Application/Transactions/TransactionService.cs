using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
		private readonly IConfiguration configuration;
		private readonly Utils utils;

		public TransactionService(IRepositoryManager repositoryManager, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, Utils utils)
		{
			this.repositoryManager = repositoryManager;
			this.mapper = mapper;
			this.userManager = userManager;
			this.configuration = configuration;
			this.utils = utils;
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

		public async Task<string> CreatePaymentAsync(Guid userId, TransactionForCreationDto transactionDto)
		{
			var transaction = mapper.Map<Transaction>(transactionDto);
			transaction.Id = Guid.NewGuid();
			transaction.CreatedAt = DateTime.Now;
			transaction.Type = "Deposit";
			transaction.Status = "Pending";

			await repositoryManager.Transactions.AddTransactionAsync(transaction);

			// Tạo URL thanh toán VNPay
			var vnpay = new VnPayLibrary();
			vnpay.AddRequestData("vnp_Version", "2.1.0");
			vnpay.AddRequestData("vnp_Command", "pay");
			vnpay.AddRequestData("vnp_TmnCode", configuration.GetSection("VNPay").GetSection("TmnCode").Value);
			vnpay.AddRequestData("vnp_Amount", (transactionDto.Amount * 100).ToString());
			vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
			vnpay.AddRequestData("vnp_CurrCode", "VND");
			vnpay.AddRequestData("vnp_IpAddr", utils.GetIpAddress());
			vnpay.AddRequestData("vnp_Locale", "vn");
			vnpay.AddRequestData("vnp_OrderInfo", $"Payment for order {transaction.Id}");
			vnpay.AddRequestData("vnp_ReturnUrl", configuration.GetSection("VNPay").GetSection("ReturnUrl").Value);
			vnpay.AddRequestData("vnp_TxnRef", transaction.Id.ToString());
			var paymentUrl = vnpay.CreateRequestUrl(configuration.GetSection("VNPay").GetSection("Url").Value, configuration.GetSection("VNPay").GetSection("HashSecret").Value);
			return paymentUrl; // Redirect to this URL for payment
		}

		public async Task<IActionResult> IPNAsync(IQueryCollection query)
		{
			var vnpay = new VnPayLibrary();
			foreach (var key in query.Keys)
			{
				if (key.StartsWith("vnp_"))
				{
					vnpay.AddResponseData(key, query[key]);
				}
			}

			var vnpSecureHash = query["vnp_SecureHash"];
			var isValid = vnpay.ValidateSignature(vnpSecureHash, configuration.GetSection("VNPay").GetSection("HashSecret").Value);

			if (!isValid)
			{
				return new JsonResult(new { RspCode = "97", Message = "Invalid signature" });
			}

			// Validate and update transaction status
			var transactionId = Guid.Parse(vnpay.GetResponseData("vnp_TxnRef"));
			var amount = long.Parse(vnpay.GetResponseData("vnp_Amount")) / 100;
			var responseCode = vnpay.GetResponseData("vnp_ResponseCode");
			var transaction = await repositoryManager.Transactions.GetTransactionByIdAsync(transactionId);

			if (transaction == null)
			{
				return new JsonResult(new { RspCode = "01", Message = "Order not found" });
			}

			// Update transaction status based on response code
			if (responseCode == "00")
			{
				transaction.Status = "Success"; // Update to success
			}
			else
			{
				transaction.Status = "Failed"; // Update to failed
			}

			// Save changes to database
			await repositoryManager.Transactions.AddTransactionAsync(transaction);

			return new JsonResult(new { RspCode = "00", Message = "Confirm Success" });
		}
	}
}
