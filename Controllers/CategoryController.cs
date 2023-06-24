using BookieWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookieWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //  Get list items from the database
            List<Category> objCategoryList = _db.Categories.ToList();
            // Default View if no view is provided
            return View(objCategoryList);
        }

        // Create category method
        public IActionResult Create()
        {
            return View();
        }
    }
}
