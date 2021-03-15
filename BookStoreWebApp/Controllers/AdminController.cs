using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStore.Models;
using BookStoreWebApp.Helpers;

namespace BookStoreWebApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            var book = BookStoreFunctions.GetFullBookById(id);
            return View(book);
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = DropDownFormatter.FormatGenres();
            ViewBag.AuthorId = DropDownFormatter.FormatAuthors();

            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book bookToCreate)
        {
            try
            {
                BookStoreAdminfunctions.AddBook(bookToCreate);
                return RedirectToAction("Books","Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = BookStoreFunctions.GetFullBookById(id);
            ViewBag.GenreId = DropDownFormatter.FormatGenres();
            ViewBag.AuthorId = DropDownFormatter.FormatAuthors();
            return View(book);
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book bookToEdit)
        {
            try
            {
                BookStoreAdminfunctions.EditBook(bookToEdit);
                return RedirectToAction("Books", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = BookStoreFunctions.GetFullBookById(id);
            return View(book);
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book book)
        {
            try
            {
                BookStoreAdminfunctions.DeleteBook(book.BookId);
                return RedirectToAction("Books", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
