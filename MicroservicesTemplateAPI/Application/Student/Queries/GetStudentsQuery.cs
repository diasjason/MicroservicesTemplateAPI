using AutoMapper;
using MediatR;
using MicroservicesTemplateAPI.Infrastructure.Persistence.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Application.Student.Queries
{
    public class GetStudentsQuery : IRequest<List<StudentVm>>
    {
    }

    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<StudentVm>>
    {
        private readonly IStudentDataAccessQueries _studentService;
        private readonly IMapper _mapper;

        public GetStudentsQueryHandler(IStudentDataAccessQueries studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<List<StudentVm>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var response = await _studentService.GetStudentsAsync();
            var viewModel = _mapper.Map<List<StudentVm>>(response);

            return await Task.FromResult(viewModel);
        }
    }
}
