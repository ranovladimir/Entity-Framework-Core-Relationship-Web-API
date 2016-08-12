using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TouchCloudBackEnd.Entities.Administrations;
using TouchCloudBackEnd.Services.Administrations;

namespace TouchCloudBackEnd.V1.Controllers
{
    [Route("v1/api/[controller]")]
    public class ActionController : Controller
    {
        private IActionService actionService;


        public ActionController(IActionService actionService)
        {
            this.actionService = actionService;
        }


        [HttpPost]
        public IActionResult CreateAction([FromBody] Action newAction)
        {
            if (newAction == null)
            {
                return BadRequest();
            }
            actionService.Create(newAction);
            //            return idAction;
            return CreatedAtRoute("GetAction", new { Controller = "action", idAction = newAction.IdAction }, newAction);//201
        }



        [HttpGet("{idAction}", Name = "GetAction")]
        public IActionResult GetAction(int idAction)
        {
            var action = actionService.GetOne(idAction);
            if (action == null)
            {
                return NotFound();
            }
            return new ObjectResult(action);

        }

        public IActionResult GetAllAction()
        {
            var Actions = actionService.GetAll().ToList();
            return Ok(Actions);
        }



        [HttpPut("{idAction}")]
        public IActionResult UpdateAction(int idAction, [FromBody] Action newAction)
        {
            Action oldAction = actionService.GetOne(idAction);
            if (newAction == null)
            {
                return BadRequest();
            }
            else
            if (oldAction == null)
            {
                return NotFound();
            }
            else
            {
                Action updatedAction = actionService.Update(oldAction, newAction);
                return Ok(updatedAction);
            }
        }



        [HttpDelete("{idAction}")]
        public IActionResult DeleteAction(int idAction)
        {
            actionService.Delete(idAction);
            return new NoContentResult();//204
        }
    }
}
