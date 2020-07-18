using Cosmonaut;
using Cosmonaut.Extensions;
using MicroservicesTemplateAPI.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Infrastructure.Persistence
{
    public class CosmosContactService : IContactService
    {
        private readonly ICosmosStore<Contact> _contactStore;
        public CosmosContactService(ICosmosStore<Contact> contactStore)
        {
            _contactStore = contactStore;
        }
        public async Task<Contact> GetContactByEmailAsync(string email)
        {
            return await _contactStore.Query().Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            return await _contactStore.Query().ToListAsync();
        }

        public async Task<bool> PostContact(Contact contact)
        {
            var response = await _contactStore.AddAsync(contact);
            return response.IsSuccess;
        }

        public async Task<bool> PutContact(Contact contact)
        {
            var response = await _contactStore.UpdateAsync(contact);
            return response.IsSuccess;
        }
    }
}
