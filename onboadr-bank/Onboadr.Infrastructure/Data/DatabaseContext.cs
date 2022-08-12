
using Microsoft.EntityFrameworkCore;
using Onboardr.Domain.Entities;

namespace Onboadr.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
