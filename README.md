# Bookie Web
[Source](https://www.youtube.com/watch?v=AopeJjkcRvU&ab_channel=DotNetMastery)

--- ---

## Required Libraries


- Entity Framework Core
- Entity Framework Sql Server
- Entity Framework Tools

--- ---

## Add Database and Connection String

- Add connection string to **_appsettings.json_**
- Add **_DbContext_**

```C#
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

```

--- ---