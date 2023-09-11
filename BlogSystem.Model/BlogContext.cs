using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Model.Entitie;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Model
{
    public class BlogContext: DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryDetail> CategoryDetail { get; set; }
    }
}
