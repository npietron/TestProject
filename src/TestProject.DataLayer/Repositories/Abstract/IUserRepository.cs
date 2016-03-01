using System.Linq;
using TestProject.Model;

namespace TestProject.DataLayer.Repositories.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        User DeleteUser(int userId);
        void SaveUser(User user);
    }
}
