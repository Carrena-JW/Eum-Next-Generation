﻿using System;
using AutoMapper;
using Eum.Module.Board.Shared.Response.DTO;
using Eum.Module.Board.Shared.Entities;

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

