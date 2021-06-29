using ManagerLayer.Interfaces;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BookstoreProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager userManager;

        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }
        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel register)
        {
            try
            {
                var Result = this.userManager.RegisterUser(register);
                ViewBag.Message = "User registered successfully";
                // return View();
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                return ViewBag.Message = "User registration unsuccessfull";
            }
        }
    }
}