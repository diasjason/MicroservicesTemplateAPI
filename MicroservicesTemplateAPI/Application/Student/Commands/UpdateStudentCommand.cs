using AutoMapper;
using MediatR;
using MicroservicesTemplate.Common.Exceptions;
using MicroservicesTemplateAPI.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;
using MicroservicesTemplateAPI.Application.Automapper;

namespace MicroservicesTemplateAPI.Application.Student.Commands
{
    public class UpdateStudentCommand : IRequest<bool>, IMapFrom<Domain.Entities.Student>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string AssignedTo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateStudentCommand, Domain.Entities.Student>(MemberList.Source);
        }
    }
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _studentService.GetStudentByEmailAsync(request.Email);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Student), request.Email);
            }
            var student = _mapper.Map<Domain.Entities.Student>(request);

            return await _studentService.PutStudent(student);
        }
    }
}
