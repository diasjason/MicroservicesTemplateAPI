using AutoMapper;
using MediatR;
using MicroservicesTemplateAPI.Application.Automapper;
using MicroservicesTemplateAPI.Infrastructure.Persistence.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Application.Student.Commands
{
    public class CreateStudentCommand : IRequest<bool>, IMapFrom<Domain.Entities.Student>
    {
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string AssignedTo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateStudentCommand, Domain.Entities.Student>(MemberList.Source)
                .ForMember(d => d.StudentId, opt => opt.MapFrom(s => Guid.NewGuid().ToString()));
        }
    }
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly IStudentDataAccessCommands _studentService;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IStudentDataAccessCommands studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Domain.Entities.Student>(request);

            return await _studentService.AddStudent(student);
        }
    }
}
