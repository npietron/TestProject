using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Model;

namespace TestProject.Services.REST.Abstract
{
    public interface IMessageService
    {
        IQueryable<Message> Get();
        Message Get(int messageId);
        IQueryable<Message> GetMessagesByUserId(int userId);
        IQueryable<Message> GetMessagesByPostId(int postId);
    }
}
