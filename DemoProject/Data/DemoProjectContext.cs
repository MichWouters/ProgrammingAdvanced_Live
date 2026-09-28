using DemoProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace DemoProject.Data
{
    public class DemoProjectContext : DbContext
    {
        public DemoProjectContext(DbContextOptions options) : base(options)
        {
        }

        // Bepaal welke modellen in tabellen worden opgeslagen
        public DbSet<Product> Producten { get; set; }

        public DbSet<Laptop> Laptops { get; set; }


        //Database structuur finetunen
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            GenerateTables(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptop>().HasData(
                            new Laptop { Id = 1, Merk = "Acer", Price = 699M, GPU = "RTX 3050", Processor = "Intel I7", RamInGB = 16 },
                            new Laptop { Id = 2, Merk = "ASUS", Price = 1299M, GPU = "RTX 4060", Processor = "Intel i7", RamInGB = 16 },
                            new Laptop { Id = 3, Merk = "Lenovo", Price = 899M, GPU = "RTX 3060", Processor = "AMD Ryzen 7", RamInGB = 16 },
                            new Laptop { Id = 4, Merk = "HP", Price = 549M, GPU = "Integrated", Processor = "Intel i5", RamInGB = 8 },
                            new Laptop { Id = 5, Merk = "MSI", Price = 1899M, GPU = "RTX 4070", Processor = "Intel i9", RamInGB = 32 },
                            new Laptop { Id = 6, Merk = "Apple", Price = 1499M, GPU = "M3 10-core", Processor = "Apple M3", RamInGB = 16 },
                            new Laptop { Id = 7, Merk = "Dell", Price = 1099M, GPU = "RTX 3050 Ti", Processor = "Intel i7", RamInGB = 16 },
                            new Laptop { Id = 8, Merk = "Gigabyte", Price = 2199M, GPU = "RTX 4080", Processor = "AMD Ryzen 9", RamInGB = 32 },
                            new Laptop { Id = 9, Merk = "Acer", Price = 429M, GPU = "Integrated", Processor = "AMD Ryzen 3", RamInGB = 8 },
                            new Laptop { Id = 10, Merk = "Razer", Price = 2799M, GPU = "RTX 4090", Processor = "Intel i9", RamInGB = 32 }
                        );

            modelBuilder.Entity<Product>().HasData
            (
                new List<Product>()
                {
                    new Product{ Id = 1, Naam = "Laptop", Prijs = 999 },
                    new Product{ Id = 2, Naam = "Pc", Prijs = 1299.49M },
                    new Product{ Id = 3, Naam = "Perslucht", Prijs = 14.99M },
                }
            );
        }

        private void GenerateTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptop>(entity =>
            {
                entity.ToTable("Laptop");
                entity.Property(x => x.Merk).HasMaxLength(100);
                entity.Property(x => x.Price).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.Property(x => x.Naam).HasMaxLength(50);
                entity.Property(x => x.Prijs).HasColumnType("decimal(18,2)");
            });
        }
    }
}
