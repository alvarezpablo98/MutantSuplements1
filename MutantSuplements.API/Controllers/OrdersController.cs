using System.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MutantSuplements.API.DTOs.OrderDTOs;
using MutantSuplements.API.Entities;
using MutantSuplements.API.Services.interfaces;

namespace MutantSuplements.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;
        public OrdersController(IOrdersRepository repository, IMapper mapper, IUsersRepository usersRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        [HttpGet]
        //[Authorize]
        public ActionResult<List<OrderDTO>> GetAll()
        {
            //string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            //if (role != "Admin")
            //{
            //    return Unauthorized("Not authorized to view users.");
            //}

            List<Order> orders = _repository.GetAllOrders().ToList();
            if (orders.Count == 0)
                return NotFound("The order list is empty");

            //var orderDto = _mapper.Map<List<OrderDTO>>(orders);  no descomentar
            return Ok(orders);
        }


        [HttpGet("{idOrder}", Name = "GetOrder")]
        [Authorize]
        public IActionResult GetOrder(int idOrder)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            if (role != "Admin")
            {
                return Unauthorized("Not authorized to view orders.");
            }

            if (!_repository.OrderExists(idOrder))
                return NotFound();

            Entities.Order? order = _repository.GetOrderById(idOrder);
            var orderDto = _mapper.Map<OrderDTO>(order);

            return Ok(orderDto);
        }

        [HttpPost("{id}")]
        public IActionResult CreateOrder(int id, [FromBody] OrderToCreateDTO orderToCreate)
        {

            if (orderToCreate == null)
                return BadRequest();

            if (_repository.OrderExists(id))
                return BadRequest("order already exist");

            

            int idUser = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value);

            //var orderDetail = orderToCreate.OrderDetails.ToList();
            //var newOrderDetail = _mapper.Map<List<OrderDetail>>(orderDetail);
            var newOrder = _mapper.Map<Order>(orderToCreate);
            newOrder.UserId = idUser;
            _repository.AddOrder(newOrder/*, newOrderDetail*/);


            //_repository.SaveChanges();

            return Created("GetOrder", orderToCreate);
        }

        //[HttpPut("{idOrder}")]
        ////[Authorize]
        //public IActionResult UpdateOrder(int idOrder, [FromBody] OrderToUpdateDTO orderUpdated)
        //{
        //    //string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

        //    //if (role != "Admin")
        //    //{
        //    //    return Unauthorized("Not authorized to view users.");
        //    //}

        //    var order = _repository.GetOrderById(idOrder);
        //    if (order == null)
        //        return NotFound();

        //    _mapper.Map(orderUpdated, order);

        //    var orderDetails = order.OrderDetails.ToList();
        //    var detailUpdated = orderUpdated.OrderDetails.ToList();

        //    _mapper.Map(detailUpdated, orderDetails);

        //    _repository.Update(order, orderDetails);
        //    _repository.SaveChanges();

        //    return NoContent();
        //}

        [HttpDelete("{idOrder}")]
        //[Authorize]
        public IActionResult DeleteOrder(int idOrder)
        {
            //string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            //if (role != "Admin")
            //{
            //    return Unauthorized("Not authorized to delete orders.");
            //}

            if (!_repository.OrderExists(idOrder))
                return NotFound();

            var orderToDelete = _repository.DeleteOrderAndDetails(idOrder);

            if (orderToDelete == false)
                return NotFound();

            _repository.SaveChanges();

            return NoContent();
        }

    }

}
