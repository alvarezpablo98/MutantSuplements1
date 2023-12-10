using MutantSuplements.API.DBContext;
using MutantSuplements.API.Entities;
using MutantSuplements.API.Services.interfaces;
using SQLitePCL;

namespace MutantSuplements.API.Services.implementations
{
    public class ProductCategoriesRepository : IProductCategoriesRepository
    {
        private readonly MutantSuplementsContext _context;
        public ProductCategoriesRepository(MutantSuplementsContext context)
        {
            _context = context;

        }
        public IEnumerable<ProductCategory> GetCategories()
        {
            return _context.ProductCategories;
        }
        public void AddProductCategory(ProductCategory product)
        {
            _context.ProductCategories.Add(product);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public bool ProductCategoryExists(string name)
        {
            return _context.ProductCategories.Where(p => p.Name == name).Any();
        }
        public void DeleteProductCategory(ProductCategory category)
        {
            _context.Remove(category);
        }
        public ProductCategory? ProductCategoryById(int id)
        {
            return _context.ProductCategories.Where(pc => pc.Id == id).FirstOrDefault();
        }


    }
}
