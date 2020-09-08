using AutoMapper;
using MicroservicesTemplateAPI.Application.Automapper;

namespace MicroservicesTemplateAPI.Application.Student.Queries
{
    public class StudentVm : IMapFrom<Domain.Entities.Student>
    {
        public string StudentId { get; set; }
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
            profile.CreateMap<Domain.Entities.Student, StudentVm>(MemberList.Destination)
                .ForMember(d => d.StudentId, opt => opt.MapFrom(s => s.StudentId));
        }
    }
}
