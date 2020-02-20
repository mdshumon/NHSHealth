using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Workflow.DomainModels.Interfaces;

namespace Workflow.DomainModels.Models.ViewModels
{
    public class ServiceVm : IPatient
    {
        [Required]
        public Guid PatientId { get; set; }

        public string FullName { get; set; }
        [Required]
        public System.Guid ServiceId { get; set; }
        [Required]
        public System.DateTime ServiceTime { get; set; }

        public string Symtoms { get; set; }
        public string Advice { get; set; }
        public string Medication { get; set; }
        public string Comments { get; set; }
        public decimal ServiceCharge { get; set; }

        public List<SelectListItem> ServiceChargeList { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "10.00", Text = "10.00" },
            new SelectListItem { Value = "0.00", Text = "0.00" }
        };
        public SelectListItem PatientListItem { get; set; }
        public IEnumerable<SelectListItem> PatientListItems { get; set; }
    }
}
