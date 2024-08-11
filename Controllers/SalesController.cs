using Microsoft.AspNetCore.Mvc;
using PizzaPlace.DBContext;

namespace PizzaPlace.Controllers
{
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly PizzaPlaceDbContext _context;

        public SalesController(PizzaPlaceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves top-selling pizza.
        /// </summary>
        [HttpGet]
        [Route("api/Sales/TopSellingPizza")]
        public IActionResult GetTopSellingPizza()
        {
            try
            {
                var topPizzaTypeId = (from orderDetail in _context.OrdersDetails
                                      join pizza in _context.Pizza
                                      on orderDetail.PizzaId equals pizza.PizzaId
                                      group new { orderDetail, pizza } by new { pizza.PizzaTypeId } into g
                                      orderby g.Count() descending
                                      select g.Key.PizzaTypeId)
                                      .FirstOrDefault();

                var pizzaName = (from pizzaType in _context.PizzaType
                                 where pizzaType.PizzaTypeId == topPizzaTypeId
                                 select pizzaType.Name)
                                     .FirstOrDefault();

                var pizzaPrice = (from pizzaType in _context.Pizza
                                  where pizzaType.PizzaTypeId == topPizzaTypeId
                                  select pizzaType.Price)
                                     .FirstOrDefault();

                if (pizzaName == null)
                    return NotFound();

                var topPizzaName = pizzaName.Replace("The", "").TrimStart().TrimEnd();
                return Ok($"Top selling price pizza is {topPizzaName} for only ${pizzaPrice}.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves the revenue.
        /// </summary>
        [HttpGet]
        [Route("api/Sales/GetRevenue")]
        public IActionResult GetRevenue()
        {
            try
            {
                var totalPrice = (from orderDetail in _context.OrdersDetails
                                  join pizza in _context.Pizza
                                  on orderDetail.PizzaId equals pizza.PizzaId
                                  select pizza.Price)
                            .Sum();
                return Ok(totalPrice);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }
    }

}

