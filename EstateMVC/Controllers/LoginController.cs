using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EstateMVC.Controllers
{
    public class LoginController : Controller
    {
        // EF model of users
        private Models.LoginDBEntities db = new Models.LoginDBEntities();
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Logout
        public ActionResult Logout()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.Users objUser)
        {
            string hashedPassword = ComputeSHA256(objUser.Password);

            if (ModelState.IsValid)
            {
                if (ValidateUser(objUser.UserName, hashedPassword.ToString()))
                {
                    Session["UserName"] = objUser.UserName;
                    return RedirectToAction("Index", "Search");
                }
                else
                {
                    ModelState.AddModelError("", "Błędny login lub hasło!");
                }
            }
            return View(objUser);
        }

        // Hash calculator SHA256, returns string
        private string ComputeSHA256(string plainPass)
        {
            StringBuilder hashedPassword = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(plainPass));

                foreach (Byte b in result)
                    hashedPassword.Append(b.ToString("x2"));
            }
            return hashedPassword.ToString();
        }

        // Check if username and hashed password are OK
        private bool ValidateUser(string username, string hashedPass)
        {
            return db.Users.Any(x => x.UserName == username &&
                x.Password == hashedPass);
        }

        // Get user based on username and hashed password
        private Models.Users GetUser(string username, string hashedPass)
        {
            return db.Users.First(x => x.UserName == username &&
                x.Password == hashedPass);
        }    
    }
}