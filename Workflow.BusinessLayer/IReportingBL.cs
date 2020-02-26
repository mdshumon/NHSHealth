using System;
using System.Collections.Generic;
using System.Text;
using Workflow.DomainModels.Models.ViewModels;
using static Workflow.DomainModels.Enums;

namespace Workflow.BusinessLayer
{
    public interface IReportingBL
    {
        IList<ReportVm> GetSummaryReport(DateTime date, ReportTypes reporttype);

    }
}
