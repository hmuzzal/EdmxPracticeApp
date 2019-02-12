using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EdmxPractiseApplication.Models;

namespace EdmxPractiseApplication.Controllers
{
    public class BooksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: /Books/
        public ActionResult Index()
        {
         
            return View(db.Books.ToList());
        }

        // GET: /Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


        public ActionResult BooksWrittenByAuthor()
        {
            ViewBag.Authors = db.Authors.ToList();
            ViewBag.Books = db.Books.ToList();
            return View();
        }


        [HttpPost]
        public ActionResult BooksWrittenByAuthor(Book book)
        {
            ViewBag.Authors = db.Authors.ToList();
           
            return View();
        }



        //[HttpPost]
        //public JsonResult BookList(string AuthorName)
        //{

         
        //    var BookList = db.Books.Where(c => c.BookAuthor == AuthorName).ToList();

        //    return Json(BookList, JsonRequestBehavior.AllowGet);
        //}


        public JsonResult BookList(string AuthorName)
        {
            var BookList = db.Books.ToList().Where(c => c.BookAuthor == AuthorName);
            return Json(BookList, JsonRequestBehavior.AllowGet);
        }



        public JsonResult AuthorList(string Prefix)
        {
            var AuthorList = db.Authors.ToList().Where(c => c.AuthorName.Contains(Prefix));
            return Json(AuthorList, JsonRequestBehavior.AllowGet);
        }





        // GET: /Books/Create
        public ActionResult Create()
        {
            ViewBag.Authors = db.Authors.ToList();
            return View();
        }

        // POST: /Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BookId,BookName,BookAuthor")] Book book)
        {
            ViewBag.Authors = db.Authors.ToList();
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: /Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BookId,BookName,BookAuthor")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: /Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: /Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
