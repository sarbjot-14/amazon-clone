using InventoryService.Data;
using InventoryService.Models;

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
            if(prod == null){
                throw new ArgumentNullException(nameof(prod));
            }
            _context.Products.Add(prod);
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p=>p.Id == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}