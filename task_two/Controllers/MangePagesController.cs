using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_two.Controllers
{
    public class MangePagesController : Controller
    {
        // GET: MangePagesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MangePagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MangePagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MangePagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MangePagesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MangePagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MangePagesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MangePagesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
