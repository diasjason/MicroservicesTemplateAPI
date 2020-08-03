using System;

namespace MicroservicesTemplate.Common.Entities
{
    public abstract class AuditableEntity
    {
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}