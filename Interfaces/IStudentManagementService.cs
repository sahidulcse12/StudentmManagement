using Newtonsoft.Json;
using StudentmManagement.Models;

namespace StudentmManagement.Interfaces
{
    public interface IStudentManagementService
    {
        public void Add(Student newStudent);
        public bool Update(string id, Student updatedStudent);
        public Student? GetById(string id);
        public IList<Student> GetAll();
        public bool Delete(string id);

    }
}
