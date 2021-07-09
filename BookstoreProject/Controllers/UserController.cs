using ManagerLayer.Interfaces;
using Microsoft.IdentityModel.Tokens;
using ModelsLayer;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Mvc;

namespace BookstoreProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        //private readonly string _secret;
        //private readonly string _issuer;
        private const string Secret = "my_secret_key_12345";
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
            //_secret = "Thisismysecretkey";
            //_issuer = "https://localhost:44380";
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

        [AllowAnonymous]
        [HttpPost]
        public JsonResult Login(LoginModel login)
        {

            try
            {
                var result = this.userManager.loginUser(login);
                //ViewBag.Message = "logged in successfully";

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Secret);
                var tokenDescriptor = new SecurityTokenDescriptor

                {
                    Issuer = "self",
                    Audience = "http://localhost",
                    Subject = new ClaimsIdentity(new Claim[]
                    {

                    new Claim(ClaimTypes.Email, login.Email),
                    new Claim("ServiceType", "User"),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(600),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                Session["Token"] = tokenString;
                ViewBag.Token = tokenString;
                LoginModel Tokenname = new LoginModel()
                {
                    Token = tokenString
                };
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { result = "success", Token = tokenString, returnUrl = "https://localhost:44301/Books/GetBooks" }
                };
                //return this.View("Login", Tokenname);
                //RedirectToAction("GetBooks", "Books");

            }
            catch (Exception ex)
            {
                
                return ViewBag.Message = ex;
            }
        }

        public ActionResult loginuser(LoginModel userlogin)
        {
            return View(userlogin);
        }
    }
}