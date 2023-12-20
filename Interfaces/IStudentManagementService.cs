using Newtonsoft.Json;
using StudentmManagement.DTO;
using StudentmManagement.Models;

namespace StudentmManagement.Interfaces
{
    public interface IStudentManagementService
    {
        Task<List<Student>> GetAll();
        Task<Student?> GetById(int id);
        Task Add(StudentDto student);
        Task Update(int id, StudentDto request);
        Task Delete(int id);
        Task AddSingleCourse(CourseDto course);
        Task AddSingleSemester(SemesterDto semester);

    }
}
