using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using TestProject.Services.Contracts.Message;
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

        [HttpGet]
        public IQueryable<MessageDto> Get(ODataQueryOptions options)
        {
            var result = _messageService.Get();

            if (options.Filter != null)
            {
                var settings = new ODataQuerySettings();
                result = options.Filter.ApplyTo(result, settings) as IQueryable<MessageDto>;
            }

            return options.ApplyTo(result) as IQueryable<MessageDto>;
        }

        [HttpGet]
        [ODataRoute("GetMessagesByUserId(UserId={userId})")]
        public IHttpActionResult GetMessagesByUserId([FromODataUri]int userId)
        {
            IHttpActionResult actionResult = StatusCode(HttpStatusCode.NotFound);

            var result = _messageService.GetMessagesByUserId(userId);

            if (result != null)
                actionResult = Ok(result);

            return actionResult;
        }

        [HttpGet]
        [ODataRoute("GetMessagesByPostId(PostId={postId})")]
        public IHttpActionResult GetMessagesByPostId([FromODataUri]int postId)
        {
            IHttpActionResult actionResult = StatusCode(HttpStatusCode.NotFound);

            var result = _messageService.GetMessagesByPostId(postId);

            if (result != null)
            {
                actionResult = Ok(result);
            }

            return actionResult;
        }

        [HttpPost]
        [ODataRoute(("AddMessage"))]
        public IHttpActionResult AddMessage(ODataActionParameters parameters)
        {
            IHttpActionResult actionResult = BadRequest();

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            MessageDto request = parameters["Request"] as MessageDto;

            if (request != null)
            {
                _messageService.AddMessage(request);

                actionResult = Ok();
            }

            return actionResult;
        }
    }
}