using FoodTrucksMenus.Data;
using FoodTrucksMenus.Data.Entities;
using FoodTrucksMenus.Helpers;
using FoodTrucksMenus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTrucksMenus.Controllers
{
    public class MenusController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public MenusController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Menus != null ?
                        View(await _context.Menus.Include(P => P.Products)
                        .Include(B => B.Branch).Include(B => B.Category).ToListAsync()) :
                        Problem("Entity set 'DataContext.Menus'  is null.");
        }
        public async Task<IActionResult> Create()
        {
            AddOrEditMenu model = new AddOrEditMenu
            {
                Categories = await _combosHelper.GetComboCategoriesAsync(),
                Branches = await _combosHelper.GetComboBranchesAsync(1)//Se obotendra el listado enviando el truck id
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddOrEditMenu? model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Menu menu = new Menu() 
                    {
                        Name = model.Name,
                        Branch = await _context.Branches.FindAsync(model.BranchId),
                        Category = await _context.Categories.FindAsync(model.CategoryId),
                        Enable = model.Enable,

                    };
                    _context.Add(menu);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un Menu con el mismo nombre");

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
            model.Categories = await _combosHelper.GetComboCategoriesAsync();
            model.Branches = await _combosHelper.GetComboBranchesAsync(1);//Se obotendra el listado enviando el truck id
            return View(model);
        }

        //ToDo: Pendiente Crear el update MEnu
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Menus
                .FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un pais con el mismo nombre");

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
            return View(category);
        }

    }
}
