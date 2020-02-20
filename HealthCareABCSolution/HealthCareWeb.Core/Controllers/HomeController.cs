using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HealthCareWeb.Core.Models;

namespace HealthCareWeb.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> loggerP)
        {
            this.logger = loggerP;        }

        public IActionResult Index()
        {
            return View();
        }
      
    }
}
