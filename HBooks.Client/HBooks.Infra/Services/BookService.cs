using AutoMapper;
using HBooks.Domain.Entities.Book;
using HBooks.Domain.Entities.Response;
using HBooks.Domain.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HBooks.Infra.Services
{
    public class BookService : IBookService
    {
        private readonly HBooksAPI.Client _api;
        private readonly IMapper _mapper;

        public BookService(IMapper mapper)
        {
            var httpClient = new HttpClient();

            _api = new HBooksAPI.Client("https://hbooksui20200131014501.azurewebsites.net/", httpClient);
            _api.BaseUrl = "https://hbooksui20200131014501.azurewebsites.net/";
            _mapper = mapper;
        }


        public ResponseObject Delete(BookObject obj)
        {
            var call = _api.ApiV1BooksDeletebookAsync(Convert.ToDouble(obj.Id));
            call.Wait();

            ResponseObject resultObj = _mapper.Map<ResponseObject>(call.Result);

            return resultObj;
        }

        public List<BookObject> GetAll()
        {
            var call = _api.ApiV1BooksGetallboksAsync();
            call.Wait();

            List<BookObject> resultObj = _mapper.Map<List<BookObject>>(call.Result);

            return resultObj;
        }

        public BookObject GetById(decimal bookId)
        {
            var call = _api.ApiV1BooksGetbyidAsync(Convert.ToDouble(bookId));
            call.Wait();

            BookObject resultObj = _mapper.Map<BookObject>(call.Result);

            return resultObj;
        }

        public ResponseObject InsertBook(BookObject obj)
        {
            var id = Convert.ToDecimal(DateTime.Now.ToString("yyyyMMddHHmmss"));

            var call = _api.ApiV1BooksInserbookAsync(new HBooksAPI.BookObject() { Genre = obj.Genre, Id = (double)id, Name = obj.Name, Qty = obj.Qty, QtyRented = obj.QtyRented, RentalPrice = obj.QtyRented, ShortDescription = obj.ShortDescription });
            call.Wait();

            ResponseObject resultObj = _mapper.Map<ResponseObject>(call.Result);

            return resultObj;
        }

        public ResponseObject UpdateBookData(BookObject obj)
        {
            var call = _api.ApiV1BooksUpdatebookAsync(new HBooksAPI.BookObject() { Genre = obj.Genre, Id = (double)obj.Id, Name = obj.Name, Qty = obj.Qty, QtyRented = obj.QtyRented, RentalPrice = obj.QtyRented, ShortDescription = obj.ShortDescription });
            call.Wait();

            ResponseObject resultObj = _mapper.Map<ResponseObject>(call.Result);

            return resultObj;
        }
    }
}
