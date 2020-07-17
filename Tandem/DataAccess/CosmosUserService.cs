using Cosmonaut;
using Cosmonaut.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tandem.Domain.Entities;

namespace Tandem.DataAccess
{
    public class CosmosUserService : IUserService
    {
        private readonly ICosmosStore<User> _userStore;
        public CosmosUserService(ICosmosStore<User> userStore)
        {
            _userStore = userStore;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userStore.Query().Where(x => x.EmailAddress == email).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userStore.Query().ToListAsync();
        }

        public async Task<bool> PostUser(User user)
        {
            var response = await _userStore.AddAsync(user);
            return response.IsSuccess;
        }
    }
}