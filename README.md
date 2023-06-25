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

- Changes made in **_program.cs_**

```C#
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// adding database connection
builder.Services.AddDbContext<BookieWeb.Models.ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

```

--- ---

## Database Migration

- Run following commands

```shell
Add-Migration "migration message"
Update-database
```

--- ---

## Add data to tables using program

- Addin following lines of code to add the data

```C#
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

```

--- ---

## Routing in ASP.Net Core

- Routnig follows the following Rules

```C#
pattern: "{controller=Home}/{action=Index}/{id?}");
```

- controller/action/id

![alt text](Images/mvc.png)

--- ---

## Add Model in Views

- In contropller informatino is given to **_View_** as follows

```C#
public IActionResult Index()
{
    //  Get list items from the database
    List<Category> objCategoryList = _db.Categories.ToList();
    // Default View if no view is provided
    return View(objCategoryList);
}
```

- - First model is added to the start of **_cshtml_** as given below

```C#
@model List<Category>
```

- Run followinh line to loop over the information that is being gievn to **_View_** as follows 

```C#
<table class="table table-bordered table-striped">
    <thead>
        <!-- head of the table -->
        <tr>
            <!-- Adding header column for the table -->
            <th>
                Category Name
            </th>
            <th>
                Display Order
            </th>
        </tr>
    </thead>
    <tbody>
        <!-- Adding for loop to iterate over the list elements -->
        @foreach(var obj in Model.OrderBy(u => u.DisplayOrders))
        {
            <!-- body of the table -->
            <tr>
                <td>
                    @obj.Name
                </td>
                <td>
                    @obj.DisplayOrders
                </td>
            </tr>
        }
    </tbody>
</table>
```

--- ---

## Adding partial views

- Add following lines of code in **_View_** to add **_parial view_**

```C#

@section Scripts{
    @{
        <partial name="_ValidationScriptsPartial" />
    }
}
```

--- ---