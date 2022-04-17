using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.ViewModels
{
    public class PrintNewsViewModel
    {
        public IEnumerable<PieceOfNews> allNews { get; set; }
    }
}
