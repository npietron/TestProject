using System.Collections.Generic;
using System.Linq;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Model;
using TestProject.Services.Contracts.Message;
using TestProject.Services.Mapper;
using TestProject.Services.REST.Abstract;

namespace TestProject.Services.REST.Concrete
{
    public class CustomMessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public CustomMessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void AddMessage(MessageDto message)
        {
            var mappedMessage = MappingsConfig.Mapper.Map<Message>(message);

            _messageRepository.SaveMessage(mappedMessage);
        }

        public IQueryable<MessageDto> Get()
        {
            var result = _messageRepository.Messages;
            var messages = MappingsConfig.Mapper.Map<IEnumerable<MessageDto>>(result).AsQueryable();

            return messages;
        }

        public MessageDto Get(int messageId)
        {
            var result = _messageRepository.Messages.FirstOrDefault(x => x.MessageId == messageId);
            var messages = MappingsConfig.Mapper.Map<MessageDto>(result);


            return messages;
        }

        public IQueryable<MessageDto> GetMessagesByPostId(int postId)
        {
            var result = _messageRepository.Messages.Where(x => x.PostId == postId);
            var messages = MappingsConfig.Mapper.Map<IEnumerable<MessageDto>>(result).AsQueryable();

            return messages;
        }

        public IQueryable<MessageDto> GetMessagesByUserId(int userId)
        {
            var result = _messageRepository.Messages.Where(x => x.UserId == userId);
            var messages = MappingsConfig.Mapper.Map<IEnumerable<MessageDto>>(result).AsQueryable();

            return messages;
        }
    }
}
