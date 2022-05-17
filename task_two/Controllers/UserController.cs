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
                    user.IdRole = 2;
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
        public IActionResult login(string UserName , string Password)
        {
            const string id = "id";
            const string usernae_secc = "usernae_secc";
          
            var auth = _userContext.User.Where(x => x.UerName == UserName && x.Password == Password).SingleOrDefault();
            if (auth != null)
            {
                switch (auth.IdRole)
                {
                    case 1:
                        HttpContext.Session.SetInt32(id, Convert.ToInt32(auth.Id.ToString()));
                        HttpContext.Session.SetString(usernae_secc, auth.UerName.ToString());
                        return RedirectToAction("admin", "Home");

                    case 2:
                        HttpContext.Session.SetInt32(id, Convert.ToInt32(auth.Id.ToString()));
                        HttpContext.Session.SetString(usernae_secc, auth.UerName.ToString());
                        return RedirectToAction("Test", "User");

              
                }
               
                return RedirectToAction("Test", "User");
            }
            return View();
        }
        public IActionResult Test()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            var itemCategories = _userContext.categories.ToList();
            var itemprodacts = _userContext.prodacts.ToList();
            var itemmessege = _userContext.messeges.ToList();

            var modelitems = Tuple.Create<IEnumerable<task_two.Models.Category>, IEnumerable<task_two.Models.Prodact>, IEnumerable<task_two.Models.Messege>>(itemCategories, itemprodacts, itemmessege);
            return View(modelitems);
        }
        public IActionResult Logout()
        {
         
            HttpContext.Session.Clear();
            return RedirectToAction("", "Home");
        }
        [HttpGet]
        public IActionResult showproudact(int c)
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            ViewBag.id = c;
            var pro2 = _userContext.prodacts.Where(x => x.IdCategory == c).ToList();
            return View(pro2);
        }
        public IActionResult showproudact()
        {
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
            var itemprodacts = _userContext.prodacts.ToList();
            var modelitems = Tuple.Create<IEnumerable<task_two.Models.Prodact>>(itemprodacts);
            return View(modelitems);

        }
        public IActionResult Profiel()
        {
            var UserData = _userContext.User.SingleOrDefault(x => x.Id == HttpContext.Session.GetInt32("id"));
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");

            ViewBag.ProPic = HttpContext.Session.GetString("ProPic");
            return View(UserData);
        }
        [HttpPost]
        public IActionResult Profiel(string FName, string LName, string Email, string UName, string Password, IFormFile ProfilePicture)
        {
            Account UserData = _userContext.User.SingleOrDefault(x => x.Id == HttpContext.Session.GetInt32("id"));
            ViewBag.id = HttpContext.Session.GetInt32("id");
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");
          
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
      
    }
}
