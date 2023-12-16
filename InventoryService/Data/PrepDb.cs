using InventoryService.Data;
using InventoryService.Models;

namespace ProductService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }

        private static void SeedData(AppDbContext context)
        {

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