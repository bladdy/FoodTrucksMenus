using FoodTrucksMenus.Data;
using FoodTrucksMenus.Data.Entities;
using FoodTrucksMenus.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTrucksMenus.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        public ProductController(ICombosHelper combosHelper, DataContext context)
        {
            _context = context;
            _combosHelper = combosHelper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products
                .Include(pc => pc.Category)
                .Include(p => p.MenuProducts)
                .ThenInclude(p => p.Menu)
                .ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.MenuProducts)
                .ThenInclude(pc => pc.Menu)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
