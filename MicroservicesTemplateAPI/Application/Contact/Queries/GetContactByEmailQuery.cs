using AutoMapper;
using MediatR;
using MicroservicesTemplate.Common.Exceptions;
using MicroservicesTemplateAPI.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Application.Contact.Queries
{
    public class GetContactByEmailQuery : IRequest<ContactVm>
    {
        public string Email { get; set; }
    }
    public class GetContactByEmailHandler : IRequestHandler<GetContactByEmailQuery, ContactVm>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public GetContactByEmailHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<ContactVm> Handle(GetContactByEmailQuery request, CancellationToken cancellationToken)
        {
            var response = await _contactService.GetContactByEmailAsync(request.Email);
            var viewModel = _mapper.Map<ContactVm>(response);

            if (viewModel == null)
            {
                throw new NotFoundException(nameof(Contact), request.Email);
            }

            return await Task.FromResult(viewModel);
        }
    }
}
