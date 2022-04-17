using News.Data.Interfaces;
using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data.Mocks
{
    public class MockSubtitles : INewsSubtitles
    {
        private readonly IAllNews _subtitlesNews = new MockPieceOfNews();

        public IEnumerable<Subtitles> AllSubtitles
        {
            get
            {
                return new List<Subtitles>
                {
                    new Subtitles { subtitle = "Подзаголовок у 1 новости ", text="Текст 1", PieceOfNews = _subtitlesNews.News.ElementAt(0)},
                    new Subtitles { subtitle = "Подзаголовок у 1 новости ", text="Текст 2", PieceOfNews = _subtitlesNews.News.ElementAt(0)},
                    new Subtitles { subtitle = "Подзаголовок у 2 новости ", text="Текст 3", PieceOfNews = _subtitlesNews.News.ElementAt(1)}
                };
            }
        }
    }
}
