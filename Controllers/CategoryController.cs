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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            // custom error message
            if (obj.Name == obj.DisplayOrders.ToString())
            {
                // This error meesage will be displayed when model is being validated
                ModelState.AddModelError("name", "The display order cant match the name");
            }
            // we will receive the Category object from the View
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }

            return View();
        }
    }
}
