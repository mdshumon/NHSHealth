using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.BusinessLayer
{
    public class BusinessDI
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<IPatientBL, PatientBL>();
            services.AddTransient<IServiceBL, ServiceBL>();
            services.AddTransient<IReportingBL, ReportingBL>();
        }
    }
}
