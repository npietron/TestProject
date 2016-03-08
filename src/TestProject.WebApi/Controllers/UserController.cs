using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using TestProject.Services.Contracts.User;
using TestProject.Services.REST.Abstract;

namespace TestProject.WebApi.Controllers
{
    public class UserController : ODataController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IQueryable<UserDto> Get(ODataQueryOptions options)
        {
            var result = _userService.Get();

            if (options.Filter != null)
            {
                var settings = new ODataQuerySettings();
                result = options.Filter.ApplyTo(result, settings) as IQueryable<UserDto>;
            }

            return options.ApplyTo(result) as IQueryable<UserDto>;
        }

        [HttpGet]
        [ODataRoute("GetUserById(UserId={userId})")]
        public IHttpActionResult GetUserById([FromODataUri]int userId)
        {
            IHttpActionResult actionResult = StatusCode(HttpStatusCode.NotFound);

            var result = _userService.Get(userId);

            if (result != null)
                actionResult = Ok(result);

            return actionResult;
        }

        [HttpGet]
        [ODataRoute("GetUserIdByUserName(UserName={userName})")]
        public IHttpActionResult GetUserIdByUserName([FromODataUri]string userName)
        {
            IHttpActionResult actionResult = StatusCode(HttpStatusCode.NotFound);

            var result = _userService.Get().FirstOrDefault(x => x.UserName == userName);

            if (result != null)
                actionResult = Ok(result);

            return actionResult;
        }

        [HttpGet]
        [ODataRoute("DoesUserExists(UserName={userName})")]
        public bool DoesUserExists([FromODataUri]string userName)
        {
            return _userService.DoesUserExists(userName);
        }

        [HttpPost]
        [ODataRoute("AddUser")]
        public IHttpActionResult AddUser(ODataActionParameters parameters)
        {
            IHttpActionResult actionResult = BadRequest();

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            UserDto request = parameters["Request"] as UserDto;

            if (request != null)
            {
                _userService.AddUser(request);

                actionResult = Ok();
            }

            return actionResult;
        }
    }
}