﻿namespace Mindmath.Service.ProblemTypes.DTO
{
	public record ProblemTypeForUpdateDto
	{
		public string Name { get; init; }
		public string Description { get; init; }
		public bool Active { get; init; }
		public int NumberOfInputs { get; init; }
	}
}
