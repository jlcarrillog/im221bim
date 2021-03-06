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
    [Authorize]
    public class PacientesController : Controller
    {
        private readonly PacientesDbContext _pacientesDbContext;
        public PacientesController(IConfiguration configuration)
        {
            _pacientesDbContext = new PacientesDbContext(configuration.GetConnectionString("DefaultConnection"));
        }

        public IActionResult Index()
        {
            var data = _pacientesDbContext.List();
            return View(data);
        }

        public IActionResult Details(Guid id)
        {
            var data = _pacientesDbContext.Details(id);
            return View(data);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Paciente data, IFormFile file)
        {
            if (file != null)
            {
                data.Foto = FileConverterService.ConvertToBase64(file.OpenReadStream());
            }
            else
            {
                data.Foto = FileConverterService.PlaceHolder;
            }
            _pacientesDbContext.Create(data);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Guid id)
        {
            var data = _pacientesDbContext.Details(id);
            return View(data);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Paciente data, IFormFile file)
        {
            if (file != null)
            {
                data.Foto = FileConverterService.ConvertToBase64(file.OpenReadStream());
            }
            else if (data.Foto == null)
            {
                data.Foto = FileConverterService.PlaceHolder;
            }
            _pacientesDbContext.Edit(data);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            _pacientesDbContext.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
