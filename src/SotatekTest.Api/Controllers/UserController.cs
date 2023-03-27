using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SotatekTest.Application.Dtos.User;
using SotatekTest.Application.Features.Commands.User;
using SotatekTest.Application.Features.Queries.User;
using SotatekTest.Domain.Entities;
using System.Net;

namespace SotatekTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserList([FromQuery] SelectUserFilter filter)
        {
            var listUser = await _mediator.Send(new GetUserQuery(filter));
            return Ok(listUser);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertUser([FromBody] InsertUserDto model)
        {
            try
            {
                return Ok(await _mediator.Send(new InsertUserCommand(model)));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
