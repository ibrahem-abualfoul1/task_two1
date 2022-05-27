using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using task_two.Data;
using task_two.Models;


namespace task_two.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly UserContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CategoriesController(UserContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            return View(await _context.categories.ToListAsync());
        }
        // GET: categories/Details/5
        public async Task<IActionResult> Details(int? id )
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.categories
               
                .FirstOrDefaultAsync(m => m.IdCategory == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }
        // GET: categories/Create
        public IActionResult Create()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            return View();
        }

        // POST: categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category categorie)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + categorie.ImageFile_Category.FileName;
                string extension = Path.GetExtension(categorie.ImageFile_Category.FileName);
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await categorie.ImageFile_Category.CopyToAsync(fileStream);
                }
                categorie.UrlCategory = fileName;


                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categorie);
        }
        // GET: categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.categories.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category categorie)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            if (id != categorie.IdCategory)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + categorie.ImageFile_Category.FileName;
                    string extension = Path.GetExtension(categorie.ImageFile_Category.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await categorie.ImageFile_Category.CopyToAsync(fileStream);
                    }
                    categorie.UrlCategory = fileName;

                    _context.Update(categorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!categorieExists(categorie.IdCategory))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(categorie);
        }

        // GET: categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.categories
                .FirstOrDefaultAsync(m => m.IdCategory == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            var categorie = await _context.categories.FindAsync(id);
            _context.categories.Remove(categorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {


            if (HttpContext.Session.GetString("usernae_secc") != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");

            }



            return View();
        }

        private bool categorieExists(decimal id)
        {
            return _context.categories.Any(e => e.IdCategory == id);
        }
    }
}