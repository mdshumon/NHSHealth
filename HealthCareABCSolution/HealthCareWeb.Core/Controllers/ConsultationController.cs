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

namespace HealthCareWeb.Core.Controllers
{
    public class ConsultationController : Controller
    {

        private readonly IRepositories iRepository;
        private readonly ILogger<ConsultationController> logger;
        private readonly IServiceBL iServiceBL = null;
        public ConsultationController(IRepositories iRepositoryP, ILogger<ConsultationController> loggerP, IServiceBL iServiceBLP)
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

        // GET: Consultation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Consultation/Create
        public ActionResult Create()
        {
            var model = new ServiceVm();
            ViewBag.PatientListItemsIds= iServiceBL.GetAllPatientNameId();
            model.PatientListItems = iServiceBL.GetAllPatientNameId();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceVm servicevm)
        {
            if (string.IsNullOrEmpty(servicevm.Advice))
                return View();
            iServiceBL.AddService(servicevm);
            return RedirectToAction(nameof(Index));
        }

        // GET: Consultation/Edit/5
        public ActionResult Edit(Guid serviceId)
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(id)))
                return View();
            await iServiceBL.DeleteServiceAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}