using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Model
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string PizzaId { get; set; }
        public string PizzaTypeId { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}
