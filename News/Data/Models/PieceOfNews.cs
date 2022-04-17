using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data.Models
{
    public class PieceOfNews
    {
        public int id { set; get; }
        [Display(Name ="Title")]
        [Required(ErrorMessage ="TitleRequired")]
        public string Title { set; get; }

        public List<Subtitles> subtitles { set; get; }

    }
}
