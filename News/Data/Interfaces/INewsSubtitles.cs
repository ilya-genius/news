using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data.Interfaces
{
    public interface INewsSubtitles
    {
        IEnumerable<Subtitles> AllSubtitles { get;  }
    }
}
