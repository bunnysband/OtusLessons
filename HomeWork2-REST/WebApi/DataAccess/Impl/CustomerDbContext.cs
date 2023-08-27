using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DataAccess.Impl
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
    }
}
