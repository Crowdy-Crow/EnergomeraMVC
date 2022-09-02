using EnergomeraMVC.Models;
using EnergomeraMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EnergomeraMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryService _countryService;
        public HomeController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var viewModel = await _countryService.GetAllAsync();
        //    return View(viewModel);
        //}
        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            IEnumerable<CountryViewModel> viewModel;
            if (String.IsNullOrEmpty(name)) viewModel = await _countryService.GetAllAsync();
            else viewModel = await _countryService.GetByNameAsync(name);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string name)
        {
            var viewModel = (await _countryService.GetByNameAsync(name)).FirstOrDefault();
            return View(viewModel);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
