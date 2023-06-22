using BulkyFormWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyFormWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
