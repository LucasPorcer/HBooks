using HBooks.Domain.Entitites.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBooks.Domain.Services.Interfaces.Book
{
    public interface IBookService
    {
        BookObject GetById(decimal bookId);
        IEnumerable<BookObject> GetAll();
        ResponseObject InsertBook(BookObject obj);
        ResponseObject UpdateBookData(BookObject obj);
        ResponseObject Delete(decimal bookId);
        void CreateFakeBooks();
    }
}
