using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mindmath.Repository.IRepository;
using Mindmath.Repository.Models;
using Mindmath.Service.IService;
using StackExchange.Redis;

namespace Mindmath.Service.Service
{
	public class ReceiverService : BackgroundService, IReceiverService
	{
		private readonly string ConnectionString;
		private readonly IConnectionMultiplexer Connection;
		private readonly RedisChannel Channel;
		private readonly IConfiguration configuration;
		private readonly IServiceScopeFactory serviceScopeFactory;

		//private const string Channel = "Channel1";

		public ReceiverService(IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
		{
			this.configuration = configuration;
			this.serviceScopeFactory = serviceScopeFactory;
			ConnectionString = this.configuration.GetSection("Redis").GetSection("ConnectionString").Value;
			Connection = ConnectionMultiplexer.Connect(ConnectionString);
			Channel = new RedisChannel(this.configuration.GetSection("Redis").GetSection("Channel2").Value, RedisChannel.PatternMode.Literal);
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var subscriber = Connection.GetSubscriber();

			await subscriber.SubscribeAsync(Channel, async (channel, message) =>
			{
				Guid inputParameterId = Guid.Parse(message.ToString().Split(";")[0]);
				string userId = message.ToString().Split(";")[1];
				string solutionLink = message.ToString().Split(";")[2];

				Transaction transaction = new Transaction()
				{
					Id = Guid.NewGuid(),
					Amount = 10000,
					Description = $"Transaction for generating for input parameter {inputParameterId}",
					CreatedAt = DateTime.Now,
					Status = "Success",
					UserId = userId
				};

				Solution solution = new Solution()
				{
					Id = Guid.NewGuid(),
					Link = solutionLink,
					Description = $"Solution for input parameter {inputParameterId}",
					CreatedAt = DateTime.Now,
					UpdatedAt = DateTime.Now,
					Active = true,
					InputParameterId = inputParameterId,
					TransactionId = transaction.Id
				};

				using (var scope = serviceScopeFactory.CreateScope())
				{
					var repositoryManager = scope.ServiceProvider.GetRequiredService<IRepositoryManager>();

					repositoryManager.Solutions.CreateSolution(solution);
					repositoryManager.Transactions.CreateTransaction(transaction);

					var wallet = await repositoryManager.Wallets.GetWalletByUserId(userId, trackChange: true);
					wallet.Balance -= transaction.Amount;

					await repositoryManager.Save();
				}
			});
		}
	}
}
