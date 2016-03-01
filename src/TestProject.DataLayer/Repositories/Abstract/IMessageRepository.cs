using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
