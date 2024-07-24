using AstronautsWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AstronautsWebApplication.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Astronaut> Astronauts { get; set; }
    }
}
