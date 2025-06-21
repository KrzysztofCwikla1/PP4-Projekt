using Microsoft.EntityFrameworkCore;
using ProjektPP4.Models;

namespace ProjektPP4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey("CategoryId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            var seedDate = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var emptyGuid = Guid.Empty;

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sruba", CreatedAt = seedDate, CreatedBy = emptyGuid },
                new Category { Id = 2, Name = "Gwozdz", CreatedAt = seedDate, CreatedBy = emptyGuid },
                new Category { Id = 3, Name = "Nakretka", CreatedAt = seedDate, CreatedBy = emptyGuid }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "SrubaStalowa",
                    Ean = "11111111111111",
                    Price = 0.5m,
                    Stock = 1000,
                    Sku = "SRUB-001",
                    Material = "StalNierdzewna",
                    Size = "4x20mm",
                    Type = "Krzyzak",
                    CreatedAt = seedDate,
                    CreatedBy = emptyGuid
                },
                new Product
                {
                    Id = 2,
                    Name = "GwozdzStalowy",
                    Ean = "22222222222222",
                    Price = 0.10m,
                    Stock = 5000,
                    Sku = "GWZ-001",
                    Material = "Stal",
                    Size = "50mm",
                    Type = "Common",
                    CreatedAt = seedDate,
                    CreatedBy = emptyGuid
                },
                new Product
                {
                    Id = 3,
                    Name = "NakretkaAluminiowa",
                    Ean = "333333333333333",
                    Price = 0.15m,
                    Stock = 3000,
                    Sku = "NAKR-001",
                    Material = "Aluminium",
                    Size = "15mm",
                    Type = "Szesciokatna",
                    CategoryId=3,
                    CreatedAt = seedDate,
                    CreatedBy = emptyGuid
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@main.com",
                    FirstName = "Admin",
                    LastName = "User"
                },
                new User
                {
                    Id = 2,
                    Username = "user1",
                    Email = "user1@mail.com",
                    FirstName = "Jan",
                    LastName = "Kowalski"
                }
            );
        }
    }
}