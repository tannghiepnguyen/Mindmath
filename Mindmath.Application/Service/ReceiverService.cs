using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Mindmath.Service.IService;
using StackExchange.Redis;

namespace Mindmath.Service.Service
{
	public class ReceiverService : BackgroundService, IReceiverService
	{
		private readonly string ConnectionString;
		private readonly IConnectionMultiplexer Connection;
		private readonly RedisChannel Channel;
		private readonly IConfiguration _configuration;
		//private const string Channel = "Channel1";

		public ReceiverService(IConfiguration configuration)
		{
			_configuration = configuration;
			ConnectionString = _configuration.GetSection("Redis").GetSection("ConnectionString").Value;
			Connection = ConnectionMultiplexer.Connect(ConnectionString);
			Channel = new RedisChannel(_configuration.GetSection("Redis").GetSection("Channel1").Value, RedisChannel.PatternMode.Literal);
		}

		public string ReceiveMessage()
		{
			throw new NotImplementedException();
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var subscriber = Connection.GetSubscriber();

			await subscriber.SubscribeAsync(Channel, (channel, message) =>
			{
				Guid inputParameterId = Guid.Parse(message.ToString().Split(";")[0]);
				string userId = message.ToString().Split(";")[1];
				string solutionLink = message.ToString().Split(";")[2];


			});
		}
	}
}
