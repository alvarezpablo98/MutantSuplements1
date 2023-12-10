using MutantSuplements.API.DBContext;
using MutantSuplements.API.DTOs.ProductDTOs;
using MutantSuplements.API.Entities;
using MutantSuplements.API.Services.interfaces;
using SQLitePCL;

namespace MutantSuplements.API.Services.implementations
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly MutantSuplementsContext _context;
        public ProductsRepository(MutantSuplementsContext context) 
        { 
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }
        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public bool ProductExists(string name)
        {
            return _context.Products.Where(p => p.Name == name).Any();
        }
        public bool ProductExistsByCategoryId(int id)
        {
            return _context.ProductCategories.Where(p => p.Id == id).Any();
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Updated(Product product)
        {

            _context.Products.Update(product);
        }
        public Product? GetProductByName(string name)
        {
            return _context.Products.Where(p=> p.Name == name).FirstOrDefault();
        }

        public void DeleteProduct(Product product)
        {
            _context.Remove(product);
        }
    }

}

