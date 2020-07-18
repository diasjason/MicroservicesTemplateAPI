using MicroservicesTemplateAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Infrastructure.Persistence
{
    public interface IContactService
    {
        public Task<List<Contact>> GetContactsAsync();
        public Task<Contact> GetContactByEmailAsync(string email);

        //TODO: Refactor PostContact to return Id for better testing.
        public Task<bool> PostContact(Contact contact);
        public Task<bool> PutContact(Contact contact);
    }
}
