using Microsoft.AspNetCore.Mvc;
using News.Data.Interfaces;
using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class SubtitlesController : Controller
    {
        private readonly INewsSubtitles _newsSubtitles;
        private readonly IAllNews _allNews;

        public SubtitlesController(INewsSubtitles InewsSubtitles, IAllNews  IallNews)
        {
            _newsSubtitles = InewsSubtitles;
            _allNews = IallNews;
        }

        public ViewResult ResultSubtitles()
        {
            SubtitlesResultViewModel obj = new SubtitlesResultViewModel();
            obj.allSubtitles = _newsSubtitles.AllSubtitles;
            obj.allNews = _allNews.News;
            return View(obj);
        }
    }
}
