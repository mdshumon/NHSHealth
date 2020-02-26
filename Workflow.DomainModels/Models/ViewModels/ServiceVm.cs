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
        [Required]
        public string Symtoms { get; set; }
        [Required]
        public string Advice { get; set; }
        [Required]
        public string Medication { get; set; }
        public string Comments { get; set; }
        [Required]
        public decimal ServiceCharge { get; set; }

        //public override string ToString()
        //{
        //    return $"{this.} {}";
        //}
        public List<SelectListItem> ServiceChargeList { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "0.000", Text = "0.000", Selected=true },
            new SelectListItem {  Value = "10.000", Text = "10.000"  }
        };
        public SelectListItem PatientListItem { get; set; }
        public IEnumerable<SelectListItem> PatientListItems { get; set; }

    }
}
