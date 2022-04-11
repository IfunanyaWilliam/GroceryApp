using GroceryApp.Data.Repositories;
using GroceryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using GroceryApp.Data.Contracts;

namespace GroceryApp.Controllers
{
    [Area(("Customer"))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFactory _ifactory;

        public HomeController(ILogger<HomeController> logger, IFactory factory)
        {
            _logger = logger;
            _ifactory = factory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Product> products = _ifactory.Product.GeTAll(includeProperties: "Category");
            return View(products);
        }

        [HttpGet]
        public IActionResult Details(int? productId)
        {
            Cart cart = new Cart()
            {
                Product = _ifactory.Product.GetT(x => x.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = (int)productId
            };
            return View(cart);
        }

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public IActionResult Details(Cart cart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var claimsIdentity = (ClaimsIdentity)User.Identity;
        //        var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //        cart.ApplicationUserId = claims.Value;

        //        var cartItem = _ifactory.Cart.GetT(x => x.Product == cart.ProductId && x.ApplicationUserId == claims.Value);

        //        if(cartItem == null)
        //        {
        //            _ifactory.Cart.Add(cart);
        //            _ifactory.Save();
        //            HttpContext.Session.SetInt32("SessionCart", _ifactory.Cart.GetAll(x => x.ApplicationUserId == claims.Value).ToList().Count);
        //        }
        //    }
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}