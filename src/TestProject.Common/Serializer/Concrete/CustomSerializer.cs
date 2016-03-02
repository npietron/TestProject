using Jil;
using TestProject.Common.Serializer.Abstract;

namespace TestProject.Common.Serializer.Concrete
{
    public class CustomSerializer<T> : ISerializer<T>
    {
        public T Deserialize(string description)
        {
            return JSON.Deserialize<T>(description);
        }

        public string Serialize(T model)
        {
            return JSON.Serialize(model);
        }
    }
}
