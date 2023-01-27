using FoodTrucksMenus.Data;
using FoodTrucksMenus.Data.Entities;
using FoodTrucksMenus.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTrucksMenus.Controllers
{
    public class BranchController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        public BranchController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Branch branch = await _context.Branches
                .Include(M => M.Menus)
                .ThenInclude(MP => MP.MenuProducts)
                .Include(B => B.Tables)
                .ThenInclude(O => O.Orders)
                .Include(B => B.Truck)
                .FirstOrDefaultAsync(B => B.Id == id);
            

            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }
    }
}
