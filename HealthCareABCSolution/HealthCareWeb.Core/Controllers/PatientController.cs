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
    public class PatientController : Controller
    {

        private readonly IRepositories iRepository = null;
        private readonly IPatientBL iPatientBL = null;
        private readonly ILogger<PatientController> logger;
        public PatientController(IRepositories iRepositoryP, ILogger<PatientController> loggerP, IPatientBL iPatientBLP)
        {
            this.iRepository = iRepositoryP;
            this.logger = loggerP;
            this.iPatientBL = iPatientBLP;
        }
        public ActionResult Index()
        {
            var model = iPatientBL.GetAllPatient();
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PatientVm());
        }

        [HttpPost]
        public ActionResult Create(PatientVm patient)
        {
            if (ModelState.IsValid)
            {
                iPatientBL.AddPatient(patient);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(id)))
                return View();
            var model = await iPatientBL.GetPatientByID(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientVm patient)
        {
            if (string.IsNullOrEmpty(Convert.ToString(patient.PatientId)))
                return View();
            var model = await iPatientBL.UpdatePatientAsync(patient);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(id)))
                return View();
            await iPatientBL.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}