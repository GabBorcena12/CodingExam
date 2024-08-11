using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Model
{
    public class PizzaType
    {
        [Key]
        public int Id { get; set; }
        public string PizzaTypeId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Ingredients { get; set; }
    }
}
