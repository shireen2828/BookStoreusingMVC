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
    public class WishlistController : Controller
    {
        private readonly IWishlistManager wishlistManager;
        public WishlistController(IWishlistManager wishlistManager)
        {
            this.wishlistManager = wishlistManager;
        }
        // GET: Wishlist
        [HttpGet]
        public ActionResult Getwishlist()
        {
            try
            {
                var result = this.wishlistManager.Getwishlist();
                ViewBag.Message = "retrieved";
                return View(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Authorize]
        [HttpPost]
        public JsonResult AddToWishlist(WishlistModel wishlist, string Email)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;

                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var email = claims.Where(p => p.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").FirstOrDefault()?.Value;

                    var result = this.wishlistManager.AddToWishlist(wishlist, Email);
                    if (result != null)
                    {
                        return Json(new { status = true, Message = "added", Data = result });
                    }
                }

                    return Json(new { status = false, Message = "not added" });
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}