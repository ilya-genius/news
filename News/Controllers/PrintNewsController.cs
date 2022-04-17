using Microsoft.AspNetCore.Mvc;
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
    public class PrintNewsController : Controller
    {
        private readonly IAllNews _allNews;
        private AppDBContent db;

        public PrintNewsController(AppDBContent context,IAllNews IallNews)
        {
            _allNews = IallNews;
            db = context;
        }

        public ViewResult Index()
        {
            var allNews = new PrintNewsViewModel
            {
                allNews=_allNews.News
            };
            return View(allNews);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PieceOfNews news)
        {
            if (ModelState.IsValid)
            {
                    db.PieceOfNews.Add(news);
                    await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                PieceOfNews news = await db.PieceOfNews.FirstOrDefaultAsync(p => p.id == id);
                if (news != null)
                    return View(news);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PieceOfNews news)
        {
            if (ModelState.IsValid)
            {
                db.PieceOfNews.Update(news);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                PieceOfNews news = await db.PieceOfNews.FirstOrDefaultAsync(p => p.id == id);
                if (news != null)
                    return View(news);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                PieceOfNews news = await db.PieceOfNews.FirstOrDefaultAsync(p => p.id == id);
                if (news != null)
                {
                    db.PieceOfNews.Remove(news);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
