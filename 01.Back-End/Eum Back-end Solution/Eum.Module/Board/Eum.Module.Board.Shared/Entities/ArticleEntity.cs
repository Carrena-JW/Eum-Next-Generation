using System;
using Eum.Module.Board.Shared.Interfaces;

namespace Eum.Module.Board.Shared.Entities
{
	public class ArticleEntity : IArticle
    {
        public int Id { get; set; }
        public string Subject { get; set; }
    }
}


 