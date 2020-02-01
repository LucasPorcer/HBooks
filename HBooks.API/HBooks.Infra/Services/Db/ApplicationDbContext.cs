using HBooks.Domain.Entitites.Objects;
using Microsoft.EntityFrameworkCore;

namespace HBooks.Infra.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :
            base(options)
        { }

        public DbSet<BookObject> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookObject>()
                .HasKey(p => p.Id);
        }
    }
}