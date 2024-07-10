using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface INewsService
    {
        public Task<NewsDTO> CreateNews(NewsDTO newsDTO);
        public Task<NewsDTO> UpdateNews(int newsId, NewsDTO newsDTO);
        public Task<NewsDTO> GetNewsById(int newsId);
        public Task<IEnumerable<NewsDTO>> GetAllNewses();
        public Task<IEnumerable<NewsDTO>> GetAllNewsesByCount(int count);
        public Task<NewsDTO> IsNewsExistsByTitle(string title, int newsId);
        public Task<int> RemoveNews(int newsId);
        public Task<int> RemoveNews(NewsDTO news);
        public Task<FilterNewsesDTO> FilterNewses(FilterNewsesDTO filter);
    }
}
