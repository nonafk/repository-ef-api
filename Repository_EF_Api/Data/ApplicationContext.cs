using Microsoft.EntityFrameworkCore;
using Repository_EF_Api.Models;

namespace Repository_EF_Api.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
    }
}
