using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Workflow.DomainModels.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Workflow.DomainModels.Models.ViewModels
{
    public class PatientVm : IPatient
    {
        [Required]
        public Guid PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime DOB { get; set; }
        [Required]
        public string Address { get; set; }

        public List<SelectListItem> Genders { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Male" },
            new SelectListItem { Value = "2", Text = "Female" },
            new SelectListItem { Value = "3", Text = "DontDisclose", Selected=true }
        };
    }
}
