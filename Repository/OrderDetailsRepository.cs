using Microsoft.EntityFrameworkCore;
using PizzaPlace.DBContext;
using PizzaPlace.Interface;
using PizzaPlace.Model;

namespace PizzaPlace.Repository
{
    public class OrderDetailsRepository : IOrderDetails
    {
        private readonly PizzaPlaceDbContext _context;

        public OrderDetailsRepository(PizzaPlaceDbContext context)
        {
            _context = context;
        }

        public void AddOrderDetails(IEnumerable<OrderDetails> model)
        {
            AddEntities(
                model,
                entity => entity.OrderDetailsId
            );
        }

        public void AddOrderTransactions(IEnumerable<Orders> model)
        {
            AddEntities(
                model,
                entity => entity.OrderId
            );
        }

        public void AddPizza(IEnumerable<Pizza> model)
        {
            AddEntities(
                model,
                entity => entity.PizzaId
            );
        }
        public void AddPizzaTypes(IEnumerable<PizzaType> model)
        {
            AddEntities(
                model,
                entity => entity.PizzaTypeId
            );
        }

        public void AddEntities<T>(IEnumerable<T> entities, Func<T, string> getId) where T : class
        {
            var existingEntities = _context.Set<T>().ToList();

            var newEntities = entities
                .Where(entity => !existingEntities.Any(existing => getId(existing) == getId(entity)))
                .ToList();

            if (newEntities.Any())
            {
                _context.Set<T>().AddRange(newEntities);
                _context.SaveChanges();
            }
        }

        public void AddEntities<T>(IEnumerable<T> entities, Func<T, int> getId) where T : class
        {
            var existingEntities = _context.Set<T>().ToList();

            var newEntities = entities
                .Where(entity => !existingEntities.Any(existing => getId(existing) == getId(entity)))
                .ToList();

            if (newEntities.Any())
            {
                _context.Set<T>().AddRange(newEntities);
                _context.SaveChanges();
            }
        }
    }
}
