using BlazorCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCrud.Data
{
    public class BookService : IBookService
    {
        private readonly BookContext Context;

        public BookService(BookContext context)
        {
            Context = context;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await Context.Books.FindAsync(id);

            Context.Books.Remove(book);

            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Books>> GetAllBooks()
        {
            return await Context.Books.ToListAsync();
        }

        public async Task<Books> GetBooksDetails(int id)
        {
            return await Context.Books.FindAsync(id);
        }

        public async Task<bool> InsertBook(Books book)
        {
            Context.Books.Add(book);

            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveBook(Books book)
        {
            if (book.BookId > 0)
                return await UpdateBook(book);

            return await InsertBook(book);
        }

        public async Task<bool> UpdateBook(Books book)
        {
            Context.Entry(book).State = EntityState.Modified;

            return await Context.SaveChangesAsync() > 0;
        }
    }
}
