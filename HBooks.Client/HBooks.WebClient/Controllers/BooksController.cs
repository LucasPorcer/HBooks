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
            try
            {
                var data = _service.GetAll();

                return View(new BookViewModel(data));
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro: {ex.Message}";
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Name,ShortDescription,Genre,Qty,QtyRented")] BookObject book)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    ViewBag.Error = "Por favor verifique os campos";
                    return View();
                }

                if (book.QtyRented > book.Qty)
                {
                    ViewBag.Error = "Quantidade alugada não pode ser maior do que a quantidade disponível em stoque";
                    return View();
                }

                var rt = _service.InsertBook(book);

                if (rt.Code != 0)
                {
                    ViewBag.Error = rt.Message;
                    return View();
                }


                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro: {ex.Message}";
                return View();
            }

        }

        public IActionResult Edit(string id)
        {
            try
            {
                decimal bookId = 0;

                if (!string.IsNullOrEmpty(id))
                {
                    bookId = Convert.ToDecimal(id);
                    return View(_service.GetById(bookId));
                }
                else
                {
                    ViewBag.Error = "Não foi possível localizar este livro";
                    return View();
                }
            }
            catch (Exception ex)
            {

                ViewBag.Error = $"Erro: {ex.Message}";
                return View();
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,Name,ShortDescription,Genre,Qty,QtyRented")] BookObject obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.QtyRented > obj.Qty)
                    {
                        ViewBag.Error = "Quantidade alugada não pode ser maior do que a quantidade disponível em stoque";
                        return View();
                    }

                    var rt = _service.UpdateBookData(obj);

                    if (rt.Code != 0)
                    {
                        ViewBag.Error = rt.Message;
                        return View();
                    }

                }
                else
                {
                    ViewBag.Error = "Ocorreu um erro, favor verifique todos os campos se estão de acordo com o padrão";
                    return View();
                }

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Erro: {ex.Message}";
                return View();
            }

        }


        public IActionResult Delete(string id)
        {
            try
            {
                decimal bookId = 0;

                if (!string.IsNullOrEmpty(id))
                {
                    bookId = Convert.ToDecimal(id);

                    var objToDelete = _service.GetById(bookId);

                    var rt = _service.Delete(objToDelete);

                    if (rt.Code != 0)
                    {
                        ViewBag.Error = rt.Message;
                        return View();
                    }

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Não foi possível localizar este livro";
                    return View();
                }
            }
            catch (Exception ex)
            {

                ViewBag.Error = $"Erro: {ex.Message}";
                return View();
            }

        }

    }
}