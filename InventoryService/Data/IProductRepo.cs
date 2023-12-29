using InventoryService.Models;

namespace ProductService.Data
{
    public interface IProductRepo
    {
        bool SaveChanges();

        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);

        void CreateProduct(Product prod);

        Product UpdateQuantity(int purchasedQuantity, int productId);
    }
}