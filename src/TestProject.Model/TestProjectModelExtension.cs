using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Model
{
    public partial class TestProjectContext
    {
        public TestProjectContext(string connectionString):
            base(connectionString)
        {

        }
    }
}
