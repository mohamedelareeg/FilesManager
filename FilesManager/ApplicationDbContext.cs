
using FilesManager.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesManager.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          
        }

        public DbSet<Batches> Batches { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Papers> Papers { get; set; }

    }
}
