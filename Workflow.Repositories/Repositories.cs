using System;
using System.Collections.Generic;
using System.Text;
using Workflow.DbLayer;

namespace Workflow.Repositories
{
    public class Repositories : IRepositories
    {
        readonly HealthCareDbContext healthCareDbContext;
        public Repositories(HealthCareDbContext healthCareDbContextP)
        {
            this.healthCareDbContext = healthCareDbContextP;
        }
        public HealthCareDbContext HealthCareDbContext
        {
            get {
                return healthCareDbContext;
            }
        }
    }
}
