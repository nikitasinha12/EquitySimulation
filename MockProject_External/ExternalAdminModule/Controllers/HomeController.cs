using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExternalAdminModule.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult AfterLogin()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Admin(FormCollection collection)
        {
            string username = collection["name"];
            string password = collection["pwd"];

                if (username == "" || password == "")
                {
                    ViewData["Message"] = "Please enter ID and Password.";
                    return View("Admin");
                }
            External_DatabaseEntities dbinstance = new External_DatabaseEntities();
            var list = dbinstance.Users.ToList();
            foreach (var item in list)
            {
                if (item.UserName == username && item.Password == password)
                {
                    
                    return View("AfterLogin");
                }

             
            }

               
                    ViewData["Message"] = "Invalid Username or Password.";
                    return View("Admin");
                
           

        } 
    }
}