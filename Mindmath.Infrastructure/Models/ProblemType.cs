using System.ComponentModel.DataAnnotations;

namespace Mindmath.Repository.Models
{
	public class ProblemType
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public DateTime? DeletedAt { get; set; }
		public int NumberOfInputs { get; set; }
		public bool Active { get; set; }
		public Guid? TopicId { get; set; }
		public Topic Topic { get; set; }
		public ICollection<InputParameter> InputParameters { get; set; } = new List<InputParameter>();
	}
}
