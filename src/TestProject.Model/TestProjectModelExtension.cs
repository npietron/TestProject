using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Model
{
    public partial class TestProjectDBContext
    {
        public TestProjectDBContext(string connectionString):
            base(connectionString)
        {

        }
    }
}
