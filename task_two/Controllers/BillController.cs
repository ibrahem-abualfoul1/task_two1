using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task_two.Data;
using task_two.Models;

namespace task_two.Controllers
{
    public class BillController : Controller
    {
        private readonly UserContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public BillController(UserContext context, IWebHostEnvironment _hostEnvironment)
        {
            this._hostEnvironment = _hostEnvironment;
            _context = context;
        }
        // GET: BillController
        public async Task<IActionResult> Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            return View(await _context.bills.ToListAsync());
        }
        // GET: BillController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.bills

                .FirstOrDefaultAsync(m => m.IdBill== id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }


        // GET: BillController/Create
        public IActionResult Create()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            return View();
        }

        // POST: BillController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bill categorie)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            if (ModelState.IsValid)
            {

                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(categorie);
        }

        // GET: BillController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.bills.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: BillController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bill categorie)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            if (id != categorie.IdBill)
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
                    if (!categorieExists(categorie.IdBill))
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

        // GET: BillController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.bills
                .FirstOrDefaultAsync(m => m.IdBill == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BillController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            var categorie = await _context.bills.FindAsync(id);
            _context.bills.Remove(categorie);
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
            return _context.bills.Any(e => e.IdBill == id);
        }


    }
}
