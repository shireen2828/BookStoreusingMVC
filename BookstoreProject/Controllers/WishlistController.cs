using ManagerLayer.Interfaces;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public ActionResult AddToWishlist(WishlistModel wishlist)
        {
            try
            {
                var result = this.wishlistManager.AddToWishlist(wishlist);
                if(result != null)
                {
                    return Json(new { status = true, Message = "added", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "not added", Data = result });
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}