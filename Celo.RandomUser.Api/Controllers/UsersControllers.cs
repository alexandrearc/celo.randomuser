using System.Threading.Tasks;
using Celo.RandomUser.Data;
using Celo.RandomUser.Requests;
using Celo.RandomUser.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Celo.RandomUser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var user = await _userService.GetAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("list")]
        public IActionResult List(ListRequest request)
        {
            return Ok(_userService.List(request));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(int id, UserRequest request)
        {
            return Ok(await _userService.UpdateAsync(new User
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Title = request.Title
            }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post()
        {
            return Ok(await _userService.CreateAsync());
        }
    }
}
