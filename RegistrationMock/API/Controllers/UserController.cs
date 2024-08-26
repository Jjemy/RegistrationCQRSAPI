using Microsoft.AspNetCore.Mvc;
using MediatR;
using RegistrationMock.Application.Commands;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
                return Ok(new { message = "User registered successfully" });

            return BadRequest(new { message = "User registration failed" });
        }

        //// POST: api/user/login
        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        //{
        //    var token = await _mediator.Send(command);
        //    if (!string.IsNullOrEmpty(token))
        //        return Ok(new { token });

        //    return Unauthorized(new { message = "Invalid email or password" });
        //}

        //// GET: api/user/finance-requests
        //[HttpGet("finance-requests")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> GetFinanceRequests([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string requestNumber = null, [FromQuery] string status = null)
        //{
        //    // Assuming a GetFinanceRequestsQuery and corresponding handler exists
        //    var query = new GetFinanceRequestsQuery(page, pageSize, requestNumber, status);
        //    var result = await _mediator.Send(query);

        //    return Ok(result);
        //}
    }
}