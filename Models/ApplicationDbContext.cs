using BookieWeb.Models;
using Microsoft.EntityFrameworkCore;


namespace BookieWeb.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { 
        
        }
        // This is where we will be adding the 
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrders = 1 },
                new Category { Id = 2, Name = "History", DisplayOrders = 2 },
                new Category { Id = 3, Name = "History", DisplayOrders = 2 }
                ); 
        }
    }
}
