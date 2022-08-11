using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestApiEmployee.Queries;
using System.Net;

namespace RestApiEmployee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;

        private readonly IMediator _mediator;

        public AdminController(ILogger<AdminController> logger,
                               IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetEmployeeByName")]
        public async Task<IActionResult> GetAction([FromQuery] GetEmployeeByName query)
            => Ok(await _mediator.Send(query));

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> AddEmployee(CreateEmployee.EmployeeEntity employeeEntity)
            => Ok(await _mediator.Send(employeeEntity));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAction(int id)
        {
            try
            {
                await _mediator.Send(new RemoveEmployeeById {Id = id});
            }
            catch (Exception ex)
            {
                return NotFound(new { ErrorCode = HttpStatusCode.NotFound,
                                      Message = ex.Message });
            }

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployee.Parametrs query)
        {
            try
            {
                await _mediator.Send(query);
            }
            catch(Exception ex)
            {
                return NotFound(new
                {
                    ErrorCode = HttpStatusCode.NotFound,
                    Message = ex.Message});
            }
            return NoContent();
        }
            

    }
}