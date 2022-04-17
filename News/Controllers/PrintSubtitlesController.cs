using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using News.Data;
using News.Data.Interfaces;
using News.Data.Models;
using News.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    public class PrintSubtitlesController : Controller
    {
        private readonly IAllNews _allNews;
        private readonly INewsSubtitles _allSubtitles;
        private AppDBContent db;

        public PrintSubtitlesController(AppDBContent context, IAllNews IallNews, INewsSubtitles IallSubtitles)
        {
            _allSubtitles = IallSubtitles;
            _allNews = IallNews;
            db = context;
        }

        public ViewResult Index()
        { 
            var allNews = new PrintSubtitlesViewModel
            {
                allSubtitles = _allSubtitles.AllSubtitles,
                allNews=_allNews.News
            };
            return View(allNews);
        }

        public IActionResult Create()
        {
            ViewBag.SelectItems = new SelectList(_allNews.News, "id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Subtitles subtitles)
        {
            if (ModelState.IsValid)
            {
                db.Subtitles.Add(subtitles);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.SelectItems = new SelectList(_allNews.News,"id","Title");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Subtitles subtitles = await db.Subtitles.FirstOrDefaultAsync(p => p.id == id);
                ViewBag.SelectItems = new SelectList(_allNews.News, "id", "Title",_allNews.News.FirstOrDefault());
                if (subtitles != null)
                    return View(subtitles);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Subtitles subtitles)
        {
            if (ModelState.IsValid)
            {
                db.Subtitles.Update(subtitles);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.SelectItems = new SelectList(_allNews.News, "id", "Title", _allNews.News.FirstOrDefault());
            }
            return View(subtitles);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Subtitles subtitles = await db.Subtitles.FirstOrDefaultAsync(p => p.id == id);
                if (subtitles != null)
                    return View(subtitles);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Subtitles subtitles = await db.Subtitles.FirstOrDefaultAsync(p => p.id == id);
                if (subtitles != null)
                {
                    db.Subtitles.Remove(subtitles);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
