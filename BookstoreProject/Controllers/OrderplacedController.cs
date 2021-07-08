using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookstoreProject.Controllers
{
    public class OrderplacedController : Controller
    {
        // GET: Orderplaced
        public ActionResult Order()
        {
            return View();
        }
    }
}