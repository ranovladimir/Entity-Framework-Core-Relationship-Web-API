using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TouchCloudBackEnd.Entities.Administrations;
using TouchCloudBackEnd.Services.Administrations;

namespace TouchCloudBackEnd.V1.Controllers
{
    [Route("v1/api/[controller]")]
    public class RoleUserController : Controller
    {
        private IRoleUserService roleUserService;


        public RoleUserController(IRoleUserService roleUserService)
        {
            this.roleUserService = roleUserService;
        }


        [HttpPost]
        public IActionResult CreateRoleUser([FromBody] RoleUser newRoleUser)
        {
            if (newRoleUser == null)
            {
                return BadRequest();
            }
            roleUserService.Create(newRoleUser);
            //            return idRoleUser;
            return CreatedAtRoute("GetRoleUser", new { Controller = "roleUser", idRoleUser = newRoleUser.IdRoleUser }, newRoleUser);//201
        }



        [HttpGet("{idRoleUser}", Name = "GetRoleUser")]
        public IActionResult GetRoleUser(int idRoleUser)
        {
            var roleUser = roleUserService.GetOne(idRoleUser);
            if (roleUser == null)
            {
                return NotFound();
            }
            return new ObjectResult(roleUser);

        }

        public IActionResult GetAllRoleUser()
        {
            var roleUsers = roleUserService.GetAll().ToList();
            return Ok(roleUsers);
        }



        [HttpPut("{idRoleUser}")]
        public IActionResult UpdateRoleUser(int idRoleUser, [FromBody] RoleUser newRoleUser)
        {
            RoleUser oldRoleUser = roleUserService.GetOne(idRoleUser);
            if (newRoleUser == null)
            {
                return BadRequest();
            }
            else
            if (oldRoleUser == null)
            {
                return NotFound();
            }
            else
            {
                RoleUser updatedRoleUser = roleUserService.Update(oldRoleUser, newRoleUser);
                return Ok(updatedRoleUser);
            }
        }



        [HttpDelete("{idRoleUser}")]
        public IActionResult DeleteRoleUser(int idRoleUser)
        {
            roleUserService.Delete(idRoleUser);
            return new NoContentResult();//204
        }
    }
}
