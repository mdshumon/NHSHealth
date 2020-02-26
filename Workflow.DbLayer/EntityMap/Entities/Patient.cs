using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Workflow.DbLayer.EntityMap.Entities
{
    public partial class Patient
    {
        public Patient()
        {
            this.Services = new HashSet<Service>();
        }
        [Key]
        public System.Guid PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public System.DateTime DOB { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }

}

