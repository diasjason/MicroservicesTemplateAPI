using AutoMapper;
using MediatR;
using MicroservicesTemplateAPI.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Application.Contact.Queries
{
    public class GetContactsQuery : IRequest<List<ContactVm>>
    {
        public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, List<ContactVm>>
        {
            private readonly IContactService _contactService;
            private readonly IMapper _mapper;

            public GetContactsQueryHandler(IContactService contactService, IMapper mapper)
            {
                _contactService = contactService;
                _mapper = mapper;
            }

            public async Task<List<ContactVm>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
            {
                var response = await _contactService.GetContactsAsync();
                var viewModel = _mapper.Map<List<ContactVm>>(response);

                return await Task.FromResult(viewModel);
            }
        }
    }
}
