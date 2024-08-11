using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlace.Model
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public string PizzaId { get; set; }
        public int Quantity { get; set; }
    }
}
