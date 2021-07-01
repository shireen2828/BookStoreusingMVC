using ManagerLayer.Interfaces;
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
    }
}