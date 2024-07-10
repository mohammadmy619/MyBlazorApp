using Application.DTOs.Paging;
using Application.DTOs;
using AutoMapper;
using Domin.entites;
using Domin.Entites;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IService;

namespace Application.ImplementServices
{
    public class NewsService : INewsService
    {
        #region constructor

        private readonly INewsRepository _NewsRepository;
        private readonly IMapper _mapper;

        public NewsService(INewsRepository NewsRepository, IMapper mapper)
        {
            _NewsRepository = NewsRepository;
            _mapper = mapper;
        }

        #endregion


        public async Task<NewsDTO> CreateNews(NewsDTO newsDTO)
        {
            var news = _mapper.Map<NewsDTO, News>(newsDTO);
            news.CreatedBy = "";
            news.CreateDate = DateTime.Now;
            var addedNews = await _NewsRepository.CreateNews(news);
            return _mapper.Map<News, NewsDTO>(addedNews);
        }

        public async Task<NewsDTO> UpdateNews(int newsId, NewsDTO newsDTO)
        {
            try
            {
                if (newsId == newsDTO.NewsId)
                {
                    News newsDetail = await _NewsRepository.UpdateNews(newsId,null);
               
                    return _mapper.Map<News, NewsDTO>(newsDetail);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<NewsDTO> GetNewsById(int newsId)
        {
            try
            {
                NewsDTO news = _mapper.Map<News, NewsDTO>(await _NewsRepository.GetNewsById(newsId));
                return news;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<NewsDTO>> GetAllNewses()
        {
            try
            {
                IEnumerable<NewsDTO> newsDTOs = _mapper.Map<IEnumerable<News>, IEnumerable<NewsDTO>>(await _NewsRepository.GetAllNewses());
                return newsDTOs;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<IEnumerable<NewsDTO>> GetAllNewsesByCount(int count)
        {
            try
            {
                var data = await _NewsRepository
                    .GetQuery()
                    .OrderByDescending(s => s.CreateDate)
                    .Take(count)
                    .ToListAsync();
                IEnumerable<NewsDTO> newsDTOs = _mapper.Map<IEnumerable<News>, IEnumerable<NewsDTO>>(data);
                return newsDTOs;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<NewsDTO> IsNewsExistsByTitle(string title, int newsId)
        {
            return _mapper.Map<News, NewsDTO>(await _NewsRepository.GetQuery().FirstOrDefaultAsync(s => s.Title == title && s.NewsId != newsId));
        }

        public async Task<int> RemoveNews(int newsId)
        {
            var news = await _NewsRepository.GetNewsById(newsId);
            if (news != null)
            {
             await   _NewsRepository.RemoveNews(news);
                

                return news.NewsId;
            }

            return 0;
        }

        public async Task<int> RemoveNews(NewsDTO news)
        {
            return await RemoveNews(news.NewsId);
        }

        public async Task<FilterNewsesDTO> FilterNewses(FilterNewsesDTO filter)
        {
            var query = _NewsRepository.GetQuery().AsQueryable();

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(s => EF.Functions.Like(s.Title, $"%{filter.Title}%"));
            }

            var allEntitiesCount = await query.CountAsync();

            var pager = Pager.Build(filter.Page, filter.Take, allEntitiesCount, filter.HowManyShowAfterBefore);

            var newses = await query.Paging(pager).ToListAsync();

            filter.Newses = _mapper.Map<List<News>, List<NewsDTO>>(newses);

            return filter.SetPaging(pager);
        }
    }
}
