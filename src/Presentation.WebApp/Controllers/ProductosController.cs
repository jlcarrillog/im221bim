using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

using Domain;
using Infrastructure;
using Application;

namespace Presentation.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductosController : Controller
    {
        private readonly ProductosDbContext _productosDbContext;
        public ProductosController(IConfiguration configuration)
        {
            _productosDbContext = new ProductosDbContext(configuration.GetConnectionString("DefaultConnection"));
        }

        public IActionResult Index()
        {
            var data = _productosDbContext.List();
            return View(data);
        }

        public IActionResult Details(Guid id)
        {
            var data = _productosDbContext.Details(id);
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Producto data, IFormFile file)
        {
            if (file != null)
            {
                data.Foto = FileConverterService.ConvertToBase64(file.OpenReadStream());
            }
            else
            {
                data.Foto = FileConverterService.PlaceHolder;
            }
            _productosDbContext.Create(data);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            var data = _productosDbContext.Details(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Producto data, IFormFile file)
        {
            if (file != null)
            {
                data.Foto = FileConverterService.ConvertToBase64(file.OpenReadStream());
            }
            else if (data.Foto == null)
            {
                data.Foto = FileConverterService.PlaceHolder;
            }
            _productosDbContext.Edit(data);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            _productosDbContext.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
