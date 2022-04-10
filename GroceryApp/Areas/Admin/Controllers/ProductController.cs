using GroceryApp.Data.Repositories;
using GroceryApp.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GroceryApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    { 
        private readonly IFactory _ifactory;
        private IWebHostEnvironment _hostingEnvironment;

        public ProductController(IFactory factory, IWebHostEnvironment hostEnvironment)
        {
            _ifactory = factory;
            _hostingEnvironment = hostEnvironment;
        }

        #region APICALL
        public IActionResult AllProducts()
        {
            var products = _ifactory.Product.GeTAll(includeProperties: "Category");
            return Json(new { data = products });
        }
        #endregion

        public IActionResult Index()
        {
            ProductVM productVM = new ProductVM();
            productVM.Products = _ifactory.Product.GeTAll();
            foreach (var prod in productVM.Products)
            {
                prod.Category = _ifactory.Category.GeTAll().Where(c => c.Id == prod.CategoryId).Single();
            }
            return View(productVM);
        }

        //[HttpGet]   
        //public IActionResult Create()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            ProductVM vm = new ProductVM()
            {
                Product = new(),
                Categories = _ifactory.Category.GeTAll().Select(x =>
                new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
               
            };

            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Product = _ifactory.Product.GetT(x => x.Id == id);
                if (vm.Product == null)
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
        public IActionResult CreateUpdate(ProductVM vm, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                
                string fileName = String.Empty;
                if (file != null)
                {
                    string uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "ProductImage");
                    fileName = Guid.NewGuid().ToString().Substring(0,8) + "-" + file.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);
                    if (vm.Product.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, vm.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    vm.Product.ImageUrl = @"\ProductImage\" + fileName;
                }
                if (vm.Product.Id == 0)
                {
                    _ifactory.Product.Add(vm.Product);
                    TempData["success"] = "Product Created";
                }
                else
                {
                    _ifactory.Product.Update(vm.Product);
                    TempData["success"] = "Product Updated";
                }

                
                _ifactory.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if(id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var category = _unitOfWork.Category.GetT(x => x.Id == id);
        //    if(category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        #region DeleteAPICALL
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var product = _ifactory.Product.GetT(x => x.Id == id);
            if (product == null)
            {
                return Json(new { success = false, message = "Error in Fetching Data" });
            }
            else
            {
                var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, product.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
                _ifactory.Product.Delete(product);
                _ifactory.Save();
                return Json(new { success = true, message = "Product Deleted" });
            }
        }
        #endregion
    }
}
