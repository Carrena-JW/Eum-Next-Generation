using System;
namespace Eum.Common.Interfaces
{
	public interface IEntity
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public string CreatedId { get; set; }
		public string UpdatedId { get; set; }
	}
}

