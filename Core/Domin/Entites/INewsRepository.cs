using Domin.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entites
{
    public interface INewsRepository
    {
        public Task<News> CreateNews(News newsDTO);
        public Task<News> UpdateNews(int newsId, News newsDTO);
        public Task<News> GetNewsById(int newsId);
        public Task<IEnumerable<News>> GetAllNewses();
        public Task<IQueryable<News>> GetQuery();
        public Task<IEnumerable<News>> GetAllNewsesByCount(int count);
        public Task<News> IsNewsExistsByTitle(string title, int newsId);
        public Task<int> RemoveNews(int newsId);
        public Task<int> RemoveNews(News news);
    }
}
