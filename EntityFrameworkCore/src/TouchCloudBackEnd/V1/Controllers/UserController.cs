using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TouchCloudBackEnd.Entities.Administrations;
using TouchCloudBackEnd.Services.Administrations;


namespace TouchCloudBackEnd.Controllers
{
    [Route("v1/api/[controller]")]
    public class UserController : Controller
    {
        private IUserService userService;


        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpPost]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            if (newUser == null)
            {
                return BadRequest();
            }
            userService.Create(newUser);
           // return idUser;
            return CreatedAtRoute("GetUser", new { Controller = "user", idUser = newUser.IdUser }, newUser);//201
        }



        [HttpGet("{idUser}", Name = "GetUser")]
        public IActionResult GetUser(int idUser)
        {
            var user = userService.GetOne(idUser);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);

        }

        public IActionResult GetAllUser(int pageNo = 1, int pageSize = 50)
        {
            var users = userService.GetAll().ToList();
            return Ok(users);
        }



        [HttpPut("{idUser}")]
        public IActionResult UpdateUser(int idUser, [FromBody] User newUser)
        {
            User oldUser = userService.GetOne(idUser);
            if (newUser == null)
            {
                return BadRequest();
            }
            else
            if (oldUser == null)
            {
                return NotFound();
            }
            else
            {
                User updatedUser = userService.Update(oldUser, newUser);
                return Ok(updatedUser);
            }
        }



        [HttpDelete("{idUser}")]
        public IActionResult DeleteUser(int idUser)
        {
            userService.Delete(idUser);
            return new NoContentResult();//204
        }
    }
}
