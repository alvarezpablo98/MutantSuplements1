using MutantSuplements.API.DTOs.ProductCategoryDTOs;
using MutantSuplements.API.Entities;

namespace MutantSuplements.API.Services.interfaces
{
    public interface IProductCategoriesRepository
    {
        IEnumerable<ProductCategory> GetCategories();
        bool SaveChanges();
        void AddProductCategory(ProductCategory category);
        bool ProductCategoryExists(string name);
        ProductCategory? ProductCategoryById(int id);
        void DeleteProductCategory(ProductCategory category);
    }
}
