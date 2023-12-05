using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week_7.API.Models;
using Week_7.Domain.Entities;
using Week_7.Persistence.Contexts;

namespace Week_7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly Week_7DbContext _context;

        public UsersController(Week_7DbContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_context.Users.ToList());
        }



        [HttpPost("[action]")]

        public IActionResult CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            User user = new()
            {
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,
            };

            _context.Users.Add(user);

            //_context.SaveChanges();

            return Ok();
        }

        [HttpGet("[action]")]
        public string GetSomething(string name)
        {
            return name.Substring(0, 2);
        }
    }
}
