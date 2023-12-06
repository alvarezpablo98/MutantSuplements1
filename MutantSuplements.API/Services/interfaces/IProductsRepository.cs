using MutantSuplements.API.Entities;

namespace MutantSuplements.API.Services.interfaces
{
    public interface IProductsRepository
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product? GetProductById(int id);
        bool ProductExists(string name);
        bool SaveChanges();
    }
}
