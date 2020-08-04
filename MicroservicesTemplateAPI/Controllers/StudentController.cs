using System.Collections.Generic;
using System.Threading.Tasks;
using MicroservicesTemplate.Common.Controller;
using MicroservicesTemplateAPI.Application.Student.Commands;
using MicroservicesTemplateAPI.Application.Student.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesTemplateAPI.Controllers
{

    public class StudentController : ApiController
    {
        [HttpGet]
        public async Task<List<StudentVm>> Get()
        {
            return await Mediator.Send(new GetStudentsQuery());
        }

        [HttpGet("{email}")]
        public async Task<StudentVm> Get(string email)
        {
            return await Mediator.Send(new GetStudentByEmailQuery { Email = email });
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] CreateStudentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<bool> Update(UpdateStudentCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
