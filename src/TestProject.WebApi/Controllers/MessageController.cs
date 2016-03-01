using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;
using TestProject.Services.Abstract;

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