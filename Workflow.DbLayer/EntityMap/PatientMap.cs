using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.DbLayer.EntityMap.Entities;

namespace Workflow.DbLayer.EntityMap
{

    public class PatientMap : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("tblPatient","NHS");
            builder.HasKey(x=>x.PatientId);
        }
    }
}