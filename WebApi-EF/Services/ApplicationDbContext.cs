using Microsoft.EntityFrameworkCore;

namespace WebApi_EF.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
