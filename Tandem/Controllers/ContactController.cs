using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTemplateAPI.Application.Contact.Commands;
using MicroservicesTemplateAPI.Application.Contact.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesTemplateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ApiController
    {
        [HttpGet]
        public async Task<List<ContactVm>> Get()
        {
            return await Mediator.Send(new GetContactsQuery());
        }

        [HttpGet("{email}")]
        public async Task<ContactVm> Get(string email)
        {
            return await Mediator.Send(new GetContactByEmailQuery { Email=email});
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] CreateContactCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{email}")]
        public async Task<bool> Update(string email, UpdateContactCommand command)
        {
            return await Mediator.Send(command);            
        }
    }
}
