using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Workflow.BusinessLayer;
using Workflow.DomainModels.Models.ViewModels;
using Workflow.Repositories;
using static Workflow.DomainModels.Enums;

namespace HealthCareWeb.Core.Controllers
{
    public class ReportController : Controller
    {
        private readonly IRepositories iRepository;
        private readonly ILogger<ReportController> logger;
        private readonly IReportingBL iReporting;
        public ReportController(IRepositories iRepositoryP, ILogger<ReportController> loggerP, IReportingBL iReportingP)
        {
            this.iRepository = iRepositoryP;
            this.logger = loggerP;
            this.iReporting = iReportingP;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Details( DateTime reportDate, ReportTypes reporttype)
        {
            var model= iReporting.GetSummaryReport(reportDate,reporttype);
            return Json(model);
        }
    }
} 