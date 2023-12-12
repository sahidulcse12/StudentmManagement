using Newtonsoft.Json;
using StudentmManagement.Interfaces;
using StudentmManagement.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace StudentmManagement.Services
{
    public class StudentManagementService : IStudentManagementService
    {
        private static string StudentsFilePath = "studentsData.json";
        private readonly ILogger<StudentManagementService> _logger;
        private static List<Student> _students = new List<Student>();

        public StudentManagementService(ILogger<StudentManagementService> logger)
        {
            _logger = logger;
            _students = Load();
        }

        public IList<Student> GetAll()
        {
            return _students;
        }

        public Student? GetById(string id)
        {
            return _students.Find(i => i.StudentId == id);
        }

        public void Add(Student newStudent)
        {
            _students.Add(newStudent);
            Save();
        }

        public bool Update(string id, Student updatedStudent)
        {
            var existingStudent = _students.Find(i => i.StudentId == id);
            if (existingStudent == null)
            {
                return false;
            }

            existingStudent.FirstName = updatedStudent.FirstName;
            existingStudent.MidlleName = updatedStudent.MidlleName;
            existingStudent.LastName = updatedStudent.LastName;
            existingStudent.JoiningBatch = updatedStudent.JoiningBatch;

            Save();

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

            Save();
            return true;
        }

        #region Helper Method
        public List<Student> Load()
        {
            if (File.Exists(StudentsFilePath))
            {
                string json = File.ReadAllText(StudentsFilePath);
                return JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();
            }
            return new List<Student>();
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(_students, Formatting.Indented);
            File.WriteAllText(StudentsFilePath, json);
        }
        #endregion


    }
}
