using News.Data.Interfaces;
using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data.Repository
{
    public class PieceOfNewsRepository : IAllNews
    {
        private readonly AppDBContent appDBContent;

        public PieceOfNewsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<PieceOfNews> News => appDBContent.PieceOfNews;

        public IEnumerable<PieceOfNews> GetLastNews => appDBContent.PieceOfNews.OrderByDescending(x => x.id).Take(2);
    }
}
