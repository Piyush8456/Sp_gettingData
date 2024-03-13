using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using gettingData.Models;

namespace gettingData.Services
{
    public class _empServices : DbContext
    {

        public _empServices() : base("EmployeeDbConnection")
        {

        }
        public DbSet<employeeEntity> Employees { get; set; }


    }
}