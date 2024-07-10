using Domin.entites;
using Domin.Entites;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _DbContext;
        public NewsRepository(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }
        public async Task<News> CreateNews(News news)
        {
            await _DbContext.Newses.AddAsync(news);
            _DbContext.SaveChanges();
            return news;
        }

        public async Task<IEnumerable<News>> GetAllNewses()
        {
            return await _DbContext.Newses.ToListAsync();
        }

        public async Task<IEnumerable<News>> GetAllNewsesByCount(int count)
        {
            return await _DbContext.Newses.Take(count).ToListAsync();
        }

        public async Task<News> GetNewsById(int newsId)
        {
            return await _DbContext.Newses.Where(n => n.NewsId == newsId).FirstOrDefaultAsync();

        }

        public IQueryable<News> GetQuery()
        {
            return _DbContext.Newses.AsQueryable();
           
        }

        public async Task<News> IsNewsExistsByTitle(string title, int newsId)
        {
            return await _DbContext.Newses.Where(n=>n.NewsId==newsId && n.Title==title).FirstOrDefaultAsync();
        }

        public async Task<int> RemoveNews(int newsId)
        {
            var res = await _DbContext.Newses.FindAsync(newsId);
            if (res != null)
            {
                _DbContext.Newses.Remove(res);
                await _DbContext.SaveChangesAsync();

                return res.NewsId;
            }

            return 0;
         
        }

        public async Task<int> RemoveNews(News news)
        {
            return await RemoveNews(news.NewsId);
        }

        public async Task<News> UpdateNews(int newsId, News? news)
        {
            try
            {
                if (newsId == news.NewsId)
                {
                    News newsDetail = await _DbContext.Newses.FindAsync(newsId);
                    news.EditedBy = "";
                    _DbContext.Newses.Update(news);
                    await _DbContext.SaveChangesAsync();
                    return newsDetail;
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
    }
}
