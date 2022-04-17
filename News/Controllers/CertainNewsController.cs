using Microsoft.AspNetCore.Mvc;
using News.Data.Interfaces;
using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class CertainNewsController : Controller
    {
        private readonly INewsSubtitles _newsSubtitles;
        private readonly IAllNews _oneNews;

        public CertainNewsController(INewsSubtitles InewsSubtitles, IAllNews IoneNews)
        {
            _newsSubtitles = InewsSubtitles;
            _oneNews = IoneNews;
        }
        public ViewResult Print(int id)
        {
            var certainNews = new CertainNewsViewModel
            {
                oneNews = _oneNews.News.FirstOrDefault(i => i.id==id),
                allSubtitles = _newsSubtitles.AllSubtitles.Where(i=>i.PieceOfNewsID==id)
            };
            return View(certainNews);
        }

    }
}
