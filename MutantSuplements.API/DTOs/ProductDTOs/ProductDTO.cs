namespace MutantSuplements.API.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}
