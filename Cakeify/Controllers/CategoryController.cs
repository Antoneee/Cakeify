using Cakeify.Data;
using Cakeify.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cakeify.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CakeifyDbContext _cakeifyDbContext;

        public CategoryController(CakeifyDbContext cakeifyDbContext)
        {
            _cakeifyDbContext = cakeifyDbContext;
        }

        public IActionResult Index()
        {
            var categoryList = _cakeifyDbContext.Categories.ToList();
            ViewBag.Active = "Category";
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category categoryToBeAdded)
        {
            if (categoryToBeAdded.Name == categoryToBeAdded.OrderId.ToString())
            {
                ModelState.AddModelError("Name", "The Name and Display Order fields cannot be the same.");
            }
            if (ModelState.IsValid) {
                _cakeifyDbContext.Categories.Add(categoryToBeAdded);
                _cakeifyDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryToBeAdded);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryToBeUpdated = _cakeifyDbContext.Categories.Find(id);
            if (categoryToBeUpdated == null)
            {
                return NotFound();
            }
            return View(categoryToBeUpdated);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category categoryToBeUpdated)
        {
            if (categoryToBeUpdated.Name == categoryToBeUpdated.OrderId.ToString())
            {
                ModelState.AddModelError("Name", "The Name and Display Order fields cannot be the same.");
            }
            if (ModelState.IsValid)
            {
                _cakeifyDbContext.Categories.Update(categoryToBeUpdated);
                _cakeifyDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryToBeUpdated);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryToBeDeleted = _cakeifyDbContext.Categories.Find(id);
            if (categoryToBeDeleted == null)
            {
                return NotFound();
            }
            return View(categoryToBeDeleted);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category categoryToBeDeleted)
        {
            _cakeifyDbContext.Categories.Remove(categoryToBeDeleted);
            _cakeifyDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
