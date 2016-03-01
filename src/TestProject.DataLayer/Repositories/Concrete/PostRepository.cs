using System.Linq;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Model;

namespace TestProject.DataLayer.Repositories.Concrete
{
    public class PostRepository : IPostRepository
    {
        private readonly TestProjectContext _context;

        public PostRepository(TestProjectContext context)
        {
            _context = context;
        }

        public IQueryable<Post> Posts
        {
            get
            {
                return _context.Posts;
            }
        }

        public Post DeletePost(int postId)
        {
            Post dbEntry = _context.Posts.Find(postId);

            if (dbEntry != null)
            {
                _context.Posts.Remove(dbEntry);
                _context.SaveChanges();
            }

            return dbEntry;
        }

        public void SavePost(Post post)
        {
            if (post.PostId == 0)
            {
                _context.Posts.Add(post);
            }
            else
            {
                Post dbEntry = _context.Posts.Find(post.PostId);
                if (dbEntry != null)
                {
                    dbEntry.Content = post.Content;
                }
            }
            _context.SaveChanges();
        }
    }
}
