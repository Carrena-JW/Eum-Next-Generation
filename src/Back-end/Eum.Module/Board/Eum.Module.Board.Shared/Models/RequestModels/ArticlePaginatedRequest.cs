using Eum.Shared.Common.Models.CommonRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eum.Module.Board.Shared.Models.RequestModels
{
    public class ArticlePaginatedRequest : PaginatedRequestModels
    {
        public bool IncludeContents { get; set; } = false;
    }
}
