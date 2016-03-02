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
    public class CustomMesssageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public CustomMesssageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IQueryable<Message> Get()
        {
            return _messageRepository.Messages;
        }

        public Message Get(int messageId)
        {
            return _messageRepository.Messages.FirstOrDefault(x => x.MessageId == messageId);
        }

        public IQueryable<Message> GetMessagesByPostId(int postId)
        {
            return _messageRepository.Messages.Where(x => x.PostId == postId);
        }

        public IQueryable<Message> GetMessagesByUserId(int userId)
        {
            return _messageRepository.Messages.Where(x => x.UserId == userId);
        }
    }
}
