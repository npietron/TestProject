using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Services.Abstract;

namespace TestProject.Services.Concrete
{
    public class CustomPostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public CustomPostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
    }
}
