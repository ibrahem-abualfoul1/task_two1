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
    public class TransactionsController : Controller
    {
        private readonly UserContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TransactionsController(UserContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            return View(await _context.transactions.ToListAsync());
        }
        // GET: MangePages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.transactions

                .FirstOrDefaultAsync(m => m.IdTransaction == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }
        // GET: MangePages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MangePages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transaction categorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categorie);
        }
        // GET: Testimonial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.transactions.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: Testimonial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Transaction categorie)
        {
            if (id != categorie.IdTransaction)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(categorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!categorieExists(categorie.IdTransaction))
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

        // GET: Testimonial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            
                if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.transactions
                .FirstOrDefaultAsync(m => m.IdTransaction == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: Testimonial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorie = await _context.transactions.FindAsync(id);
            _context.transactions.Remove(categorie);
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
            return _context.transactions.Any(e => e.IdTransaction == id);
        }
    }
}