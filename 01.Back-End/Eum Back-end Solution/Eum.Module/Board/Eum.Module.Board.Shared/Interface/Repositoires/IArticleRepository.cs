using System;
using Eum.Module.Board.Shared.Interfaces;
using Eum.Shared.Common.Interfaces;

namespace Eum.Module.Board.Shared.Interface.Repositoires
{
	public interface IArticleRepository<T> : IRepository<T> where T : IArticle   
    {
	}
}

