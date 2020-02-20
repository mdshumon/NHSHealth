using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Workflow.DbLayer.EntityMap.Entities
{
    public partial class Service
    {
        [Key]
        public System.Guid ServiceId { get; set; }
        public System.Guid PatientId { get; set; }
        public System.DateTime ServiceTime { get; set; }
        public string Symtoms { get; set; }
        public string Advice { get; set; }
        public string Medication { get; set; }
        public string Comments { get; set; }
        public decimal ServiceCharge { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
