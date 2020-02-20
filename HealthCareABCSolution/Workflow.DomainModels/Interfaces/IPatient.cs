using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.DomainModels.Interfaces
{
    public interface IPatient
    {
        public Guid PatientId { get; set; }
    }
}
