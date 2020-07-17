using AutoMapper;
using Tandem.Application.Common.AutoMapper;

namespace Tandem.Application.User.Queries
{
    public class UserVm : IMapFrom<Domain.Entities.User>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entities.User, UserVm>(MemberList.Destination)
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => $"{s.FirstName} {s.MiddelName} {s.LastName}"));
        }
    }
}