using System.Web.OData;
using TestProject.Services.REST.Abstract;

namespace TestProject.WebApi.Controllers
{
    public class MessageController : ODataController
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
    }
}