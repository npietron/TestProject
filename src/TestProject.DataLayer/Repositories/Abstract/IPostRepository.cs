using System.Linq;
using TestProject.Model;

namespace TestProject.DataLayer.Repositories.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }
        Post DeletePost(int postId);
        void SavePost(Post post);
    }
}
