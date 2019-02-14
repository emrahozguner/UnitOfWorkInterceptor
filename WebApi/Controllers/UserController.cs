using System.Net.Http;
using System.Web.Http;
using WebApi.Entity;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public virtual HttpResponseMessage AddNewUser(AddNewUserRequest reqModel)
        {
            _userService.AddNewUser(reqModel);
            return Request.CreateResponse();
        }
    }
}