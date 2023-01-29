using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_EF_Api.DTOs.User;
using Repository_EF_Api.Interfaces;
using Repository_EF_Api.Models;
using System.Net;

namespace Repository_EF_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAll()
        {
            return (await _userRepository.GetAll()).Select(UserResponse.FromUser).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetById(int id)
        {
            var product = await _userRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return UserResponse.FromUser(product);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromForm] UserRequest userRequest)
        {
            var user = userRequest.Adapt<User>();
            await _userRepository.Create(user);
            return StatusCode((int)HttpStatusCode.Created, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromForm] UserRequest userRequest)
        {
            if (id != userRequest.Id)
            {
                return BadRequest();
            }

            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            //userRequest.Adapt(user);
            //var result = _userRepository.Update(user);
            await _userRepository.Update(user);
            return Ok(UserResponse.FromUser(user));

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _userRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            await _userRepository.Delete(product);
            return NoContent();
        }
    }
}
