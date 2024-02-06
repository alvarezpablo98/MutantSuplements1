using Microsoft.EntityFrameworkCore;
using MutantSuplements.API.DBContext;
using MutantSuplements.API.Entities;
using MutantSuplements.API.Services.interfaces;

namespace MutantSuplements.API.Services.implementations
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly MutantSuplementsContext _context;
        public OrdersRepository(MutantSuplementsContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.Include(o => o.OrderDetails);
        }

        public Order? GetOrderById(int id)
        {
            return _context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _context.Orders.Where(o => o.Id == orderId).SelectMany(o => o.OrderDetails);
        }

        public bool OrderExists(int idOrder)
        {
            return _context.Orders.Where(o => o.Id == idOrder).Any();
        }

        public void AddOrder(Order order/*, List<OrderDetail> orderDetails*/)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            

            //var orderDetails = order.OrderDetails.ToList();
            //_context.OrderDetails.AddRange(orderDetails);
            //_context.SaveChanges();
        }

        public void Update(Order order, List<OrderDetail> orderDetails)
        {
            _context.OrderDetails.UpdateRange(orderDetails);
            _context.Orders.Update(order);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool DeleteOrderAndDetails(int orderId)
        {
            //var order = GetOrderById(orderId);
            var order = _context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.Id == orderId);
            if (order == null)
                return false;
            _context.OrderDetails.RemoveRange(order.OrderDetails);
            _context.Orders.Remove(order);
            return true;
        }

    }
}
