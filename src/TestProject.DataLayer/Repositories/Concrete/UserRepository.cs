using System.Linq;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Model;

namespace TestProject.DataLayer.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly TestProjectContext _context;

        public UserRepository(TestProjectContext context)
        {
            _context = context;
        }

        public IQueryable<User> Users
        {
            get
            {
                return _context.Users;
            }
        }

        public User DeleteUser(int userId)
        {
            User dbEntry = _context.Users.Find(userId);

            if (dbEntry != null)
            {
                _context.Users.Remove(dbEntry);
                _context.SaveChanges();
            }

            return dbEntry;
        }

        public void SaveUser(User user)
        {
            if (user.UserId == 0)
            {
                _context.Users.Add(user);
            }
            else
            {
                User dbEntry = _context.Users.Find(user.UserId);
                if (dbEntry != null)
                {
                    dbEntry.UserName = user.UserName;
                }
            }
            _context.SaveChanges();
        }
    }
}
