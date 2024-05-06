using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Application.Services;
using UserManagementApp.Application.Validators;
using UserManagementApp.Domain.Entities;

namespace UserManagementApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var userInDb = await _userService.GetUserByIdAsync(id);
            if (userInDb == null)
            {
                return NotFound();
            }
            return Ok(userInDb);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await ValidateUser(user);

            try
            {
                var userAdded = await _userService.AddUserAsync(user);
                return CreatedAtAction(nameof(GetUserById), new { id = userAdded.Id }, userAdded);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            await ValidateUser(user);

            int userInDb = await _userService.UpdateUserAsync(id, user);
            if (userInDb == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            int userInDb = await _userService.DeleteUserAsync(id);
            if (userInDb == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }

        private async Task<IActionResult> ValidateUser(User user)
        {
            var validator = new UserValidator();
            var validationResult = await validator.ValidateAsync(user);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            return NoContent();
        }
    }
}
