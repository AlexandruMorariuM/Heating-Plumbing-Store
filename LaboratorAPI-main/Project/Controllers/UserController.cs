using Core.Services;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService{ get; set; }
        public UserController(UserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("/get-all")]
        public ActionResult<List<User>> GetAll()
        {
            var results = _userService.GetAll();

            return Ok(results);
        }

    }
}
