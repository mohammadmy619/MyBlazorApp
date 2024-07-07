using System;

namespace Application.DTOs.Paging
{
    public class Pager
    {
        public static BasePaging Build(int page, int take, int allEntitiesCount, int howManyShowAfterBefore)
        {
            var allPageCount = (int)Math.Ceiling(allEntitiesCount / (double)take);
            return new BasePaging
            {
                Page = page,
                Take = take,
                Skip = (page - 1) * take,
                HowManyShowAfterBefore = howManyShowAfterBefore,
                AllEntitiesCount = allEntitiesCount,
                AllPageCount = allPageCount,
                StartPage = page > howManyShowAfterBefore ? page - howManyShowAfterBefore : 1,
                EndPage = page + howManyShowAfterBefore > allPageCount ? allPageCount : page + howManyShowAfterBefore
            };
        }
    }
}
