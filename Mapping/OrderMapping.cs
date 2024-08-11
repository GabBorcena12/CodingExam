using CsvHelper.Configuration;
using PizzaPlace.Model;

namespace PizzaPlace.Mapping
{    public class OrderMapping : ClassMap<Orders>
    {   public OrderMapping()
        {
            Map(m => m.OrderId).Name("order_id");
            Map(m => m.Date).Name("date");
            Map(m => m.Time).Name("time");
        }
    }
}

