using Cosmonaut.Attributes;
using Newtonsoft.Json;

namespace Tandem.Domain.Entities
{
    [CosmosCollection("users")]
    public class User
    {
        [CosmosPartitionKey]
        [JsonProperty("id")]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddelName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        //TODO:
        //EmailAddress could be the Partition Key for this senario
        public string EmailAddress { get; set; }
    }
}
