using ASP.NETMVCCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETMVCCRUD.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }


        public DbSet<Employees> Employees { get; set; }
    }
}
