using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RhymesUI.Models;

namespace RhymesUI.Controllers
{
    //[Authorize(Roles ="Admin,Management,Staff,Author")]
    public class BookController : Controller
    {
        private readonly IBookService _book;

        public BookController(IBookService book)
        {
            _book = book;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var books = _book.GetBooksAsync();
            return View(books);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(string bookId)
        {
            var book = _book.GetBookAsync(bookId);
            return View(book);
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(BookViewModel model)
        {
            var bookInDb = new Book {
                Title = model.Title,
                Synopsis = model.Synopsis,
                AuthorBio = model.AuthorBio,
                AuthorName = model.AuthorName,
                Genre = model.Genre,
                image = model.image,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                MarketingBudget = model.MarketingBudget,
                MarketingPlan = model.MarketingPlan,
                Quantity = model.Quantity,
                IsApproved = false,
                IsDeleted = false
            };
            _book.AddBookAsync(bookInDb);
            return RedirectToAction("Details", new { bookId = bookInDb.BookId});
            
        }

        public IActionResult EditBook(string bookId)
        {
            var book = _book.GetBookAsync(bookId);
            return View(book);
        }

        [HttpPut]
        public IActionResult EditBook(Book book)
        {
            _book.UpdateBookAsync(book);
            return RedirectToAction("Index");
        }

       
    }

    
}