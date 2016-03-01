using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
