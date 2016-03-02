using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData;
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
    }
}