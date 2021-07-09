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

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {

            try
            {
                var result = this.userManager.loginUser(login);
                //ViewBag.Message = "logged in successfully";
                //return View();
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
                
                ViewBag.Token = tokenString;
                LoginModel Tokenname = new LoginModel()
                {
                    Token = tokenString
                };
                return this.View("Login", Tokenname);
                //RedirectToAction("GetBooks", "Books");

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex;
                return View();
            }
        }



        //public ActionResult GetToken()
        //{
        //    var issuer = "self";
        //    var allowedAudience = "http://localhost";
        //    var secretKey = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
        //    var digestAlgorithm = "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256";
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var now = DateTime.UtcNow;
        //    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature, digestAlgorithm);
        //    var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Email, "shireenkk28@gmail.com", ClaimValueTypes.String),
        //            new Claim(ClaimTypes.Sid, "1",ClaimValueTypes.Integer32),
        //        };
        //    var roles = new List<string>() { "Login" };
        //    claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        //    var identity = new GenericIdentity("User");
        //    var tokenDesriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(identity, (IEnumerable<System.Security.Claims.Claim>)claims),
        //        TokenIssuerName = issuer,
        //        AppliesToAddress = allowedAudience,
        //        Lifetime = new Lifetime(now, now.AddDays(1)),
        //        SigningCredentials = signinCredentials,
        //    };
        //    var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDesriptor));

        //    ViewBag.Token = token;
        //    return this.View(token);

        //}
    }
}