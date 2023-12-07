using Newtonsoft.Json;
using StudentmManagement.Interfaces;
using StudentmManagement.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace StudentmManagement.Services
{
    public class StudentManagementService:IstudentManagement
    {
        private static string StudentsFilePath = "studentsdata.json";
        private readonly ILogger<StudentManagementService> _logger;
        private static List<StudentsModel>? _students;
        private static List<CoursesModel> courses = new List<CoursesModel>() 
        { 
            new CoursesModel {CourseId = "CSE 101", CourseName="C ", InstructorName="John De", NumberOfCredits=3.0},
            new CoursesModel {CourseId = "CSE 102", CourseName="Java ", InstructorName="Mickel", NumberOfCredits=3.5},
            new CoursesModel {CourseId = "CSE 103", CourseName="Go ", InstructorName="Aultman", NumberOfCredits=2.0},
            new CoursesModel {CourseId = "CSE 104", CourseName="C++ ", InstructorName="Roberto", NumberOfCredits=2.5},
            new CoursesModel {CourseId = "CSE 105", CourseName="C# ", InstructorName="Jerry", NumberOfCredits=3.5}
        };

        public StudentManagementService(ILogger<StudentManagementService> logger)
        {
            _logger = logger;
            _students = GetAll();
        }

        public List<StudentsModel> GetAll()
        {
            if (File.Exists(StudentsFilePath))
            {
                string json = File.ReadAllText(StudentsFilePath);
                return JsonConvert.DeserializeObject<List<StudentsModel>>(json) ?? new List<StudentsModel>();
            }
            return new List<StudentsModel>();
        }

        public StudentsModel GetById(string id)
        {
            return _students.Find(i => i.StudentId == id);
        }

        public void AddNewStudent(StudentsModel newStudent)
        {
            _students.Add(newStudent);
        }

        public bool Update(string id, StudentsModel updatedStudent)
        {
            var existingStudent = _students.Find(i => i.StudentId == id);
            if (existingStudent == null)
            {
                return false;
            }
            existingStudent.FirstName = updatedStudent.FirstName;
            return true;
        }
        public bool Delete(string id)
        {
            var existingStudent = _students.Find(i => i.StudentId == id);
            if(existingStudent == null)
            {
                return false;
            }
            _students.Remove(existingStudent);
            return true;
        }

    }
}
