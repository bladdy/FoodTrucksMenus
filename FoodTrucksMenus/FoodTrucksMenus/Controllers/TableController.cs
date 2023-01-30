using Microsoft.AspNetCore.Mvc;

namespace FoodTrucksMenus.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateTable()
        {
            return View();
        }
    }
}
