using InAndOut.Models;
using Microsoft.EntityFrameworkCore;

namespace InAndOut.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Item table
        /// </summary>
        public DbSet<Item> Item { get; set; }

        /// <summary>
        /// Expense table
        /// </summary>
        public DbSet<Expense> Expense { get; set; }
    }
}
