using MutantSuplements.API.DTOs.OrderDetailDTOs;

namespace MutantSuplements.API.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }

        public List<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();

    }
}
