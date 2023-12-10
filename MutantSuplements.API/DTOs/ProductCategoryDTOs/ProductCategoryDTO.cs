using MutantSuplements.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace MutantSuplements.API.DTOs.ProductCategoryDTOs
{
    public class ProductCategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
