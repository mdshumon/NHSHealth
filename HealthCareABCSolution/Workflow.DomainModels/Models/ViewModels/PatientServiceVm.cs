using System;
using System.Collections.Generic;
using System.Text;
using Workflow.DomainModels.Interfaces;

namespace Workflow.DomainModels.Models.ViewModels
{
    public class PatientServiceVm
    {
        List<PatientVm> Patients { get; set; }
        List<ServiceVm> Services { get; set; }
    }
}
