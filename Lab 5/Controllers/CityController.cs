using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_5.Models;
using Lab_5.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;

namespace Lab_5.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult List()
        {
            return View(_cityService.GetCities());
        }

        public IActionResult View(int id)
        {
            return View(_cityService.GetCity(id));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(City e)
        {
            _cityService.AddCity(e);
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Cities = _cityService.GetCities().Where(e => e.Id != id).Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });
            return View(_cityService.GetCity(id));
        }

        [HttpPost]
        public IActionResult Edit(City e)
        {
            var city = _cityService.GetCity(e.Id);
            city.Name = e.Name;
            city.population = e.population;
            _cityService.SaveChanges();
            return RedirectToAction(nameof(View), new { id = e.Id });
        }
    }
}

