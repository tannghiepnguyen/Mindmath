namespace Mindmath.Repository.Exceptions
{
	public class InputParameterNotFoundException : NotFoundException
	{
		public InputParameterNotFoundException(Guid inputParameterId) : base($"The input parameter with id: {inputParameterId} doesn't exist in the database")
		{
		}
	}
}
