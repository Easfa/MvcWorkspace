using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Models;

namespace MvcWorkspace.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        //DbSets Area

        public DbSet<Expense> Expenses {get; set;}
    }
}
