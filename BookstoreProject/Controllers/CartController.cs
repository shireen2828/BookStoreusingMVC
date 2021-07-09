using ManagerLayer.Interfaces;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace BookstoreProject.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManager cartManager;
        public CartController(ICartManager cartManager)
        {
            this.cartManager = cartManager;
        }
        // GET: Cart

        [HttpGet]
        public ActionResult Getcart()
        {
            try
            {
                var result = this.cartManager.Getcart();
                ViewBag.Message = "retrieved";
                return View(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        [Authorize]
        [HttpPost]
        public JsonResult AddToCart(CartModel cart, string Email)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var email = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;
                    var result = this.cartManager.AddToCart(cart, Email);
                    if (result != null)
                    {
                        return Json(new { status = true, Message = "added", Data = result });
                    }
                }
                
                    return Json(new { status = false, Message = "not added" });
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}