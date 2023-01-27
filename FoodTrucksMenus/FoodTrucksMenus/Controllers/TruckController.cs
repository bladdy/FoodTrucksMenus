using FoodTrucksMenus.Data;
using FoodTrucksMenus.Data.Entities;
using FoodTrucksMenus.Helpers;
using FoodTrucksMenus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                .Include(M => M.Menu)
                .ThenInclude(MP => MP.MenuProducts)
                .Include(B => B.TruckPlatforms)
                .ThenInclude(B => B.Platform)
                .Include(B => B.TruckCategories)
                .ThenInclude(c=> c.Category)
                //.Include(T => T.t)
                .FirstOrDefaultAsync(m => m.Id == 1)) :
                        Problem("Entity set 'DataContext.Trucks' is null.");
        }
        public async Task<IActionResult> CreateBranch()
        {
            AddOrEditBranchViewModel model = new()
            {
                Id = 0,
                Countries = await _combosHelper.GetComboCountriesAsync(),
                States = await _combosHelper.GetComboStatesAsync(0),
                Cities = await _combosHelper.GetComboCitiesAsync(0),
                TruckId = 1
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBranch(AddOrEditBranchViewModel model)
        {
            if (ModelState.IsValid)

            {
                Branch branch = new()
                {
                    NameBranch = model.Name,
                    Phone = model.Phone,
                    Address = model.Address,
                    IsMain = model.IsMain,
                    TablesNumbers = model.TablesNumbers,
                    Truck = await _context.Trucks.FindAsync(model.TruckId),
                    City = await _context.Cities.FindAsync(model.CityId)
                };

                try
                {
                    _context.Add(branch);
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

            model.Countries = await _combosHelper.GetComboCountriesAsync();
            model.States = await _combosHelper.GetComboStatesAsync(model.CountryId);
            model.Cities = await _combosHelper.GetComboCitiesAsync(model.StateId);
            return View(model);
        }
        //ToDo: Agregar plataforma como el agregar producto al menu
        public async Task<IActionResult> AddPlatforms(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Truck truck = await _context.Trucks
                .Include(MP => MP.TruckPlatforms)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (truck == null)
            {
                return NotFound();
            }
            /*List<Platform> filter = truck.TruckPlatforms.Select(pc => new Platform
            {
                Id = pc.Platform.Id,
                Name = pc.Platform.Name
            }).ToList();*/
            AddTruckPlatformsViewModel model = new()
            {
                TruckId = truck.Id,
                Platforms = await _combosHelper.GetComboPLatformsAsync(),
            };
            
            
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPlatforms(AddTruckPlatformsViewModel model)
        {
            Truck truck = await _context.Trucks.FirstOrDefaultAsync(m => m.Id == model.TruckId);
            if (ModelState.IsValid)
            {
                TruckPlatform truckPlatform = new()
                {
                    Platform = await _context.Platforms.FindAsync(model.PlatformsId),
                    Truck = truck,
                };
                try
                {
                    _context.Add(truckPlatform);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(AddPlatforms), new { Id = truck.Id });
                }

                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una plataforma para este Truck con el mismo nombre.");
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
            List<Platform> filter = truck.TruckPlatforms.Select(pc => new Platform
            {
                Id = pc.Platform.Id,
                Name = pc.Platform.Name
            }).ToList();
            model.Platforms = await _combosHelper.GetComboPLatformsAsync();
            return View(model);
        }
        public JsonResult? GetCities(int stateId)
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
        public JsonResult DeletePlatform(int PlataformsId)
        {
            bool result = false;
            TruckPlatform truckPlatform = _context.TruckPlatforms.FirstOrDefault(m => m.Id == PlataformsId);
            if (truckPlatform != null)
            {
                
                _context.Remove(truckPlatform);
                _context.SaveChangesAsync();
                result = true;
            }

            return Json(result);
        }
        public JsonResult? GetStates(int countryId)
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
    }
}
