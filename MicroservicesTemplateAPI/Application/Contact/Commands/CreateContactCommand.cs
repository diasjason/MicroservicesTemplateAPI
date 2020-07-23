using AutoMapper;
using MediatR;
using MicroservicesTemplateAPI.Infrastructure.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using MicroservicesTemplateAPI.Application.Automapper;

namespace MicroservicesTemplateAPI.Application.Contact.Commands
{
    public class CreateContactCommand : IRequest<bool>, IMapFrom<Domain.Entities.Contact>
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string AssignedTo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContactCommand, Domain.Entities.Contact>(MemberList.Source)
                .ForMember(d => d.Id, opt => opt.MapFrom(s => Guid.NewGuid().ToString()));
        }
    }
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, bool>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = _mapper.Map<Domain.Entities.Contact>(request);

            return await _contactService.PostContact(contact);
        }
    }
}
