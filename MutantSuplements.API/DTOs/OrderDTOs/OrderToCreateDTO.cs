using MutantSuplements.API.DTOs.OrderDetailDTOs;

namespace MutantSuplements.API.DTOs.OrderDTOs
{
    public class OrderToCreateDTO
    {
        public DateTime OrderDate { get; set; }
        //public int UserId { get; set; }
        public ICollection<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
    }
}
