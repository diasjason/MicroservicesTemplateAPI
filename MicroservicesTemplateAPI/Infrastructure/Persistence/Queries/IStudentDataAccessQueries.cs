using MicroservicesTemplateAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Infrastructure.Persistence.Queries
{
    public interface IStudentDataAccessQueries
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentByEmailAsync(string email);
    }
}
