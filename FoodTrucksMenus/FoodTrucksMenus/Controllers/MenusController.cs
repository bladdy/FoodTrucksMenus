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
        //ToDo: agregar metodo que quita el producto del menu
        public MenusController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Menus != null ?
                        View(await _context.Menus.Include(P => P.MenuProducts)
                        .Include(B => B.Branch).Include(B => B.Category).ToListAsync()) :
                        Problem("Entity set 'DataContext.Menus'  is null.");
        }
        public async Task<IActionResult> Create()
        {
            AddOrEditMenu model = new()
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
                    Menu menu = new()
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

            var menu = await _context.Menus
                .FirstOrDefaultAsync(c => c.Id == id);
            if (menu == null)
            {
                return NotFound();
            }

            AddOrEditMenu model = new()
            {
                Name = menu.Name,
                Branches = await _combosHelper.GetComboBranchesAsync(1),
                Categories = await _combosHelper.GetComboCategoriesAsync(),
                Enable = (bool)menu.Enable,
                Id = menu.Id,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AddOrEditMenu model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Menu menu = new()
                    {
                        Name = model.Name,
                        Branch = await _context.Branches.FindAsync(model.BranchId),
                        Category = await _context.Categories.FindAsync(model.CategoryId),
                        Enable = model.Enable,
                        Id = model.Id,
                    };
                    _context.Update(menu);
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
            return View(model);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Menu menu = await _context.Menus
                .Include(MP => MP.MenuProducts)
                .ThenInclude(P => P.Product)
                .Include(B => B.Branch)
                .Include(B => B.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        //Prod crear view
        public async Task<IActionResult> AddProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu menu = await _context.Menus
                .Include(MP => MP.MenuProducts)
                .ThenInclude(P => P.Product)
                .Include(B => B.Branch)
                .Include(B => B.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (menu == null)
            {
                return NotFound();
            }
            List<Product> filter = menu.MenuProducts.Select(pc => new Product
            {
                Id = pc.Product.Id,
                NameProd = pc.Product.NameProd
            }).ToList();
            AddMenuProductsViewModel model = new()
            {
                MenuId = menu.Id,
                Products = await _combosHelper.GetComboProductsAsync(filter, menu.Category.Id),
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(AddMenuProductsViewModel model)
        {
            Menu menu = await _context.Menus.Include(m => m.Category).FirstOrDefaultAsync(m => m.Id == model.MenuId);
            if (ModelState.IsValid)
            {
                MenuProducts menuProducts = new()
                {
                    Product = await _context.Products.FindAsync(model.ProductId),
                    Menu = menu,
                };
                try
                {
                    _context.Add(menuProducts);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(AddProduct), new { Id = menu.Id });
                }

                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            List<Product> filter = menu.MenuProducts.Select(pc => new Product
            {
                Id = pc.Product.Id,
                NameProd = pc.Product.NameProd
            }).ToList();
            model.Products = await _combosHelper.GetComboProductsAsync(filter, menu.Category.Id);
            return View(model);
        }

    }
}
