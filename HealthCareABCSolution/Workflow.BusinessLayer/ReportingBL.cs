using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.DomainModels.Models.ViewModels;
using Workflow.Repositories;
using static Workflow.DomainModels.Enums;
using Workflow.Utility.DTO;
using System.Data;

namespace Workflow.BusinessLayer
{
    public class ReportingBL : IReportingBL
    {
        private readonly IRepositories iRepository;
        private readonly ILogger<ReportingBL> logger;

        public ReportingBL(IRepositories iRepositoryP, ILogger<ReportingBL> loggerP)
        {
            this.iRepository = iRepositoryP;
            this.logger = loggerP;
        }

        public IList<ReportVm> GetSummaryReport(DateTime date, ReportTypes reporttype)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter rTypeParam = new SqlParameter("@reportType", (int)reporttype);
            SqlParameter dateTypeParam = new SqlParameter("@reportDate", date);

            parameters.Add(rTypeParam);
            parameters.Add(dateTypeParam);

            try
            {
                return iRepository.HealthCareDbContext.GetDataTable("NHS.sp_Summary_Report", parameters).AsEnumerable().Select(x => new ReportVm()
                {
                    TotalAgeGroup = x.Field<int>("AgeGroup"),
                    TotalConsultations = x.Field<int>("TotalConsultation"),
                    TotalFee = x.Field<decimal>("TotalFees")
                }).ToList<ReportVm>();

            }
            catch (Exception e) { return new List<ReportVm>(); }


        }
    }
}
