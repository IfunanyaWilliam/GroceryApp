using GroceryApp.Data.Repositories;
using GroceryApp.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using GroceryApp.Data.Contracts;

namespace GroceryApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IFactory _ifactory;

        public CategoryController(IFactory factory)
        {
            _ifactory = factory;
        }

        public IActionResult Index()
        {
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.categories = _ifactory.Category.GeTAll();
            return View(categoryVM);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVM vm = new CategoryVM();
            if(id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Category = _ifactory.Category.GetT(x => x.Id == id);
                if(vm.Category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryVM vm)
        {
            if (ModelState.IsValid)
            {
                if(vm.Category.Id == 0)
                {
                    _ifactory.Category.Add(vm.Category);
                    TempData["success"] = "Category Creation Done!";
                }
                else
                {
                    _ifactory.Category.Update(vm.Category);
                    TempData["success"] = "Category Update Done!";
                }

                _ifactory.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var category = _ifactory.Category.GetT(x => x.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteData(int? id)
        {
            var category = _ifactory.Category.GetT(x => x.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            _ifactory.Category.Delete(category);
            _ifactory.Save();
            TempData["success"] = "Category Deleted";
            return RedirectToAction("Index");
        }

    }
}
