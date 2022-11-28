using System;
namespace Eum.Module.Board.Shared.Response.DTO
{
	public record ResponseArticleDTO
	{
		public int Id { get; set; }
		public string Subject { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
	}
}

