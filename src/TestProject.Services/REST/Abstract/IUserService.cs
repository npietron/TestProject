using System.Linq;
using TestProject.Services.Contracts.User;

namespace TestProject.Services.REST.Abstract
{
    public interface IUserService
    {
        IQueryable<UserDto> Get();
        UserDto Get(int userId);
        bool DoesUserExists(string nick);
        void AddUser(UserDto user);
    }
}
