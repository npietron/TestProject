using System.Linq;
using TestProject.DataLayer.Repositories.Abstract;
using TestProject.Model;

namespace TestProject.DataLayer.Repositories.Concrete
{
    public class MessageRepository : IMessageRepository
    {
        private readonly TestProjectDBContext _context;

        public MessageRepository(TestProjectDBContext context)
        {
            _context = context;
        }

        public IQueryable<Message> Messages
        {
            get
            {
                return _context.Message;
            }
        }

        public Message DeleteMessage(int messageId)
        {
            Message dbEntry = _context.Message.Find(messageId);

            if (dbEntry != null)
            {
                _context.Message.Remove(dbEntry);
                _context.SaveChanges();
            }

            return dbEntry;
        }

        public void SaveMessage(Message message)
        {
            if (message.MessageId == 0)
            {
                _context.Message.Add(message);
            }
            else
            {
                Message dbEntry = _context.Message.Find(message.MessageId);
                if (dbEntry != null)
                {
                    dbEntry.Content = message.Content;
                }
            }
            _context.SaveChanges();
        }
    }
}
