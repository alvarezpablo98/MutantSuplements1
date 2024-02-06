using MutantSuplements.API.DTOs.OrderDetailDTOs;

namespace MutantSuplements.API.DTOs.OrderDTOs
{
    public class OrderToUpdateDTO
    {
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public IList<OrderDetailDTO> OrderDetails { get; set; }
    }
}
