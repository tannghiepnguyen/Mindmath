namespace Mindmath.Service.Transactions.DTO
{
	public record TransactionReturnDto
	{
		public Guid Id { get; init; }
		public double Amount { get; init; }
		public string Description { get; init; }
		public string Type { get; init; }
		public DateTime CreateAt { get; init; }
		public string Status { get; init; }
	}
}
