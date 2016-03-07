using System.Linq;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Model;

namespace TestProject.DataLayer.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly TestProjectDBContext _context;

        public UserRepository(TestProjectDBContext context)
        {
            _context = context;
        }

        public IQueryable<User> Users
        {
            get
            {
                return _context.User;
            }
        }

        public User DeleteUser(int userId)
        {
            User dbEntry = _context.User.Find(userId);

            if (dbEntry != null)
            {
                _context.User.Remove(dbEntry);
                _context.SaveChanges();
            }

            return dbEntry;
        }

        public void SaveUser(User user)
        {
            if (user.UserId == 0)
            {
                _context.User.Add(user);
            }
            else
            {
                User dbEntry = _context.User.Find(user.UserId);
                if (dbEntry != null)
                {
                    dbEntry.UserName = user.UserName;
                }
            }
            _context.SaveChanges();
        }
    }
}
