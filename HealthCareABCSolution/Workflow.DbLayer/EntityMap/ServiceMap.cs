using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.DbLayer.EntityMap.Entities;

namespace Workflow.DbLayer.EntityMap
{
  
    public class ServiceMap : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("tblServices", "NHS");
        }
    }
}
