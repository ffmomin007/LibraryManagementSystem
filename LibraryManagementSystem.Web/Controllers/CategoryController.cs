using LibraryManagementSystem.DataAccess.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            IEnumerable<Category> categories = _db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Order can't be same");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();

                TempData["success"] = "CATEGORY CREATED SUCCESSFULLY";
                return RedirectToAction("Index");
            }

            return View("Create", category);

        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryInDb = _db.Categories.Find(id);
            if (categoryInDb == null)
            {
                return NotFound();
            }


            return View(categoryInDb);
        }

        public IActionResult EditPost(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();

                TempData["success"] = "CATEGORY UPDATED SUCCESSFULLY";
                return RedirectToAction("Index");
            }

            return View(category);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryInDb = _db.Categories.Find(id);

            if (categoryInDb == null)
            {
                return NotFound();
            }

            return View(categoryInDb);
        }

        public IActionResult DeletePost(int? id)
        {
            Category? categoryInDb = _db.Categories.Find(id);
            if (categoryInDb == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(categoryInDb);
            _db.SaveChanges();
            TempData["success"] = "CATEGORY DELETED SUCCESSFULLY";

            return RedirectToAction("Index");
        }
    }
}
