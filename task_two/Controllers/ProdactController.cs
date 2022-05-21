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
    public class ProdactController : Controller
    {
        private readonly UserContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProdactController(UserContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            var modelContext = _context.prodacts.Include(p => p.Catigory);
            return View(await modelContext.ToListAsync());
        }
        // GET: Productes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producte = await _context.prodacts
                .Include(p => p.Catigory)
                .FirstOrDefaultAsync(m => m.IdProdact== id);
            if (producte == null)
            {
                return NotFound();
            }

            return View(producte);
        }
        // GET: Productes/Create
        public IActionResult Create()
        {
            ViewData["IdCategory"] = new SelectList(_context.categories, "IdCategory", "IdCategory");
            return View();
        }

        // POST: Productes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Prodact producte)
        {
            if (ModelState.IsValid)
            {

                producte.DateProdact = DateTime.Now;

                    _context.Add(producte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategory"] = new SelectList(_context.categories, "IdCategory", "IdCategory", producte.Catigory.IdCategory);

            return View(producte);
        }
        // GET: Productes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producte = await _context.prodacts.FindAsync(id);
            if (producte == null)
            {
                return NotFound();
            }
            ViewData["IdCategory"] = new SelectList(_context.categories, "IdCategory", "IdCategory", producte.Catigory);
            return View(producte);
        }

        // POST: Productes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Prodact producte)
        {
            if (id != producte.IdProdact)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    producte.DateProdact = DateTime.Now;

                    _context.Update(producte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProducteExists(producte.IdProdact))
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
            ViewData["IdCategory"] = new SelectList(_context.categories, "IdCategory", "IdCategory", producte.Catigory);

            return View(producte);
        }

        // GET: Productes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producte = await _context.prodacts
                .Include(p => p.Catigory)
                .FirstOrDefaultAsync(m => m.IdProdact == id);
            if (producte == null)
            {
                return NotFound();
            }

            return View(producte);
        }

        // POST: Productes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producte = await _context.prodacts.FindAsync(id);
            _context.prodacts.Remove(producte);
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

        private bool ProducteExists(decimal id)
        {
            return _context.prodacts.Any(e => e.IdProdact == id);
        }
    }
}
