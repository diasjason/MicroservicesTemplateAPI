using AutoMapper;
using MediatR;
using MicroservicesTemplate.Common.Exceptions;
using MicroservicesTemplateAPI.Infrastructure.Persistence;
using System.Threading;
using System.Threading.Tasks;
using MicroservicesTemplateAPI.Application.Automapper;

namespace MicroservicesTemplateAPI.Application.Contact.Commands
{
    public class UpdateContactCommand : IRequest<bool>, IMapFrom<Domain.Entities.Contact>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string AssignedTo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContactCommand, Domain.Entities.Contact>(MemberList.Source);
        }
    }
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, bool>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public UpdateContactCommandHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _contactService.GetContactByEmailAsync(request.Email);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contact), request.Email);
            }
            var contact = _mapper.Map<Domain.Entities.Contact>(request);

            return await _contactService.PutContact(contact);
        }
    }
}
