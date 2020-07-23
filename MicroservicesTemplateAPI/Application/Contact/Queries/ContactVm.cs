using AutoMapper;
using MicroservicesTemplateAPI.Application.Automapper;

namespace MicroservicesTemplateAPI.Application.Contact.Queries
{
    public class ContactVm : IMapFrom<Domain.Entities.Contact>
    {
        public string ContactId { get; set; }
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
            profile.CreateMap<Domain.Entities.Contact, ContactVm>(MemberList.Destination)
                .ForMember(d => d.ContactId, opt => opt.MapFrom(s => s.Id));
        }
    }
}
