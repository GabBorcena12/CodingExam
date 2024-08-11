using CsvHelper.Configuration;
using PizzaPlace.Model;

namespace PizzaPlace.Mapping
{    public class PizzaTypeMapping : ClassMap<PizzaType>
    {   public PizzaTypeMapping()
        {
            Map(m => m.PizzaTypeId).Name("pizza_type_id");
            Map(m => m.Name).Name("name");
            Map(m => m.Category).Name("category");
            Map(m => m.Ingredients).Name("ingredients");
        }
    }
}

