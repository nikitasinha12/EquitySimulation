using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExternalAdminModule.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string username = collection["username"];
            string password = collection["password"];


            External_DatabaseEntities dbinstance = new External_DatabaseEntities();
            var list = dbinstance.Users.ToList();
        
            foreach (var item in list)
            {
                if (item.UserName == username && item.Password == password)
                {
                    ViewData["Message"] = "Login succesfull";
                    return View();
                }

            }
            ViewData["Message"] = "Login unsuccesfull";
            return View();

        } 

    }
}