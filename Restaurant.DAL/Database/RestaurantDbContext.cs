

namespace Restaurant.DAL.Database
{
    public class RestaurantDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=RestaurantDb;Trusted_Connection=True;TrustServerCertificate=True"
            );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Table> Table{ get; set; }
    }
}
