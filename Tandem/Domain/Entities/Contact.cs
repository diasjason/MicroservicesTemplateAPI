using Cosmonaut.Attributes;
using Newtonsoft.Json;

namespace MicroservicesTemplateAPI.Domain.Entities
{
    [CosmosCollection("contacts")]
    public class Contact
    {
        [CosmosPartitionKey]
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string AssignedTo { get; set; }

    }
}
