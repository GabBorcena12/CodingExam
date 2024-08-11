using Microsoft.AspNetCore.Mvc;
using PizzaPlace.DBContext;
using PizzaPlace.Model;

namespace PizzaPlace.Controllers
{
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaPlaceDbContext _context;

        public OrdersController(PizzaPlaceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all orders.
        /// </summary>
        /// <returns>A list of orders.</returns>
        [HttpGet]
        [Route("api/Order/GetOrders")]
        public IActionResult GetOrders()
        {
            try
            {
                var orders = (from orderDetail in _context.OrdersDetails
                              join order in _context.Orders
                              on orderDetail.OrderId equals order.OrderId
                              join pizza in _context.Pizza
                              on orderDetail.PizzaId equals pizza.PizzaId into pizzaGroup
                              from pizza in pizzaGroup.DefaultIfEmpty()
                              join pizzaType in _context.PizzaType
                              on pizza.PizzaTypeId equals pizzaType.PizzaTypeId into pizzaTypeGroup
                              from pizzaType in pizzaTypeGroup.DefaultIfEmpty()
                              select new
                              {
                                  Order = order,
                                  OrderDetail = orderDetail,
                                  Pizza = pizza,
                                  PizzaType = pizzaType
                              }).ToList();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves specific order.
        /// </summary>
        /// <returns>Specific order.</returns>
        [HttpGet]
        [Route("api/Order/GetOrder/{id}")]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                var order = (from orderDetail in _context.OrdersDetails
                             join orderTransaction in _context.Orders
                             on orderDetail.OrderId equals orderTransaction.OrderId
                             join pizza in _context.Pizza
                             on orderDetail.PizzaId equals pizza.PizzaId into pizzaGroup
                             from pizza in pizzaGroup.DefaultIfEmpty()
                             join pizzaType in _context.PizzaType
                             on pizza.PizzaTypeId equals pizzaType.PizzaTypeId into pizzaTypeGroup
                             from pizzaType in pizzaTypeGroup.DefaultIfEmpty()
                             where orderTransaction.OrderId == id
                             select new
                             {
                                 Order = orderTransaction,
                                 OrderDetail = orderDetail,
                                 Pizza = pizza,
                                 PizzaType = pizzaType
                             }).FirstOrDefault();

                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
