using DemoApiProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApiProject.Controllers
{
    /// <summary>
    /// A sample controller for working with Todo items
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")] //Notify that we are expecting/sending JSON
    public class TodoController : ControllerBase
    {
        /// <summary>
        /// Creates a new Todo item
        /// </summary>
        /// <remarks>
        ///  If validation criteria is not met you will get one of the reported errors
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="201">Object was created successfully, the id of the newly created item is returned</response>
        /// <response code="400">The request was invalid, the error message will be returned</response>
        /// <response code="409">The object already exists</response>
        [HttpPost("Create")] //I want to be custom with my routing
        // Without these, a 200 is always assumed by the API generation!
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public IActionResult Create(CreateTodoRequest request)
        {
            if(request.Title == "Error")
            {
                return BadRequest("Something horrible happened");
            }

            if(request.Title == "AlreadyExists")
            {
                return Conflict("The object already exists");
            }

            var newId = Guid.NewGuid();

            return Created();
        }

        /// <summary>
        /// Gets the full detail of the todo item
        /// </summary>
        /// <param name="id">The id of the todo</param>
        /// <returns></returns>
        /// <response code="200">The full information</response>
        [HttpGet("Get/{id}")]
        [ProducesResponseType(typeof(TodoItemResponse), StatusCodes.Status200OK)]
        public IActionResult Get(Guid id)
        {
            return new JsonResult(new TodoItemResponse());
        }
    }
}
