using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
