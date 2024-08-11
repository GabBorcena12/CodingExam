using CsvHelper.Configuration;
using PizzaPlace.Model;

namespace PizzaPlace.Mapping
{    public class OrderDetailsMap : ClassMap<OrderDetails>
    {   public OrderDetailsMap()
        {
            Map(m => m.OrderDetailsId).Name("order_details_id");
            Map(m => m.OrderId).Name("order_id");
            Map(m => m.PizzaId).Name("pizza_id");
            Map(m => m.Quantity).Name("quantity");
        }
    }
}

