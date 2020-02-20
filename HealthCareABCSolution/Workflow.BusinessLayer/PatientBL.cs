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
using Workflow.Utility.DTO;
using static Workflow.DomainModels.Enums;

namespace Workflow.BusinessLayer
{

    public class PatientBL : IPatientBL
    {
        private readonly IRepositories iRepository;
        private readonly ILogger<PatientBL> logger;
        IEnumerable<PatientVm> patientList = null;
        public PatientBL(IRepositories iRepositoryP, ILogger<PatientBL> loggerP)
        {
            this.iRepository = iRepositoryP;
            this.logger = loggerP;
        }
        public IEnumerable<PatientVm> GetAllPatient()
        {
            return iRepository.HealthCareDbContext.Patients.Select(x => new PatientVm()
            {
                Address = x.Address,
                DOB = x.DOB,
                FirstName = x.FirstName,
                Gender = x.Gender,
                LastName = x.LastName,
                PatientId = x.PatientId
            });
        }
        public async Task<PatientVm> GetPatientByID(Guid patientID)
        {

            var patient = await iRepository.HealthCareDbContext.Patients.FirstOrDefaultAsync(x => x.PatientId == patientID);

            return new PatientVm()
            {
                PatientId = patient.PatientId,
                Address = patient.Address,
                DOB = patient.DOB,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Gender = patient.Gender
            };
        }

        public void AddPatient(PatientVm patient)
        {
            if (!string.IsNullOrEmpty(patient.FirstName))
            {
                iRepository.HealthCareDbContext.Patients.Add(
                new Patient()
                {
                    Address = patient.Address,
                    DOB = patient.DOB,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Gender = patient.Gender
                });
                iRepository.HealthCareDbContext.SaveChanges();
            }
        }
        public async Task<bool> DeletePatientAsync(Guid patientId)
        {
            var patient = iRepository.HealthCareDbContext.Patients.FirstOrDefault(x => x.PatientId == patientId);
            if (patient != null)
            {
                iRepository.HealthCareDbContext.Patients.Remove(patient);
                await iRepository.HealthCareDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> UpdatePatientAsync(PatientVm patientvm)
        {
            var patient = iRepository.HealthCareDbContext.Patients.FirstOrDefault(x => x.PatientId == patientvm.PatientId);
            if (patient != null)
            {
                patient.FirstName = patientvm.FirstName;
                patient.LastName = patientvm.LastName;
                patient.DOB = patientvm.DOB;
                patient.Gender = patientvm.Gender;
                patient.Address = patientvm.Address;
                await iRepository.HealthCareDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
