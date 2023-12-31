﻿using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookieWeb.Controllers
{
    public class CategoryController : Controller
    {
        // read data using repository
        private readonly CategoryRepository categoryRepository;
        // private readonly ApplicationDbContext _db;

        public CategoryController(CategoryRepository db)
        {
            categoryRepository = db;
        }

        public IActionResult Index()
        {
            //  Get list items from the database
            List<Category> objCategoryList = categoryRepository.GetAll().ToList();
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
                categoryRepository.Add(obj);
                categoryRepository.Save();
                // Here we will be using the temp data to store information
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        public IActionResult Edit(int id)
        {
            // get category object based on the id and pass it to the view to be displayed
            if (id==0)
            {
                return NotFound();
            }
            // get the category object based on id
            Category category = categoryRepository.Get(u=>u.Id==id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj) {
            if (ModelState.IsValid)
            {
                categoryRepository.Update(obj);
                categoryRepository.Save();
                // use temp data to store the message
                TempData["success"] = "Category has been edited successfully";
                // This will display the updated objects
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        // Adding delete functionality
        public IActionResult Delete(int Id)
        {
            if (Id==0)
            {
                return NotFound();
            }
            Category category = categoryRepository.Get(u => u.Id ==Id);
            if (category == null)
            {
                return NotFound();
            }

            // This information will be displayed to the user
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Category? category = categoryRepository.Get(u => u.Id == Id);
            if (Id==null)
            {
                return NotFound();
            }
            categoryRepository.Remove(category);
            categoryRepository.Save();
            // use temp data to store the message
            TempData["success"] = "Category has been delete successfully";
            return RedirectToAction("Index", "Category");
        }
    }
}
