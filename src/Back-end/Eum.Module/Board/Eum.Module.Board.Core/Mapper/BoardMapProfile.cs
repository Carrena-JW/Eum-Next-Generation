

namespace Eum.Module.Board.Core.Mapper
{
    public class BoardMapProfile : Profile
    {
		public BoardMapProfile()
		{
            CreateMap<ArticleEntity, ArticleReponseDTO>();
        }
	}
}

