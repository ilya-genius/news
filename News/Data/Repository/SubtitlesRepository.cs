using Microsoft.EntityFrameworkCore;
using News.Data.Interfaces;
using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data.Repository
{
    public class SubtitlesRepository : INewsSubtitles
    {
        private readonly AppDBContent appDBContent;

        public SubtitlesRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Subtitles> AllSubtitles => appDBContent.Subtitles.Include(c => c.PieceOfNews);
    }
}
