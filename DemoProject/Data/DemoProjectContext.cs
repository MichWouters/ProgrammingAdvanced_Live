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

        public DbSet<Bestelling>  Bestellingen { get; set; }

        public DbSet<Klant> Klanten { get; set; }

        public DbSet<OrderLijn> OrderLijnen { get; set; }


        //Database structuur finetunen
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            GenerateTables(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // 1. Laptops (10 items)
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

            // 2. Producten (10 items)
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Naam = "Laptop", Beschrijving = "Allround workstation", Prijs = 999.00M },
                new Product { Id = 2, Naam = "Pc", Beschrijving = "Krachtige desktop-computer", Prijs = 1299.49M },
                new Product { Id = 3, Naam = "Perslucht", Beschrijving = "Spuitbus voor stofreiniging", Prijs = 14.99M },
                new Product { Id = 4, Naam = "Mechanisch Toetsenbord", Beschrijving = "RGB gaming toetsenbord", Prijs = 89.95M },
                new Product { Id = 5, Naam = "Draadloze Muis", Beschrijving = "Ergonomische optische muis", Prijs = 34.50M },
                new Product { Id = 6, Naam = "27 inch Monitor", Beschrijving = "4K Ultra HD IPS scherm", Prijs = 329.00M },
                new Product { Id = 7, Naam = "Headset", Beschrijving = "Noise-cancelling gaming headset", Prijs = 79.99M },
                new Product { Id = 8, Naam = "USB-C Hub", Beschrijving = "7-in-1 adapter met HDMI", Prijs = 45.00M },
                new Product { Id = 9, Naam = "Webcam 1080p", Beschrijving = "Full HD webcam met microfoon", Prijs = 59.90M },
                new Product { Id = 10, Naam = "Externe SSD 1TB", Beschrijving = "Snelle USB 3.2 draagbare schijf", Prijs = 112.50M }
            );

            // 3. Klanten (10 items)
            modelBuilder.Entity<Klant>().HasData(
                new Klant { Id = 1, Voornaam = "Jan", AchterNaam = "Janssens", DatumAangemaakt = new DateOnly(2023, 1, 15) },
                new Klant { Id = 2, Voornaam = "Sophie", AchterNaam = "Peeters", DatumAangemaakt = new DateOnly(2023, 2, 20) },
                new Klant { Id = 3, Voornaam = "Lucas", AchterNaam = "Maes", DatumAangemaakt = new DateOnly(2023, 4, 10) },
                new Klant { Id = 4, Voornaam = "Emma", AchterNaam = "Jacobs", DatumAangemaakt = new DateOnly(2023, 5, 2) },
                new Klant { Id = 5, Voornaam = "Liam", AchterNaam = "Willems", DatumAangemaakt = new DateOnly(2023, 6, 18) },
                new Klant { Id = 6, Voornaam = "Olivia", AchterNaam = "Mertens", DatumAangemaakt = new DateOnly(2023, 7, 22) },
                new Klant { Id = 7, Voornaam = "Noah", AchterNaam = "Claes", DatumAangemaakt = new DateOnly(2023, 8, 30) },
                new Klant { Id = 8, Voornaam = "Ella", AchterNaam = "Goossens", DatumAangemaakt = new DateOnly(2023, 9, 14) },
                new Klant { Id = 9, Voornaam = "Arthur", AchterNaam = "Wouters", DatumAangemaakt = new DateOnly(2023, 11, 5) },
                new Klant { Id = 10, Voornaam = "Mila", AchterNaam = "De Smet", DatumAangemaakt = new DateOnly(2024, 1, 12) }
            );

            // 4. Bestellingen (10 items - verwezen naar KlantId)
            modelBuilder.Entity<Bestelling>().HasData(
                new Bestelling { Id = 1, KlantId = 1 },
                new Bestelling { Id = 2, KlantId = 1 },
                new Bestelling { Id = 3, KlantId = 2 },
                new Bestelling { Id = 4, KlantId = 3 },
                new Bestelling { Id = 5, KlantId = 4 },
                new Bestelling { Id = 6, KlantId = 5 },
                new Bestelling { Id = 7, KlantId = 6 },
                new Bestelling { Id = 8, KlantId = 7 },
                new Bestelling { Id = 9, KlantId = 8 },
                new Bestelling { Id = 10, KlantId = 10 }
            );

            // 5. Orderlijnen (10 items - verwezen naar BestellingId en ProductId)
            modelBuilder.Entity<OrderLijn>().HasData(
                new OrderLijn { Id = 1, BestellingId = 1, ProductId = 1, Aantal = 1 },
                new OrderLijn { Id = 2, BestellingId = 1, ProductId = 5, Aantal = 2 },
                new OrderLijn { Id = 3, BestellingId = 2, ProductId = 3, Aantal = 5 },
                new OrderLijn { Id = 4, BestellingId = 3, ProductId = 2, Aantal = 1 },
                new OrderLijn { Id = 5, BestellingId = 3, ProductId = 6, Aantal = 2 },
                new OrderLijn { Id = 6, BestellingId = 4, ProductId = 4, Aantal = 1 },
                new OrderLijn { Id = 7, BestellingId = 5, ProductId = 10, Aantal = 1 },
                new OrderLijn { Id = 8, BestellingId = 6, ProductId = 7, Aantal = 1 },
                new OrderLijn { Id = 9, BestellingId = 7, ProductId = 8, Aantal = 3 },
                new OrderLijn { Id = 10, BestellingId = 8, ProductId = 9, Aantal = 1 },
                new OrderLijn { Id = 11, BestellingId = 9, ProductId = 3, Aantal = 10 },
                new OrderLijn { Id = 12, BestellingId = 10, ProductId = 1, Aantal = 1 }
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

            modelBuilder.Entity<Bestelling>(entity =>
            {
                entity.ToTable("Bestelling");

                entity.HasOne(x => x.Klant)
                .WithMany(x => x.Bestellingen)
                .HasForeignKey(x => x.KlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            });

            modelBuilder.Entity<Klant>(entity =>
            {
                entity.ToTable("Klant");
            });

            modelBuilder.Entity<OrderLijn>(entity =>
            {
                entity.ToTable("OrderLijn");

                // Manueel relaties leggen
                entity.HasOne(x => x.Bestelling)
                .WithMany(x => x.Orderlijnen)
                .HasForeignKey(x => x.BestellingId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

                entity.HasOne(x => x.Product)
                .WithMany(x => x.OrderLijnen)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            });
        }
    }
}
