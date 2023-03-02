using crud_csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace crud_csharp.Database
{
    public class DB_Context : DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        {
           
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Video> Videos { get; set; }

    }
}
