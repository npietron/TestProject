using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Services.Abstract;

namespace TestProject.Services.Concrete
{
    public class CustomUserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public CustomUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
