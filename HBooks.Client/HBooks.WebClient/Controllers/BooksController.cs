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

        public IActionResult Edit(decimal id)
        {
            var objToUpdate = _service.GetById(id);

            return View(objToUpdate);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name,Name,ShortDescription,Genre,Qty,QtyRented")] BookObject obj)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateBookData(obj);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            var objToDelete = _service.GetById((decimal)id);

            _service.Delete(objToDelete);

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing) { }

    }
}