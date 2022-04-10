using Microsoft.AspNetCore.Mvc;

namespace GroceryApp.Areas.Customer.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
