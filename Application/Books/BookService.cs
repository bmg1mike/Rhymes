using Application.Interfaces;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _book;

        public BookService(IBookRepository book)
        {
            _book = book;
        }
        public Task<Book> AddBookAsync(Book book)
        {
            var response = _book.AddBookAsync(book);
            return response;
        }

        public async Task<Book> DeleteBook(Book book)
        {
            var response = await _book.DeleteBook(book);
            return response;
        }

        public Task<Book> GetBookAsync(string bookId)
        {
            var response = _book.GetBookAsync(bookId);
            return response;
        }

        public Task<IEnumerable<Book>> GetBooksAsync()
        {
            var response = _book.GetBooksAsync();
            return response;
        }

        public Task<Book> UpdateBookAsync(Book book)
        {
            var response = _book.UpdateBookAsync(book);
            return response;
        }
    }
}
