using InventoryService.Data;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductService.Data
{

    public class ProductRepo : IProductRepo
    {
        private AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;

        }
        public void CreateProduct(Product prod)
        {
            if (prod == null)
            {
                throw new ArgumentNullException(nameof(prod));
            }
            _context.Products.Add(prod);
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product UpdateQuantity(int purchasedQuantity, int productId)
        {
            Product product = _context.Products.Single<Product>(p => p.Id == productId);
            if (product != null)
            {
                product.Quantity -= purchasedQuantity;
                if (product.Quantity < 0)
                {
                    product.Quantity = 0;
                }
            }
            _context.SaveChanges();
            return product;
        }

        public void DeleteProducts()
        {
            _context.Products.ExecuteDelete();
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}