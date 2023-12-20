using StudentmManagement.Data;
using StudentmManagement.DTO;
using StudentmManagement.Interfaces;
using StudentmManagement.Models;

namespace StudentmManagement.Services
{
    public class StudentManagementService : IStudentManagementService
    {
        private readonly ILogger<StudentManagementService> _logger;
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IGenericRepository<Semester> _semesterRepository;

        public StudentManagementService(ILogger<StudentManagementService> logger, 
            IGenericRepository<Student> studentRepository,
            IGenericRepository<Course> courseRepository,
            IGenericRepository<Semester> semesterRepository
            )
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _semesterRepository = semesterRepository;
        }

        public async Task<List<Student>> GetAll()
        {
            var result = await _studentRepository.GetAll();
            return result.ToList();
        }

        public async Task<Student?> GetById(int id)
        {
            var result = await _studentRepository.GetById(id);
            if (result is null)
                return null;

            return result;
        }
        public async Task Add(StudentDto s)
        {
            var student = new Student
            {
                FirstName = s.FirstName,
                MidlleName = s.MidlleName,
                LastName = s.LastName,
                Degree = s.Degree,
                Department = s.Department,
                JoiningBatch = s.JoiningBatch,
            };
            var courses = await _courseRepository.GetAll();
            var cous = courses.Where(x => s.AttendedCourse.Contains(x.Id)).ToList();
            student.AttendedCourse = cous;

            var semesters = await _semesterRepository.GetAll();
            var sem = semesters.Where(x => s.SemestersAttended.Contains(x.Id)).ToList();
            student.SemestersAttended = sem;

            await _studentRepository.Add(student);
        }
        public async Task AddSingleCourse(CourseDto c)
        {
            var course = new Course
            {
                CourseCode = c.CourseCode,
                CourseName = c.CourseName,
                NumberOfCredits = c.NumberOfCredits,
                InstructorName = c.InstructorName,
            };
            await _courseRepository.Add(course);
        }
        public async Task AddSingleSemester(SemesterDto se)
        {
            var semester = new Semester
            {
                SemesterCode = se.SemesterCode,
                Year = se.Year,
            };
            await _semesterRepository.Add(semester);
        }
        public async Task Update(int id, StudentDto request)
        {
            var result = await _studentRepository.GetById(id);
            if (result is null)
                return;

            result.FirstName = request.FirstName;
            result.MidlleName = request.MidlleName;
            result.LastName = request.LastName;
            result.JoiningBatch = request.JoiningBatch;

            await _studentRepository.Update(result);
        }
        public async Task Delete(int id)
        {
            var result = await _studentRepository.GetById(id);
            if (result is null)
                return;

            await _studentRepository.Delete(id);
        }

    }
}
