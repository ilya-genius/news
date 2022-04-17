using News.Data.Interfaces;
using News.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Data.Repository
{
    public class AdminsRepository : IAllAdmins
    {
        private readonly AppDBContent appDBContent;

        public AdminsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Admin> Admins => appDBContent.Admins;
    }
}
