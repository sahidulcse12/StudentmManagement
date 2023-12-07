using StudentmManagement.Models;

namespace StudentmManagement.Interfaces
{
    public interface IstudentManagement
    {
        public bool Delete(string id);
        public bool Update(string id, StudentsModel updatedStudent);
        public void AddNewStudent(StudentsModel newStudent);
        public StudentsModel GetById(string id);
        public List<StudentsModel> GetAll();

    }
}
