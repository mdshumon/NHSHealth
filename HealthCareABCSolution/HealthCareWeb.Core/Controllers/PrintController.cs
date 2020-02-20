using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Workflow.BusinessLayer;
using Workflow.Repositories;

namespace HealthCareWeb.Core.Controllers
{
    public class PrintController : Controller
    {

        private readonly IServiceBL iServiceBL = null;
        private readonly IRepositories iRepository;
        private readonly ILogger<PrintController> logger;
        public PrintController(IRepositories iRepositoryP, ILogger<PrintController> loggerP, IServiceBL iServiceBLP)
        {
            this.iRepository = iRepositoryP;
            this.logger = loggerP;
            this.iServiceBL = iServiceBLP;
        }

        public ActionResult Index()
        {
            var model = iServiceBL.GetAllServices();
            if (model == null)
                return NotFound();
            return View(model);

        }
    }
}