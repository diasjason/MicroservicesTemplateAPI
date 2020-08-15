using MicroservicesTemplate.Common.Entities;

namespace MicroservicesTemplateAPI.Domain.Entities
{
    public class Student:AuditableEntity
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
    }
}
