using AutoMapper;
using MediatR;
using MicroservicesTemplate.Common.Exceptions;
using MicroservicesTemplateAPI.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Application.Student.Queries
{
    public class GetStudentByEmailQuery : IRequest<StudentVm>
    {
        public string Email { get; set; }
    }
    public class GetStudentByEmailHandler : IRequestHandler<GetStudentByEmailQuery, StudentVm>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public GetStudentByEmailHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<StudentVm> Handle(GetStudentByEmailQuery request, CancellationToken cancellationToken)
        {
            var response = await _studentService.GetStudentByEmailAsync(request.Email);
            var viewModel = _mapper.Map<StudentVm>(response);

            if (viewModel == null)
            {
                throw new NotFoundException(nameof(Student), request.Email);
            }

            return await Task.FromResult(viewModel);
        }
    }
}
