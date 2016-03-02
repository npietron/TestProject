using System.Linq;
using TestProject.Services.Contracts.Post;

namespace TestProject.Services.REST.Abstract
{
    public interface IPostService
    {
        IQueryable<PostDto> Get();
        PostDto Get(int postId);
        IQueryable<PostDto> GetPostsByUserId(int userId);
        void AddPost(PostDto post);
    }
}
