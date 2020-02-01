using HBooks.Domain.Entitites.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBooks.Domain.Repositories.Book
{
    public interface IBookRepository
    {
        BookObject GetById(decimal bookId);
        IEnumerable<BookObject> GetAll();
        ResponseObject InsertBook(BookObject obj);
        ResponseObject UpdateBookData(BookObject obj);
        ResponseObject Delete(BookObject obj);
    }
}
