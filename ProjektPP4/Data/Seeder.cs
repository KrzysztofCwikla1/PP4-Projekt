using Microsoft.EntityFrameworkCore;
using ProjektPP4.Models;

namespace ProjektPP4.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { Name = "Śruby" },
                    new Category { Name = "Gwoździe" }
                );
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                var categories = context.Categories.ToList();

                context.Products.AddRange(
                    new Product
                    {
                        Name = "Śruba M6 x 60",
                        Price = 0.50m,
                        Category = categories.First(c => c.Name == "Śruby"),
                        Material = "Stal nierdzewna",
                        Size = "M6 x 60 mm",
                        Type = "Metryczny"
                    },
                    new Product
                    {
                        Name = "Gwóźdź 2.5 x 50",
                        Price = 0.10m,
                        Category = categories.First(c => c.Name == "Gwoździe"),
                        Material = "Stal ocynkowana",
                        Size = "2.5 x 50 mm",
                        Type = "-"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

