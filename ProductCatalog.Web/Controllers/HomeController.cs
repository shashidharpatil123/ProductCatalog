using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductCatalog.Web.Models;
using ProductCatalog.Web.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICatalogService _catalogService;
        public HomeController(ILogger<HomeController> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task< IActionResult> Catalog()
        {
            IEnumerable<CatalogItem> items = await _catalogService.GetCatalogItems();
            return View(items);
        }

        public async Task<IActionResult> Details(int id)
        {
            CatalogItem item = await _catalogService.GetById(id);
            return View(item);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _catalogService.GetById(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CatalogItem item)
        {
            await _catalogService.Update(item);
            var items = await _catalogService.GetCatalogItems();
            return View("Index", items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
