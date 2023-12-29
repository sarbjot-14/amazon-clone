using System.Text.Json;
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
                using (StreamReader r = new StreamReader("Data/ProductsMock.json"))
                {
                    string mockJson = r.ReadToEnd();
                    var productData = JsonSerializer.Deserialize<List<Product>>(mockJson);
                    //Console.WriteLine($"the data {JsonSerializer.Serialize(productData)}");
                    context.Products.AddRange(productData);
                    //context.Products.RemoveRange(context.Products);

                    context.SaveChanges();
                }

            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}