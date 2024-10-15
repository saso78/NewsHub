using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsHub.Data.Models;
namespace NewsHub.Data.Context
{
    public class NewsHubDbContext : DbContext
    {
        public NewsHubDbContext(DbContextOptions<NewsHubDbContext> options)
         : base(options) { }

        public DbSet<Article> Articles { get; set; }
    }
}
