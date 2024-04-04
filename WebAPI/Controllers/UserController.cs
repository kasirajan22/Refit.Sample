using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>{
            new User{Id = 1, Name = "User 1", Email = "User1@demo.com", Country = "India"},
            new User{Id = 2, Name = "User 2", Email = "User2@demo.com", Country = "US"},
            new User{Id = 3, Name = "User 3", Email = "User3@demo.com", Country = "UK"},
            new User{Id = 4, Name = "User 4", Email = "User4@demo.com", Country = "France"},
            new User{Id = 5, Name = "User 5", Email = "User5@demo.com", Country = "Germany"}
        };

        [HttpGet("GetAllUsers")]
        public IEnumerable<User> Get()
        {
            return users;
        }

        [HttpGet("GetUserByID/{id}")]
        public User? GetUserByID(int id)
        {
            return users.FirstOrDefault(a => a.Id.Equals(id));
        }

        [HttpPost("AddUser")]
        public void Post([FromBody] User user)
        {
            users.Add(user);
        }

        [HttpPut("UpdateUser/{id}")]
        public void Put(int id, [FromBody] User user)
        {
            var existUser = users.FirstOrDefault(a => a.Id.Equals(id));
            if (existUser is not null)
                users.Remove(existUser);

            users.Add(user);
        }

        [HttpDelete("DeleteUser/{id}")]
        public void Delete(int id)
        {
            var existUser = users.FirstOrDefault(a => a.Id.Equals(id));
            Console.WriteLine(existUser is not null);
            if (existUser != null)
                users.Remove(existUser);
        }
    }
}
