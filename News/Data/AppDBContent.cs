using Microsoft.EntityFrameworkCore;
using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<PieceOfNews> PieceOfNews { get; set; }
        public DbSet<Subtitles> Subtitles { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
