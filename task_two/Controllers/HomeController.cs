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
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            var itemCategories = _context.categories.ToList();
            var itemMangePage = _context.mangePages.ToList();
            var itemprodacts = _context.prodacts.ToList();
            var itemmessege = _context.messeges.ToList(); 
           


            var itemtestmonil = _context.testimonials.ToList();   
            

            var modelitems = Tuple.Create<IEnumerable<task_two.Models.Category>, IEnumerable<task_two.Models.Prodact> , IEnumerable<task_two.Models.Messege> , IEnumerable<task_two.Models.MangePage>, IEnumerable<task_two.Models.Testimonial>>(itemCategories, itemprodacts, itemmessege , itemMangePage,itemtestmonil);
            return View(modelitems);
        }
      
        public IActionResult About_us()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId"); 
            var itemmangepage = _context.mangePages.ToList();

            var modelitems = Tuple.Create<IEnumerable<task_two.Models.MangePage>>(itemmangepage);
            return View(modelitems);
        }
        public IActionResult admin()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
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
        [HttpGet]
        public IActionResult showproudact(int c)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            ViewBag.idprodact = c;
            var pro2 = _context.prodacts.Where(x => x.IdCategory == c).ToList();
            return View(pro2);
        }
        public IActionResult showproudact()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            var itemprodacts = _context.prodacts.ToList();
            var modelitems = Tuple.Create<IEnumerable<task_two.Models.Prodact>>( itemprodacts);
            return View(modelitems);
            
        }
   
        public IActionResult Contact_Us()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            return View();
        }

        [HttpPost]
        public IActionResult Contact_Us(Messege messege)
        {

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            messege.ResivedEmail = "abualoul@gmail.com";
          

            _context.messeges.Add(messege);
            _context.SaveChanges();
            return View();
        }
        [HttpPost]
        public IActionResult Creattest(Testimonial test)
        {

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            if (ModelState.IsValid)
            {
                var UserData = HttpContext.Session.GetInt32("id");
                test.Id_regester = UserData;
                test.active = false;
                _context.testimonials.Add(test);
                _context.SaveChanges();
                  return RedirectToAction("test", "User");
            }
           
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
