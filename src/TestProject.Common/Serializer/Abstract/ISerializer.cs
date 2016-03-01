using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Common.Serializer.Abstract
{
    public interface ISerializer<T>
    {
        string Serialize(T model);
        T Deserialize(string description);
    }
}
