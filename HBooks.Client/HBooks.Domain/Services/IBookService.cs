using HBooks.Domain.Entities.Book;
using HBooks.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace HBooks.Domain.Services
{
    public interface IBookService
    {
        BookObject GetById(decimal bookId);
        List<BookObject> GetAll();
        ResponseObject InsertBook(BookObject obj);
        ResponseObject UpdateBookData(BookObject obj);
        ResponseObject Delete(BookObject obj);
    }
}
