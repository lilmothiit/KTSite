using KTSite.Models;
using KTSite.Models.Interfaces;
using KTSite.Models.Handlers;
using KTSite.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KTSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITabHandler _tabHandler;


        public HomeController(ILogger<HomeController> logger, ITabHandler tabHandler)
        {
            _logger = logger;
            _tabHandler = tabHandler;
        }

        public IActionResult Index()
        {
            var tabView = new TabViewModel
            {
                Tabs = _tabHandler.Tabs
            };

            return View(tabView);
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
