using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;

namespace TestProject.Services.REST.Abstract
{
    public interface IPostService
    {
        IQueryable<Post> Get();
        Post Get(int postId);
        IQueryable<Post> GetPostsByUserId(int userId);
    }
}
