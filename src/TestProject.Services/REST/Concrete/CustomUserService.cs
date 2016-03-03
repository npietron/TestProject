using System.Collections.Generic;
using System.Linq;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Model;
using TestProject.Services.Contracts.User;
using TestProject.Services.Mapper;
using TestProject.Services.REST.Abstract;

namespace TestProject.Services.REST.Concrete
{
    public class CustomUserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public CustomUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(UserDto user)
        {
            var mappedUser = MappingsConfig.Mapper.Map<User>(user);

            _userRepository.SaveUser(mappedUser);
        }

        public IQueryable<UserDto> Get()
        {
            var result = _userRepository.Users;
            var users = MappingsConfig.Mapper.Map<IEnumerable<UserDto>>(result).AsQueryable();

            return users;
        }

        public UserDto Get(int userId)
        {
            var result = _userRepository.Users.FirstOrDefault(x => x.UserId == userId);
            var user = MappingsConfig.Mapper.Map<UserDto>(result);

            return user;
        }
    }
}
