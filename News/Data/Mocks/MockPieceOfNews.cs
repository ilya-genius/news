using News.Data.Interfaces;
using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data.Mocks
{
    public class MockPieceOfNews : IAllNews
    {
        public IEnumerable<PieceOfNews> News
        {
            get
            {
                return new List<PieceOfNews>
                {
                    new PieceOfNews { Title="Новость 1"},
                    new PieceOfNews { Title="Новость 2"}    
                };
            }
        }

        IEnumerable<PieceOfNews> IAllNews.GetLastNews => throw new NotImplementedException();
    }
}
