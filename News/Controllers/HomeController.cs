using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using News.Data.Interfaces;
using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsSubtitles _newsSubtitles;
        private readonly IAllNews _allNews;

        public HomeController(INewsSubtitles InewsSubtitles, IAllNews IallNews)
        {
            _newsSubtitles = InewsSubtitles;
            _allNews = IallNews;
        }

        public ViewResult Index()
        {
            var homeNews = new HomeViewModel
            {
                lastNews = _allNews.GetLastNews,
                allSubtitles=_newsSubtitles.AllSubtitles
            };
            return View(homeNews);
        }

        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            return LocalRedirect(returnUrl);
        }
    }
}
