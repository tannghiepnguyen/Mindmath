namespace Mindmath.Service.Transactions.DTO
{
	public record TransactionForCreationDto
	{
		public double Amount { get; init; }
		public string Description { get; init; }
	}
}
