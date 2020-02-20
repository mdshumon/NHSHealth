using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Workflow.DbLayer.EntityMap;
using Workflow.DbLayer.EntityMap.Entities;

namespace Workflow.DbLayer
{

    public class HealthCareDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        #region RawSQL
        protected DbCommand GetCommand(DbConnection connection, string commandText, CommandType commandType)
        {
            SqlCommand command = new SqlCommand(commandText, connection as SqlConnection);
            command.CommandType = commandType;
            return command;
        }
        public DbDataReader GetDataReader(string procedureName, List<SqlParameter> parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            DbDataReader ds = null;

            using (SqlConnection con = new SqlConnection(this.Database.GetDbConnection().ConnectionString))
            {
                con.Open();
                DbCommand cmd = this.GetCommand(con, procedureName, commandType);
                if (parameters != null && parameters.Count > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                ds = cmd.ExecuteReader();
            }
            return ds;
        }

        public DataTable GetDataTable(string procedureName, List<SqlParameter> parameters = null, CommandType commandType = CommandType.StoredProcedure)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(this.Database.GetDbConnection().ConnectionString))
            {
                con.Open();
                DbCommand cmd = this.GetCommand(con, procedureName, commandType);
                if (parameters != null && parameters.Count > 0)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }

                dt.Load(cmd.ExecuteReader());
            }
            return dt;
        }


        #endregion
        public HealthCareDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientMap());
            modelBuilder.ApplyConfiguration(new ServiceMap());
        }
    }
}
