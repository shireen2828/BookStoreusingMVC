using ManagerLayer.Interfaces;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public ActionResult AddToCart(CartModel cart)
        {
            try
            {
                var result = this.cartManager.AddToCart(cart);
                if (result != null)
                {
                    return Json(new { status = true, Message = "added", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "not added", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}