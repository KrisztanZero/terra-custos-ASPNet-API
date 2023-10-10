using Microsoft.AspNetCore.Mvc;
using terra_custos_aspnet_web_api.IRepositories;
using terra_custos_aspnet_web_api.IService;
using terra_custos_aspnet_web_api.Models;

namespace terra_custos_aspnet_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : GenericController<User>
    {
        private readonly IUserService _userService;

        public UserController(IGenericService<User> service, IUserService userService) : base(service)
        {
            _userService = userService;
        }

        [HttpGet("get-by-name/{username}")]
        public async Task<ActionResult<User>> GetUserByName(string username)
        {
            var user = await _userService.GetByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
