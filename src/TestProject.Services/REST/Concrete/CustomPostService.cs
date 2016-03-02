using System.Linq;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Model;
using TestProject.Services.Contracts.Post;
using TestProject.Services.Mapper;
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

        public void AddPost(PostDto post)
        {
            var mappedPost = MappingsConfig.Mapper.Map<Post>(post);

            _postRepository.SavePost(mappedPost);
        }

        public IQueryable<PostDto> Get()
        {
            var result = _postRepository.Posts;
            var posts = MappingsConfig.Mapper.Map<IQueryable<PostDto>>(result);

            return posts;
        }

        public PostDto Get(int postId)
        {
            var result = _postRepository.Posts.FirstOrDefault(x => x.PostId == postId);
            var post = MappingsConfig.Mapper.Map<PostDto>(result);

            return post;
        }

        public IQueryable<PostDto> GetPostsByUserId(int userId)
        {
            var result = _postRepository.Posts.Where(x => x.UserId == userId);
            var posts = MappingsConfig.Mapper.Map<IQueryable<PostDto>>(result);

            return posts;
        }
    }
}
