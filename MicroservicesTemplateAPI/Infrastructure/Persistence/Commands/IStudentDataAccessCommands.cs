using MicroservicesTemplateAPI.Domain.Entities;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Infrastructure.Persistence.Commands
{
    public interface IStudentDataAccessCommands
    {
        Task<bool> AddStudent(Student student);
        Task<bool> UpdateStudent(Student student);
        Task<bool> StudentExists(string email);
    }
}
