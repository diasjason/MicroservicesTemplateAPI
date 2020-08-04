using MicroservicesTemplateAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicesTemplateAPI.Infrastructure.Persistence
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetStudentByEmailAsync(string email);

        //TODO: Refactor PostContact to return Id for better testing.
        public Task<bool> PostStudent(Student student);
        public Task<bool> PutStudent(Student student);
    }
}
