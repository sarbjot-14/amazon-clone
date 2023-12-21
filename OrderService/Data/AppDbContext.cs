using Microsoft.EntityFrameworkCore;
using OrdersService.Models;

namespace OrdersService.Data{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt){

        }

        public DbSet<Order> Orders {get; set;}
    }
}