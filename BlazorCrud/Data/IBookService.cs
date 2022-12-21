using BlazorCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCrud.Data
{
    interface IBookService
    {
        Task<IEnumerable<Books>> GetAllBooks();

        Task<Books> GetBooksDetails(int id);

        Task<bool> InsertBook(Books book);

        Task<bool> UpdateBook(Books book);

        Task<bool> DeleteBook(int id);

        Task<bool> SaveBook(Books book);
    }
}
