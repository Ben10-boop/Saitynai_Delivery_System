using Microsoft.EntityFrameworkCore;
using Saitynai_Delivery_System1.Models;

namespace Saitynai_Delivery_System1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Package> Packages { get; set; }
    }
}
