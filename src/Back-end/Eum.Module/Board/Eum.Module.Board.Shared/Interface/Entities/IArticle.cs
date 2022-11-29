using System;
using Eum.Shared.Common.Interfaces;

namespace Eum.Module.Board.Shared.Interfaces
{
	public interface IArticle : IEntity
    {
		
		public string Subject { get; set; }
		public string Content { get; set; }
	}
}

