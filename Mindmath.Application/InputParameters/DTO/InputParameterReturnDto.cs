namespace Mindmath.Service.InputParameters.DTO
{
	public record InputParameterReturnDto
	{
		public Guid Id { get; init; }
		public string Input { get; init; }
		public bool Active { get; init; }
	}
}
