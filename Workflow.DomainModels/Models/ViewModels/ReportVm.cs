using System;
using System.Collections.Generic;
using System.Text;
using static Workflow.DomainModels.Enums;

namespace Workflow.DomainModels.Models.ViewModels
{
    public class ReportVm
    {
        public ReportTypes ReporType { get; set; }

        public DateTime ServiceDate { get; set; }
        public int TotalConsultations { get; set; }
        public int TotalAgeGroup { get; set; }
        public decimal TotalFee { get; set; }
    }
}
