using InventoryService.Data;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool IsDevelopment)
        {


            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), IsDevelopment);
            }

        }

        private static void SeedData(AppDbContext context, bool IsDevelopment)
        {
            if (!IsDevelopment)
            {
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not run migrations {ex.Message}");
                }
            }

            if (!context.Products.Any())
            {
                Console.WriteLine("--> Seeding Data");
                context.Products.AddRange(new Product() { Name = "Apple Watch", Description = "Apple Watch 6 with health monitoring", Price = 1200.99, Rating = 4.5, ImageUrl = "www.google.com" }, new Product() { Name = "Sony Headphones", Description = "Apple Watch 6 with health monitoring", Price = 1200.99, Rating = 4.5, ImageUrl = "www.google.com" }, new Product() { Name = "Jordans", Description = "Apple Watch 6 with health monitoring", Price = 1200.99, Rating = 4.5, ImageUrl = "www.google.com" });
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}