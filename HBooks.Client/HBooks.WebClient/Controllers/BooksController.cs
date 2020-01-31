using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBooks.Domain.Entities.Book;
using HBooks.Domain.Services;
using HBooks.WebClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace HBooks.WebClient.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _service;

        public BooksController(IBookService Service)
        {
            _service = Service;
        }

        public IActionResult Index()
        {
            var data = _service.GetAll();

            return View(new BookViewModel(data));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Name,ShortDescription,Genre,Qty,QtyRented")] BookObject book)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var rt = _service.InsertBook(book);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            decimal bookId = 0;

            if (!string.IsNullOrEmpty(id))
            {
                bookId = Convert.ToDecimal(id);
                return View(_service.GetById(bookId));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,Name,ShortDescription,Genre,Qty,QtyRented")] BookObject obj)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateBookData(obj);
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(string id)
        {
            decimal bookId = 0;

            if (!string.IsNullOrEmpty(id))
            {
                bookId = Convert.ToDecimal(id);

                var objToDelete = _service.GetById(bookId);

                _service.Delete(objToDelete);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}