using System;
using Workflow.DbLayer;

namespace Workflow.Repositories
{
    public interface IRepositories
    {
        HealthCareDbContext HealthCareDbContext { get; }

    }
}
