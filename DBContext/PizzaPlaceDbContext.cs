using Microsoft.EntityFrameworkCore;
using PizzaPlace.Model;

namespace PizzaPlace.DBContext
{
    public class PizzaPlaceDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public PizzaPlaceDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<OrderDetails> OrdersDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<PizzaType> PizzaType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("PizzaPlaceDb");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Orders>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Pizza>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<PizzaType>()
                .HasKey(o => o.Id);
        }
    }
}
