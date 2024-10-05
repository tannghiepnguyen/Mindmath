namespace Mindmath.Repository.Exceptions
{
	public class TopicNotFoundException : NotFoundException
	{
		public TopicNotFoundException(Guid topicId) : base($"The topic with id: {topicId} doesn't exist in the database")
		{
		}
	}
}
