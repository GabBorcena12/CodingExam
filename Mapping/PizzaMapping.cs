using CsvHelper.Configuration;
using PizzaPlace.Model;

namespace PizzaPlace.Mapping
{    public class PizzaMapping : ClassMap<Pizza>
    {   public PizzaMapping()
        {
            Map(m => m.PizzaId).Name("pizza_id");
            Map(m => m.PizzaTypeId).Name("pizza_type_id");
            Map(m => m.Size).Name("size");
            Map(m => m.Price).Name("price");
        }
    }
}

