using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books.OrderByDescending(b=>b.DateCreated).Take(1000);
        }

        public async Task<Book> GetBookAsync(string bookId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
            return book;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
            
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var bookInDb = await _context.Books.FindAsync(book.BookId);

            bookInDb.Title = book.Title;
            bookInDb.Price = book.Price;
            bookInDb.Synopsis = book.Synopsis;
            bookInDb.AuthorName = book.AuthorName;
            bookInDb.AuthorBio = book.AuthorBio;
            bookInDb.DateModified = DateTime.Now;

            await _context.SaveChangesAsync();
            return book;

        }

        public async Task<Book> DeleteBook(Book book)
        {
            var bookInDb = await _context.Books.FirstOrDefaultAsync(b => b.BookId == book.BookId);
            bookInDb.IsDeleted = true;
            await _context.SaveChangesAsync();
            return book;
        }
       
    }
}
