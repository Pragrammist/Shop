using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VMK_shop.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set;}
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            var t = 0;
            if(t == 1)
            //Database.EnsureDeleted();

            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
