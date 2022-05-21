using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using task_two.Data;
using task_two.Models;

namespace task_two.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserContext _context;

        public HomeController(ILogger<HomeController> logger , UserContext contxt)
        {
            _logger = logger;
            _context = contxt;

        }

        public IActionResult Index()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");

            var itemCategories = _context.categories.ToList();
            var itemMangePage = _context.mangePages.ToList();
            var itemprodacts = _context.prodacts.ToList();
            var itemmessege = _context.messeges.ToList();

            var modelitems = Tuple.Create<IEnumerable<task_two.Models.Category>, IEnumerable<task_two.Models.Prodact> , IEnumerable<task_two.Models.Messege> , IEnumerable<task_two.Models.MangePage>>(itemCategories, itemprodacts, itemmessege , itemMangePage);
            return View(modelitems);
        }
        [HttpGet]
        public IActionResult showproudact(int c)
        {
            ViewBag.id = c;
            var pro2 = _context.prodacts.Where(x => x.IdCategory == c).ToList();
            return View(pro2);
        }
        public IActionResult About_us()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            return View();
        }
        public IActionResult admin()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            return View();
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
        public IActionResult showproudact()
        {
            var itemprodacts = _context.prodacts.ToList();
            var modelitems = Tuple.Create<IEnumerable<task_two.Models.Prodact>>( itemprodacts);
            return View(modelitems);
            
        }
        public IActionResult _Clients()
        {
            return View();
        }

        [HttpPost]
        public IActionResult _Clients(Messege messege)
        {
            messege.ResivedEmail = "abualoul@gmail.com";
          

            _context.messeges.Add(messege);
            _context.SaveChanges();
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
