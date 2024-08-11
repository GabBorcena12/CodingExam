using PizzaPlace.Model;

namespace PizzaPlace.Interface
{
    public interface IOrderDetails
    {
        void AddOrderDetails(IEnumerable<OrderDetails> pizzaOrders);
        void AddOrderTransactions(IEnumerable<Orders> orderDetails);
    }
}
