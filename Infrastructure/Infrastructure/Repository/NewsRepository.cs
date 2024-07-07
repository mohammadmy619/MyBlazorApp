using Domin.entites;
using Domin.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class NewsRepository : INewsRepository
    {
        public Task<News> CreateNews(News newsDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<News>> GetAllNewses()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<News>> GetAllNewsesByCount(int count)
        {
            throw new NotImplementedException();
        }

        public Task<News> GetNewsById(int newsId)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<News>> GetQuery()
        {
            throw new NotImplementedException();
        }

        public Task<News> IsNewsExistsByTitle(string title, int newsId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveNews(int newsId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveNews(News news)
        {
            throw new NotImplementedException();
        }

        public Task<News> UpdateNews(int newsId, News newsDTO)
        {
            throw new NotImplementedException();
        }
    }
}
