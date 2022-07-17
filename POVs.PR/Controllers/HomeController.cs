using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using POVs.PR.Language;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace POVs.PR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<ProjectResources> resource;

        public HomeController(ILogger<HomeController> logger,IStringLocalizer<ProjectResources> Resource)
        {
            _logger = logger;
            resource = Resource;
        }

        public IActionResult Index()
        {
            ViewBag.Data = resource["DASHBOARD"];
            return View();
        }
    }
}
