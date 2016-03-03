using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Model.Helpers
{
    public static class DbHelper
    {
        public static string GetConnectionString()
        {
            return
                @"metadata=res://*/TestProjectModel.csdl|res://*/TestProjectModel.ssdl|res://*/TestProjectModel.msl;provider=System.Data.SqlClient;provider connection string='data source=(localdb)\MSSQLLocalDB;initial catalog=TestProject;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework'";
        }
    }
}
