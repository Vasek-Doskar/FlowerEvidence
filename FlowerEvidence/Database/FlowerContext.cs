using FlowerEvidence.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerEvidence.Database
{
    public class FlowerContext : DbContext
    {
        public DbSet<Flower> Flowers { get; set; }

        public FlowerContext()
        {
            Database.EnsureCreated(); // pokud DB neexistuje, tak se vytvoří
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=FlowerDb.db"); // název naší DB
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {// data seed
            modelBuilder.Entity<Flower>().HasData(
                new Flower { Id=1, Name="Orchidej", Genus="Chřestotvaré",Color="Bílá"},
                new Flower { Id=2, Name="Tulipán", Genus="Liliovité",Color="Žlutá"}
                );
        }
    }
}
