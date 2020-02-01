using HBooks.Domain.Entitites.Objects;
using HBooks.Domain.Repositories.Book;
using HBooks.Infra.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hbooks.InfraData.Repository.Book
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext _context;


        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public ResponseObject Delete(BookObject obj)
        {
            try
            {
                _context.Book.Remove(obj);
                _context.SaveChanges();

                return new ResponseObject() { Code = 0, Message = "OK" };
            }
            catch (Exception ex)
            {
                return ResponseObject.CreateSpecificError(ex);
            }
        }

        public IEnumerable<BookObject> GetAll()
        {
            return _context.Book.OrderBy(p => p.Name).ToList();
        }

        public BookObject GetById(decimal bookId)
        {
            try
            {
                return _context.Book.Where(p => p.Id == bookId).FirstOrDefault();
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
                var alreadExists = _context.Book.Where(p => p.Name == obj.Name).Count() > 0;

                if (alreadExists)
                {
                    return new ResponseObject() { Code = 500, Message = "Este Livro já existe" };
                }

                _context.Book.Add(obj);
                _context.SaveChanges();

                return new ResponseObject() { Code = 0, Message = "OK" };

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
                BookObject bookToUpdate = _context.Book.Where(
                   p => p.Id == obj.Id).FirstOrDefault();

                if (bookToUpdate == null)
                {
                    return new ResponseObject() { Code = 404, Message = "Livro não encontrado" };
                }

                bookToUpdate.Name = obj.Name;
                bookToUpdate.Qty = obj.Qty;
                bookToUpdate.QtyRented = obj.QtyRented;
                bookToUpdate.RentalPrice = obj.RentalPrice;
                bookToUpdate.ShortDescription = obj.ShortDescription;
                bookToUpdate.Genre = obj.Genre;

                _context.SaveChanges();

                return new ResponseObject() { Code = 0, Message = "OK" };
            }
            catch (Exception ex)
            {
                return ResponseObject.CreateSpecificError(ex);
            }



        }
    }
}
