using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Services.Abstract;

namespace TestProject.Services.Concrete
{
    public class CustomMesssageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public CustomMesssageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
    }
}
