using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Workflow.DomainModels.Models.ViewModels;

namespace Workflow.BusinessLayer
{
    public interface IServiceBL
    {
        IEnumerable<ServiceVm> GetAllServices();        
        Task<ServiceVm> GetServiceByID(Guid serviceID);
        void AddService(ServiceVm servicvm);
        Task<bool> DeleteServiceAsync(Guid serviceId);
        Task<bool> UpdateServiceAsync(ServiceVm servicevm);

        IEnumerable<SelectListItem> GetAllPatientNameId();
    }
}
