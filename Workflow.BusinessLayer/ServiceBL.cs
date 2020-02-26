using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workflow.DbLayer.EntityMap.Entities;
using Workflow.DomainModels.Models.ViewModels;
using Workflow.Repositories;

namespace Workflow.BusinessLayer
{
    public class ServiceBL : IServiceBL
    {
        private readonly IRepositories iRepository;
        private readonly ILogger<ServiceBL> logger;

        public ServiceBL(IRepositories iRepositoryP, ILogger<ServiceBL> loggerP)
        {
            this.iRepository = iRepositoryP;
            this.logger = loggerP;
        }
        public IEnumerable<ServiceVm> GetAllServices()
        {
            

           var  model= iRepository.HealthCareDbContext.Services.Select(x => new ServiceVm()
            {
                ServiceId = x.ServiceId,
                Advice = x.Advice,
                Comments = x.Comments,
                FullName = x.Patient.FirstName + x.Patient.LastName,
                Medication = x.Medication,
                PatientId = x.PatientId,
                ServiceTime = x.ServiceTime,
                Symtoms = x.Symtoms,
                ServiceCharge = x.ServiceCharge,
                PatientListItem = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.Patient.FirstName + " " + x.Patient.LastName + "(" + x.PatientId + ")", Value = x.PatientId.ToString() }
            });
            return model;
        }

        public async Task<ServiceVm> GetServiceByID(Guid serviceID)
        {
            var services = await iRepository.HealthCareDbContext.Services.FirstOrDefaultAsync(x => x.ServiceId == serviceID);
            var model= new ServiceVm()
            {
                ServiceId = services.ServiceId,
                Advice = services.Advice,
                Comments = services.Comments,
                FullName = services.Patient.FirstName + " " + services.Patient.LastName,
                Medication = services.Medication,
                PatientId = services.PatientId,
                ServiceTime = services.ServiceTime,
                Symtoms = services.Symtoms,
                ServiceCharge = services.ServiceCharge,                 
                PatientListItem = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = services.Patient.FirstName + " " + services.Patient.LastName + "(" + services.PatientId + ")", Value = services.PatientId.ToString() }
            };

            return model;
        }

        public void AddService(ServiceVm servicevm)
        {
            if (!string.IsNullOrEmpty(servicevm.Advice))
            {
                iRepository.HealthCareDbContext.Services.Add(
                new Service()
                {
                    Comments = servicevm.Comments,
                    Advice = servicevm.Advice,
                    Medication = servicevm.Medication,
                    PatientId = servicevm.PatientId,
                    ServiceCharge = servicevm.ServiceCharge,
                    ServiceTime = DateTime.Now,
                    Symtoms = servicevm.Symtoms
                });
                iRepository.HealthCareDbContext.SaveChanges();
            }
        }
        public async Task<bool> DeleteServiceAsync(Guid serviceId)
        {
            var service = iRepository.HealthCareDbContext.Services.FirstOrDefault(x => x.ServiceId == serviceId);
            if (service != null)
            {
                iRepository.HealthCareDbContext.Services.Remove(service);
                await iRepository.HealthCareDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdateServiceAsync(ServiceVm servicevm)
        {
            var service = iRepository.HealthCareDbContext.Services.FirstOrDefault(x => x.ServiceId == servicevm.ServiceId);
            if (service != null)
            {
                service.Comments = servicevm.Comments;
                service.Advice = servicevm.Advice;
                service.Medication = servicevm.Medication;
                service.PatientId = servicevm.PatientId;
                service.ServiceCharge = servicevm.ServiceCharge;
                service.ServiceTime = DateTime.Now;
                service.Symtoms = servicevm.Symtoms;                
                await iRepository.HealthCareDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public IEnumerable<SelectListItem> GetAllPatientNameId()
        {
            return iRepository.HealthCareDbContext.Patients.Select(x => new SelectListItem() { Text = x.FirstName + " " + x.LastName + "(" + x.PatientId + ")", Value = x.PatientId.ToString() });
        }

    }
}
