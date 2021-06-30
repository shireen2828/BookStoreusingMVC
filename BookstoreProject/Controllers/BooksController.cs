using ManagerLayer.Interfaces;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookstoreProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksManager booksManager;
        public BooksController(IBooksManager booksManager)
        {
            this.booksManager = booksManager;
        }

        public BooksController()
        {

        }
        // GET: Books
        public ActionResult GetBooks()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBooks(BooksModel books)
        {
            try
            {
                var result = this.booksManager.GetBooks();
                ViewBag.Message = "retrived the books";
                return View(result);
            }
            catch (Exception)
            {
                return ViewBag.Message = "failed";
            }
        }
    }
}