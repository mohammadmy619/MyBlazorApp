using Application.DTOs;
using AutoMapper;
using Domin.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class NewsMapper : Profile
    {
        public NewsMapper()
        {
            CreateMap<NewsDTO, News>();
            CreateMap<News, NewsDTO>();
        }
    }
}
