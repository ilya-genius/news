using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.ViewModels
{
    public class CertainNewsViewModel
    {
        public PieceOfNews oneNews { get; set; }

        public IEnumerable<Subtitles> allSubtitles { get; set; }
    }
}
