using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HBooks.Domain.Services.Interfaces.Book;
using HBooks.Domain.Entitites.Objects;

namespace HBooks.UI.V1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/books")]

    public class BooksController : Controller
    {

        private readonly IBookService _bookService;
        public BooksController(IBookService BookService)
        {
            _bookService = BookService;
        }

        [Route("GetAllBoks")]    
        [HttpGet]
        public IEnumerable<BookObject> GetAllBoks()
        {
            try
            {
                return _bookService.GetAll();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        [Route("GetById")]
        [HttpGet]
        public IActionResult GetById(decimal bookId)
        {
            try
            {
                return new ObjectResult(_bookService.GetById(bookId));
            }
            catch (System.Exception ex)
            {
                return NotFound();
            }

        }

        [Route("InserBook")]
        [HttpPost]
        public ResponseObject InserBook([FromBody]BookObject obj)
        {
            try
            {
                return _bookService.InsertBook(obj);
            }
            catch (System.Exception ex)
            {
                return ResponseObject.CreateSpecificError(ex);
            }
        }

        [Route("UpdateBook")]
        [HttpPut]
        public ResponseObject UpdateBook([FromBody]BookObject obj)
        {
            try
            {
                return _bookService.UpdateBookData(obj);
            }
            catch (System.Exception ex)
            {
                return ResponseObject.CreateSpecificError(ex);
            }
        }

        [Route("DeleteBook")]
        [HttpDelete]
        public ResponseObject DeleteBook(decimal idBook)
        {
            try
            {
                return _bookService.Delete(idBook);
            }
            catch (System.Exception ex)
            {
                return ResponseObject.CreateSpecificError(ex);
            }
        }
    }
}