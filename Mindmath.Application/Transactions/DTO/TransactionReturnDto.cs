using Mindmath.Repository.Models;

namespace Mindmath.Service.Transactions.DTO
{
	public record TransactionReturnDto
	{
		public Guid Id { get; init; }
		public double Amount { get; init; }
		public string Description { get; init; }
		public User User { get; init; }
	}
}
