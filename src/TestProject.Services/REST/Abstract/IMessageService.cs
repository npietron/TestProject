using System.Linq;
using TestProject.Services.Contracts.Message;

namespace TestProject.Services.REST.Abstract
{
    public interface IMessageService
    {
        IQueryable<MessageDto> Get();
        MessageDto Get(int messageId);
        IQueryable<MessageDto> GetMessagesByUserId(int userId);
        IQueryable<MessageDto> GetMessagesByPostId(int postId);
        void AddMessage(MessageDto message);
    }
}
