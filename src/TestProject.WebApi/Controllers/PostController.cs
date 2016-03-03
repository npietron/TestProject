using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Query;
using System.Web.OData.Routing;
using TestProject.Services.Contracts.Post;
using TestProject.Services.REST.Abstract;

namespace TestProject.WebApi.Controllers
{
    public class PostController : ODataController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IQueryable<PostDto> Get(ODataQueryOptions options)
        {
            var result = _postService.Get();

            if (options.Filter != null)
            {
                var settings = new ODataQuerySettings();
                result = options.Filter.ApplyTo(result, settings) as IQueryable<PostDto>;
            }

            return options.ApplyTo(result) as IQueryable<PostDto>;
        }

        [HttpGet]
        [ODataRoute("GetPostsByUserId(UserId={userId})")]
        public IHttpActionResult GetPostsByUser([FromODataUri]int userId)
        {
            IHttpActionResult actionResult = StatusCode(HttpStatusCode.NotFound);

            var result = _postService.GetPostsByUserId(userId);

            if (result != null)
                actionResult = Ok(result);

            return actionResult;
        }

        [HttpPost]
        [ODataRoute("AddPost")]
        public IHttpActionResult AddPost(ODataActionParameters parameters)
        {
            IHttpActionResult actionResult = BadRequest();

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            PostDto request = parameters["Request"] as PostDto;

            if (request != null)
            {
                _postService.AddPost(request);

                actionResult = Ok();
            }

            return actionResult;
        }
    }
}