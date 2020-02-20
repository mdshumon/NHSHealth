using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Repositories
{
    public sealed class RepositoryDI
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<IRepositories, Repositories>();
        }
    }
}
