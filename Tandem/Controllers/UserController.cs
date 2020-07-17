using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tandem.Application.User.Commands;
using Tandem.Application.User.Queries;

namespace Tandem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        [HttpGet]
        public async Task<List<UserVm>> Get()
        {
            return await Mediator.Send(new GetUsersQuery());
        }

        [HttpGet("{email}", Name = "Get")]
        public async Task<UserVm> Get(string email)
        {
            return await Mediator.Send(new GetUserByEmailQuery { Email = email });
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
