using System.Web.OData;
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
    }
}