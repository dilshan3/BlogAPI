using BlogAPI.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.DatabaseContext
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
            

        }

        public DbSet<Blog> Blogs { get; set; }
        //public DbSet<Comment> Comments { get; set; }
    }
}
