using HBooks.Domain.Entitites.Objects;
using HBooks.Domain.Repositories.Book;
using HBooks.Domain.Services.Interfaces.Book;
using HBooks.Domain.Services.Interfaces.Validation;
using HBooks.Infra.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBooks.Infra.Services
{
    public class BookService : IBookService
    {
        private ApplicationDbContext _context;
        private readonly IValidationService _validationService;
        private readonly IBookRepository _bookRepo;

        public BookService(ApplicationDbContext context, IValidationService ValidationService, IBookRepository BookRepository)
        {
            _context = context;
            _validationService = ValidationService;
            _bookRepo = BookRepository;
        }

        public BookObject GetById(decimal bookId)
        {
            try
            {
                var rt = _bookRepo.GetById(bookId);
                return rt;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public IEnumerable<BookObject> GetAll()
        {
            try
            {
                var rt = _bookRepo.GetAll();
                return rt;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public ResponseObject InsertBook(BookObject obj)
        {
            try
            {
                if (_validationService.Validate(obj, out var errorResult))
                    return errorResult;

                var rt = _bookRepo.InsertBook(obj);

                return rt;
            }
            catch (Exception ex)
            {
                return ResponseObject.CreateSpecificError(ex);
            }

        }


        public ResponseObject UpdateBookData(BookObject obj)
        {
            try
            {
                if (_validationService.Validate(obj, out var errorResult))
                    return errorResult;

                var rt = _bookRepo.UpdateBookData(obj);

                return rt;
            }
            catch (Exception ex)
            {
                return ResponseObject.CreateSpecificError(ex);
            }

        }

        public ResponseObject Delete(decimal bookId)
        {
            try
            {
                BookObject obj = GetById(bookId);
                var rt = new ResponseObject();

                if (obj == null)
                {
                    return new ResponseObject() { Code = 404, Message = "Livro não encontrado para deletar" };
                }
                else
                {
                    rt = _bookRepo.Delete(obj);
                }

                return rt;
            }
            catch (Exception ex)
            {

                return ResponseObject.CreateSpecificError(ex);
            }

        }

        public void CreateFakeBooks()
        {
            InsertBook(new BookObject() { Genre = "Infantil", Id = 1, Name = "Frozen", Qty = 10, QtyRented = 0, RentalPrice = 10, ShortDescription = "Filme para criaça" });
            InsertBook(new BookObject() { Genre = "Ação", Id = 2, Name = "Jumani", Qty = 10, QtyRented = 0, RentalPrice = 10, ShortDescription = "Filme de ação" });
            InsertBook(new BookObject() { Genre = "Gospel", Id = 3, Name = "O impossível", Qty = 10, QtyRented = 0, RentalPrice = 10, ShortDescription = "Filme gospel" });
        }

    }
}
