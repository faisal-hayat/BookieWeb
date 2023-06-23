using Microsoft.EntityFrameworkCore;

namespace BookieWeb.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { 
        
        }
        // This is where we will be adding the 
    }
}
