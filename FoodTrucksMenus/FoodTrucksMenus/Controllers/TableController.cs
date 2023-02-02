using FoodTrucksMenus.Data;
using FoodTrucksMenus.Data.Entities;
using FoodTrucksMenus.Helpers;
using FoodTrucksMenus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTrucksMenus.Controllers
{
    public class TableController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        public TableController(ICombosHelper combosHelper, DataContext context)
        {
            _context = context;
            _combosHelper = combosHelper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Order table = await _context.Orders.
            Table table = await _context.Tables
                .Include(o => o.Orders)
                .ThenInclude(od => od.OrderDetails)
                .ThenInclude(po => po.Product)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }
        public async Task<IActionResult> Create()
        {
            AddTableViewModel table = new()
            {
                TruckId = 1,
                BranchId = 1,
            };
            return View(table);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddTableViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Table table = new Table()
                    {
                        Truck = await _context.Trucks.FirstOrDefaultAsync(t => t.Id == model.TruckId),
                        Branch = await _context.Branches.FirstOrDefaultAsync(t => t.Id == model.BranchId),
                        NameTable = model.Name,
                        GuestNumber = model.GuestNumber,
                    };
                    _context.Add(table);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Branch", new { id = model.TruckId } );
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una Tabla con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            model.TruckId = 1;
            model.BranchId = 1;
            model.GuestNumber = 0;
            return View(model);
        }
    }
}
