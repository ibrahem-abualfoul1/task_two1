using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using task_two.Data;
using task_two.Models;

namespace task_two.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _userContext;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UserController( UserContext userContext , IWebHostEnvironment hostEnvironment)
        {
            _userContext = userContext;
            _hostEnvironment = hostEnvironment;

        }
        public IActionResult Index()
        {
       
          

            return View();
        }
     
        // register
        [HttpGet]
        public IActionResult register()
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Account user)
        {
            if (ModelState.IsValid)
            {
                var chek = _userContext.User.Where(x => x.UerName == user.UerName && x.Email == user.Email && x.Phone_number == user.Phone_number).FirstOrDefault();
                if (null == chek)
                {
                    user.RoleId = 2;
                    user.DateRegister = DateTime.Now;

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + user.ImageFile_back.FileName;
                    string extension = Path.GetExtension(user.ImageFile_back.FileName);
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await user.ImageFile_back.CopyToAsync(fileStream);
                    }
                    user.Background = fileName;


                    _userContext.Add(user);
                    await _userContext.SaveChangesAsync();
                    return RedirectToAction("login", "User");
                }
                else
                {

                    TempData["message"] = "failed register , please again register.";
                    return RedirectToAction("Accout", "register");
                }


            }

            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> login(string UserName , string Password)
        {
            const string id = "id";
            const string usernae_secc = "usernae_secc";
            const string RoleId = "RoleId";
           
                var auth = _userContext.User.Where(x => x.UerName == UserName && x.Password == Password).SingleOrDefault();
          
                if (auth != null)
                {
                    switch (auth.RoleId)
                    {
                        case 1:
                            HttpContext.Session.SetInt32(id, Convert.ToInt32(auth.Id.ToString()));
                            HttpContext.Session.SetInt32(RoleId, Convert.ToInt32(auth.RoleId.ToString()));
                            HttpContext.Session.SetString(usernae_secc, auth.UerName.ToString());
                            return RedirectToAction("admin", "Home");

                        case 2:

                            HttpContext.Session.SetInt32(RoleId, Convert.ToInt32(auth.RoleId.ToString()));
                            HttpContext.Session.SetInt32(id, Convert.ToInt32(auth.Id.ToString()));
                            HttpContext.Session.SetString(usernae_secc, auth.UerName.ToString());
                            return RedirectToAction("Test", "User");


                    }



                }
            
            else
            {

                TempData["login"] = "failed login , please again login.";
                return RedirectToAction("login", "user");
            }

           


            return View();
        }

        public IActionResult Test()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            var itemCategories = _userContext.categories.ToList();
            var itemMangePage = _userContext.mangePages.ToList();
            var itemprodacts = _userContext.prodacts.ToList();
            var itemmessege = _userContext.messeges.ToList();
            var itemtestmonel = _userContext.testimonials.ToList();
            
            

            var modelitems = Tuple.Create<IEnumerable<task_two.Models.Category>, IEnumerable<task_two.Models.Prodact>, IEnumerable<task_two.Models.Messege>, IEnumerable<task_two.Models.MangePage>, IEnumerable<task_two.Models.Testimonial>>(itemCategories, itemprodacts, itemmessege, itemMangePage, itemtestmonel);
            return View(modelitems);
        }
       
        public IActionResult Logout()
        {
           

            if(HttpContext.Session.GetString("usernae_secc") != null)
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
            ViewBag.id = c;
            var pro2 = _userContext.prodacts.Where(x => x.IdCategory == c).ToList();
            return View(pro2);
        }
        public IActionResult showproudact()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            var itemprodacts = _userContext.prodacts.ToList();
            var modelitems = Tuple.Create<IEnumerable<task_two.Models.Prodact>>(itemprodacts);
            return View(modelitems);

        }
      
        public IActionResult Profiel()
        {
            var UserData = _userContext.User.SingleOrDefault(x => x.Id == HttpContext.Session.GetInt32("id"));
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            ViewBag.ProPic = HttpContext.Session.GetString("ProPic");
            return View(UserData);
        }
        [HttpPost]
        public IActionResult Profiel(string FName, string LName, string Email, string UName, string Password, IFormFile ProfilePicture)
        {
            Account UserData = _userContext.User.SingleOrDefault(x => x.Id == HttpContext.Session.GetInt32("id"));
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");

            ViewBag.ProPic = HttpContext.Session.GetString("ProPic");
            UserData.Name = FName;
            UserData.UerName = LName;
            UserData.Email = Email;
            UserData.Password = Password;
            UserData.ImageFile_back = ProfilePicture;
            UserData.Phone_number = UName;
            _userContext.User.Update(UserData);
            _userContext.SaveChanges();
            return View(UserData);
        }
        [HttpGet]
        public IActionResult Cart(Cart cart)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            var UserData = HttpContext.Session.GetInt32("id");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            cart.id_user = UserData;
            var count = _userContext.carts.Where(x => x.id_user == cart.id_user);
            var itemprodacts = _userContext.prodacts.ToList();
            var itemcart = _userContext.carts.ToList();
            var modelitems = Tuple.Create<IEnumerable<task_two.Models.Prodact>,IEnumerable<task_two.Models.Cart>>(itemprodacts,itemcart);

            return View(modelitems);
        }

        [HttpGet]
        public IActionResult AddToCart(int c)
        {
            ViewBag.id = c;
            var pro2 = _userContext.prodacts.Where(x => x.IdProdact == c ).ToList();
            var itemprodacts = _userContext.prodacts.ToList();
            var itemcart = _userContext.carts.ToList();
            var modelitems = Tuple.Create<IEnumerable<task_two.Models.Prodact>, IEnumerable<task_two.Models.Cart>>(itemprodacts, itemcart);

            return View(modelitems);
           
        }
        [HttpPost]
        public IActionResult AddToCart(Cart cart, Prodact prodact)
        {
            var pro2 = _userContext.prodacts.Where(x => x.IdProdact == prodact.IdProdact).FirstOrDefault();
            var UserData = HttpContext.Session.GetInt32("id");
            cart.id_user = UserData;
            var order = _userContext.carts.Where(x => x.id_user == cart.id_user).FirstOrDefault();

            if (order == null)
            {
                cart.CartProdactTrans = pro2;
                cart.order = false;
                _userContext.Add(cart);

            }
            else
            {
                cart.CartProdactTrans = pro2;
                cart.order = false;

                _userContext.Add(cart);


            }
           
         
            _userContext.SaveChanges();

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            _userContext.SaveChanges();

            return RedirectToAction("cart", "User");

        }

        [HttpGet]
        public IActionResult Buy(int c)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            var itemcart = _userContext.carts.ToList();
            var itemprodacts = _userContext.prodacts.ToList();
            ViewBag.id = c;
            var pro2 = _userContext.carts.Where(x => x.id_user == c && x.order == false).ToList();
           
            var modelitems = Tuple.Create<IEnumerable<task_two.Models.Cart>, IEnumerable<task_two.Models.Prodact>>(itemcart, itemprodacts );

            return View(modelitems);
        }
        [HttpPost]
        public IActionResult Buy(Bill bill, Prodact prodact , Cart cart)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            var pro2 = _userContext.prodacts.Where(x => x.IdProdact == prodact.IdProdact).FirstOrDefault();
            var UserData = HttpContext.Session.GetInt32("id");
            bill.DateBill = DateTime.Now;
            bill.Id_regester = UserData;
            bill.activebill = false;
            bill.IdProdactTrans = pro2;
            _userContext.Add(bill);
            _userContext.SaveChanges();
            cart.order = true;
            _userContext.Update(cart);
            Transaction tran = new Transaction { idbill = bill.IdBill, NameBill = bill.NameBill, Price = bill.Price, IdUser = UserData, DateBill = DateTime.Now, activebill = bill.activebill };
            _userContext.Add(tran);

            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            _userContext.SaveChanges();

            return RedirectToAction("test", "User");

        }
    }
}
