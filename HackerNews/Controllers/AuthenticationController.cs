
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HackerNews.Controllers
{
    
        public class UserViewModel
        {
            public string Name { get; set; }
            public static bool IsAuthenticated { get; set; }
            
        }


        public class AuthenticationController : Controller
    {
            public ActionResult Signup()
            {
                
                return View();
                
            }

            [HttpPost]
            public ActionResult Signup(string username, string name, string password)
            {
                var mgr = new HackerNews.Models.UserManager(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True");
                mgr.AddUser(username, password, name);

                return RedirectToAction("Signin");
            }


            public ActionResult Signin()
            {
                return View(new UserViewModel());
            }

            [HttpPost]
            public ActionResult Signin(string username, string password)
            {
                var mgr = new HackerNews.Models.UserManager(@"Data Source=.\sqlexpress;Initial Catalog=HackerNews;Integrated Security=True");
                var user = mgr.GetUser(username, password);
                if (user == null)
                {
                    return View(new UserViewModel { Name = username });
                }

                FormsAuthentication.SetAuthCookie(user.UserName, true);
                UserViewModel.IsAuthenticated = User.Identity.IsAuthenticated;
                return RedirectToAction("Private");
            }

            [Authorize]
            public ActionResult Private()
            {
                return View();
            }

            public ActionResult Signout()
            {
                FormsAuthentication.SignOut();
                UserViewModel.IsAuthenticated = User.Identity.IsAuthenticated;
                return RedirectToAction("Signin");
            }

        }

    }

