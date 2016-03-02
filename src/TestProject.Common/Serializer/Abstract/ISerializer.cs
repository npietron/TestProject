namespace TestProject.Common.Serializer.Abstract
{
    public interface ISerializer<T>
    {
        string Serialize(T model);
        T Deserialize(string description);
    }
}
