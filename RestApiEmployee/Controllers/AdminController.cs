using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestApiEmployee.Queries;

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

        [HttpGet("GetUserByName")]
        public async Task<IActionResult> GetAction([FromQuery] GetUserByName query)
            => Ok(await _mediator.Send(query));
    }
}