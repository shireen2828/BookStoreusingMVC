using ManagerLayer.Interfaces;
using ModelsLayer;
using RepositoryLayer.Interaces;
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel register)
        {
            try
            {
                var Result = this.userManager.RegisterUser(register);
                ViewBag.Message = "User added successfully";
                return RedirectToAction("Login");


            }
            catch (Exception ex)
            {
                ViewBag.Message = ex;
                return View();
            }

        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            try
            {
                var result = this.userManager.loginUser(login);
                ViewBag.Message = "logged in successfully";
                //return View();
                return RedirectToAction("GetBooks", "Books");

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex;
                return View();
            }
        }
    }
}