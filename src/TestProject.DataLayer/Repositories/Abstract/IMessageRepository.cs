using System.Linq;
using TestProject.Model;

namespace TestProject.DataLayer.Repositories.Abstract
{
    public interface IMessageRepository
    {
        IQueryable<Message> Messages { get; }
        Message DeleteMessage(int messageId);
        void SaveMessage(Message message);
    }
}
