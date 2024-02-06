using MutantSuplements.API.Entities;

namespace MutantSuplements.API.Services.interfaces
{
    public interface IOrdersRepository
    {
        void AddOrder(Order order/*, List<OrderDetail> orderDetails*/);
        bool DeleteOrderAndDetails(int orderId);
        IEnumerable<Order> GetAllOrders();
        Order? GetOrderById(int id);
        IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId);
        bool OrderExists(int idOrder);
        bool SaveChanges();
        void Update(Order order, List<OrderDetail> orderDetails);
    }
}
