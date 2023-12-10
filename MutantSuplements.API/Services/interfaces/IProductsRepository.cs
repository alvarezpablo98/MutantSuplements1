using MutantSuplements.API.Entities;

namespace MutantSuplements.API.Services.interfaces
{
    public interface IProductsRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product? GetProductById(int id);
        Product? GetProductByName(string name);
        bool ProductExists(string name);
        bool ProductExistsByCategoryId(int id);
        bool SaveChanges();
        void Updated(Product product);
    }
}
