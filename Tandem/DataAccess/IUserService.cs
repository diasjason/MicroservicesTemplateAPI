using System.Collections.Generic;
using System.Threading.Tasks;
using Tandem.Domain.Entities;

namespace Tandem.DataAccess
{
    public interface IUserService
    {
        public Task<List<User>> GetUsersAsync();
        public Task<User> GetUserByEmailAsync(string email);

        //TODO: Refactor PostUser to return Id for better testing.
        public Task<bool> PostUser(User user);
    }
}
