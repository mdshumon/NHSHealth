using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Workflow.DomainModels.Models.ViewModels;

namespace Workflow.BusinessLayer
{
    public interface IPatientBL
    {

        IEnumerable<PatientVm> GetAllPatient();
        Task<PatientVm> GetPatientByID(Guid patientID);
        void AddPatient(PatientVm patient);
        Task<bool> DeletePatientAsync(Guid patientId);
        Task<bool> UpdatePatientAsync(PatientVm patient);
    }
}
