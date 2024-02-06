using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MutantSuplements.API.Entities;
using MutantSuplements.API.Services.interfaces;
using MutantSuplements.API.DTOs.UserDTOs;

namespace MutantSuplements.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _repository;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository repository, IMapper mapper, IConfiguration config)
        {
            _repository = repository;
            _mapper = mapper;
            _config = config;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate([FromBody] UserLoginDTO credentials)
        {
            var user = _repository.ValidateCredentials(credentials);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            var salt = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["AuthenticationConfiguration:Salt"])); 
            var signingCredentials = new SigningCredentials(salt, SecurityAlgorithms.HmacSha256);

            
            var claims = new List<Claim>();
            claims.Add(new Claim("sub", user.Id.ToString())); 
            claims.Add(new Claim("given_name", user.UserName)); 
            claims.Add(new Claim("Email", user.Email)); 
            claims.Add(new Claim("role", user.Role ?? "Client"));

            var jwtSecurityToken = new JwtSecurityToken( 
              _config["AuthenticationConfiguration:Issuer"],
              _config["AuthenticationConfiguration:Audience"],
              claims,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              signingCredentials);

            string tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn); 
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUsers()
        {

            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            if (role != "Admin")
            {
                return Unauthorized("Not authorized to view users.");
            }

            List<User> users = _repository.GetUsersWithoutOrders().ToList();

            var usersDto = _mapper.Map<List<UserDTO>>(users);
            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUser(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value ?? "0");

            if (role != "Admin")
            {
                if (userId != id)
                    return Unauthorized("Not authorized to view users.");
            }

            var user = _repository.GetUser(id);
            if (user is null)
            {
                return NotFound("The user does not exist");
            }

            return Ok(_mapper.Map<UserDTO>(user));
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserToCreateDTO userToCreate)
        {
            if (_repository.UserNameExists(userToCreate.Username))
            {
                return BadRequest("Username already exist.");
            }

            if (_repository.EmailExists(userToCreate.Email))
            {
                return BadRequest("Email already exist");
            }

            var user = _mapper.Map<User>(userToCreate);

            _repository.AddUser(user);
            _repository.SaveChanges();
            var userDto = _mapper.Map<UserDTO>(user);

            return Created("Created", userDto);
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateUsername(int id, [FromHeader] string userNameUpdated)
        {
            var user = _repository.GetUser(id);
            if (user is null)
            {
                return NotFound("The user does not exist");
            }

            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value ?? "0");

            if (role != "Admin")
            {
                if (userId != id)
                    return Unauthorized("Not authorized to update users.");
            }

            user.UserName = userNameUpdated;

            _repository.Update(user);

            _repository.SaveChanges();

            return Ok("Name updated succesfully");
        }

        [HttpDelete("{idUser}")]
        [Authorize]
        public ActionResult DeleteUser(int idUser)
        {

            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value ?? "0");

            if (role != "Admin")
            {
                if (userId != idUser)
                    return Unauthorized("Not authorized to delete users.");
            }

            var userToDelete = _repository.GetUser(idUser);
            if (userToDelete is null)
                return NotFound();

            _repository.DeleteUser(userToDelete);
            _repository.SaveChanges();

            return NoContent();

        }
    }
}
