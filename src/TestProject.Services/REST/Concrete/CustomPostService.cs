using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Model;
using TestProject.Services.REST.Abstract;

namespace TestProject.Services.REST.Concrete
{
    public class CustomPostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public CustomPostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IQueryable<Post> Get()
        {
            return _postRepository.Posts;
        }

        public Post Get(int postId)
        {
            return _postRepository.Posts.FirstOrDefault(x => x.PostId == postId);
        }

        public IQueryable<Post> GetPostsByUserId(int userId)
        {
            return _postRepository.Posts.Where(x => x.UserId == userId);
        }
    }
}
