using FoodTrucksMenus.Data;
using FoodTrucksMenus.Data.Entities;
using FoodTrucksMenus.Helpers;
using FoodTrucksMenus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodTrucksMenus.Controllers
{
    public class TruckController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        public TruckController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Trucks != null ?
                        View(await _context.Trucks
                .Include(T => T.Branch)
                .ThenInclude(P => P.Menus)
                .Include(B => B.TruckPlatforms)
                .ThenInclude(B => B.Platform)
                .Include(B => B.TruckCategories)
                .FirstOrDefaultAsync(m => m.Id == 1)) :
                        Problem("Entity set 'DataContext.Trucks' is null.");
        }
        public async Task<IActionResult> CreateBranch()
        {
            AddOrEditBranchViewModel model = new()
            {
                Countries = await _combosHelper.GetComboCountriesAsync(),
                States = await _combosHelper.GetComboStatesAsync(0),
                Cities = await _combosHelper.GetComboCitiesAsync(0),
                Truck = await _context.Trucks.FirstOrDefaultAsync( t => t.Id == 1)
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)

            {
                Product product = new()
                {
                    Description = model.Description,
                    NameProd = model.Name,
                    PriceOfert = model.PriceOfert,
                    PriceSale = model.PriceSale,
                    PurchasePrice = model.PurchasePrice,
                    Truck = await _context.Trucks.FindAsync(1),
                    PrepTime = Convert.ToInt32(60 * model.PrepTime),
                    Cant = model.Cant,
                    Status = model.Status,
                    DateCreated = DateTime.Now,
                    Category = await _context.Categories.FindAsync(model.CategoryId),
                };

                if (model.ImageFile != null)
                {
                    product.ProductImages = new List<ProductImage>()
                    {
                               new ProductImage { ImagenProduct = model.ImageFile.FileName }
                    };
                    //Uploads(model.ImageFile);
                }
                try
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un producto con el mismo nombre.");
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
            return View(model);
        }

        public JsonResult GetStates(int countryId)
        {
            Country country = _context.Countries
                .Include(c => c.States)
                .FirstOrDefault(c => c.Id == countryId);
            if (country == null)
            {
                return null;
            }

            return Json(country.States.OrderBy(d => d.Name));
        }

        public JsonResult GetCities(int stateId)
        {
            State state = _context.States
                .Include(s => s.Cities)
                .FirstOrDefault(s => s.Id == stateId);
            if (state == null)
            {
                return null;
            }

            return Json(state.Cities.OrderBy(c => c.Name));
        }
    }
}
