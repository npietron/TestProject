using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Model;

namespace TestProject.DataLayer.Repositories.Concrete
{
    public class MessageRepository : IMessageRepository
    {
        private readonly TestProjectContext _context;

        public MessageRepository(TestProjectContext context)
        {
            _context = context;
        }

        public IQueryable<Message> Messages
        {
            get
            {
                return _context.Messages;
            }
        }

        public Message DeleteMessage(int messageId)
        {
            Message dbEntry = _context.Messages.Find(messageId);

            if (dbEntry != null)
            {
                _context.Messages.Remove(dbEntry);
                _context.SaveChanges();
            }

            return dbEntry;
        }

        public void SaveMessage(Message message)
        {
            if (message.MessageId == 0)
            {
                _context.Messages.Add(message);
            }
            else
            {
                Message dbEntry = _context.Messages.Find(message.MessageId);
                if (dbEntry != null)
                {
                    dbEntry.Content = message.Content;
                }
            }
            _context.SaveChanges();
        }
    }
}
