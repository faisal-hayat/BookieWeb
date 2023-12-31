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

## Adding Notifications

- **_TempData_** store data, which is only available to next **_render_**
- syntax is following

```C#
TempData["success"] = "Category has been edited successfully";
```

- **_TempData_** is retrieved in **_Notification.cshtml_** file as follows

```html
@if (TempData["success"] != null)
{
    <h2>@TempData["success"]</h2>
}

@if (TempData["error"] != null)
{
    <h2>@TempData["error"]</h2>
}
```

- This **_Notification.csthml_** partial view will be added to the top of **_View_**

```html
<!-- partial tag will be used here to include the notifications -->
<partial name="_Notification" />
```

- This **_partial view_** will be added to *_Layout.cshtml_**

```html
<div class="container">
    <main role="main" class="pb-3">
        <!-- partial tag will be used here to include the notifications -->
        <partial name="_Notification" />
        @RenderBody()
    </main>
</div>
```

--- ---

## Adding **_toastr_**
[Source](https://cdnjs.com/libraries/toastr.js/latest)

```html
@if (TempData["success"] != null)
{
    <!-- Add jquery too -->
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <!-- Add javascript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js" integrity="sha512-VEd+nq25CkR676O+pLBnDW09R7VQX9Mdiij052gVCp5yVH3jGtH70Ho/UUv4mJDsEdTvqRCFZg0NKGiojGnUCw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script type="text">
        toastr.success('@TempData["success"]');
    </script>
}

@if (TempData["error"] != null)
{
    <!-- Add jquery too -->
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <!-- Add javascript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js" integrity="sha512-VEd+nq25CkR676O+pLBnDW09R7VQX9Mdiij052gVCp5yVH3jGtH70Ho/UUv4mJDsEdTvqRCFZg0NKGiojGnUCw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script type="text">
        toastr.error('@TempData["error"]');
    </script>
}
```

--- ---

## Add New Project 

- New project is added to the BookieWeb
- New Project type is **_ASP.NET Core Web App_**
- Set the new project as **_startup project_**

--- ---