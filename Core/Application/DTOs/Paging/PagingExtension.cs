using System.Linq;

namespace Application.DTOs.Paging
{
    public static class PagingExtension
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> queryable, BasePaging paging)
        {
            return queryable.Skip(paging.Skip).Take(paging.Take);
        }
    }
}
