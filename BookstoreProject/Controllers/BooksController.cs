using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
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

        private string CloudImageLink(HttpPostedFileBase file)
        {
            if(file == null)
            {
                return null;
            }
            var filepath = file.InputStream;
            string uniquename = Guid.NewGuid().ToString() + "_" + file.FileName;
            Account account = new Account("dgnbyfjo3", "469894678244667", "uNu6qqi1rfBRFuDCIbQTUHTIEGk");
            Cloudinary cloud = new Cloudinary(account);
            var uploadparam = new ImageUploadParams()
            {
                File = new FileDescription(uniquename, filepath)
            };
            var uploadResult = cloud.Upload(uploadparam);
            return uploadResult.Url.ToString();
        }
        
        [HttpPost]
        public ActionResult UploadImage(int BookId, HttpPostedFileBase image)
        {
            try
            {
                var addImage = CloudImageLink(image);
                bool result = this.booksManager.UploadImage(BookId, addImage);
                if(result == true)
                {
                    return Json(new { status = true, Message = "Image uploaded", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "failed to add" });
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}