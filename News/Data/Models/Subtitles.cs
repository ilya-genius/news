using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data.Models
{
    public class Subtitles
    {
        public int id { set; get; }

        
        public int PieceOfNewsID { set; get; }

        public virtual PieceOfNews PieceOfNews { set; get; }

        [Display(Name = "Subhead")]
        [Required(ErrorMessage = "SubheadRequired")]
        public string subtitle { set; get; }

        [Display(Name = "Word")]
        [Required(ErrorMessage = "WordRequired")]
        public string text { set; get; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "ImageRequired")]
        public string picture { set; get; }
    }
}
