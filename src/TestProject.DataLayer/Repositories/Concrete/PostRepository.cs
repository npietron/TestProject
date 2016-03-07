using System.Linq;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Model;

namespace TestProject.DataLayer.Repositories.Concrete
{
    public class PostRepository : IPostRepository
    {
        private readonly TestProjectDBContext _context;

        public PostRepository(TestProjectDBContext context)
        {
            _context = context;
        }

        public IQueryable<Post> Posts
        {
            get
            {
                return _context.Post;
            }
        }

        public Post DeletePost(int postId)
        {
            Post dbEntry = _context.Post.Find(postId);

            if (dbEntry != null)
            {
                _context.Post.Remove(dbEntry);
                _context.SaveChanges();
            }

            return dbEntry;
        }

        public void SavePost(Post post)
        {
            if (post.PostId == 0)
            {
                _context.Post.Add(post);
            }
            else
            {
                Post dbEntry = _context.Post.Find(post.PostId);
                if (dbEntry != null)
                {
                    dbEntry.Content = post.Content;
                }
            }
            _context.SaveChanges();
        }
    }
}
