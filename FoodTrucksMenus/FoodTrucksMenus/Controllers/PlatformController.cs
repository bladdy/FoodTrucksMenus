using FoodTrucksMenus.Data;
using FoodTrucksMenus.Data.Entities;
using FoodTrucksMenus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace FoodTrucksMenus.Controllers
{
    public class PlatformController : Controller
    {
        private readonly DataContext _context;
        //ToDo: crear la vista de editar plataforma
        public PlatformController(DataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Platforms
                .ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddorEditPlatformViewModel model)
        {
            Platform platform;
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.IconLogo != null)
                    {
                        Uploads(model.IconLogo);
                        platform = new Platform()
                        {
                            Name = model.Name,
                            IconLogo = model.IconLogo.FileName

                        };
                    }
                    else
                    {
                        platform = new Platform()
                        {
                            Name = model.Name
                        };
                    }

                    _context.Add(platform);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una platform con el mismo nombre");

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
        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platform = await _context.Platforms
                .FirstOrDefaultAsync(c => c.Id == id);
            if (platform == null)
            {
                return NotFound();
            }

            return View(platform);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var platform = await _context.Platforms.FindAsync(id);
            _context.Platforms.Remove(platform);
            await _context.SaveChangesAsync();
            DeleteImg(platform.IconLogo);
            return RedirectToAction(nameof(Index));
        }
        private void DeleteImg(string files)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Platform");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                

                string fileNameWithPath = Path.Combine(path, files);

                FileInfo fileInfo = new FileInfo(fileNameWithPath);
                fileInfo.Delete();
               

            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
            }
        }
        private void Uploads(IFormFile files)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Platform");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                FileInfo fileInfo = new FileInfo(files.FileName);
                string[] fileEx = files.FileName.Split(".");
                string fileName = fileEx[0] + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    files.CopyTo(stream);
                }
                
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
            }
            
        }
    }
}
