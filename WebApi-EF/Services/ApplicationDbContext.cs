using Microsoft.EntityFrameworkCore;
using WebApi_EF.Models;

namespace WebApi_EF.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public required DbSet<Event> Events { get; set; }   
    }
}
