using static StudentmManagement.Enums.Enums;
using StudentmManagement.Models;

namespace StudentmManagement.DTO
{
    public class StudentDto
    {
        public StudentDto()
        {
            AttendedCourse = new List<int>();
            SemestersAttended = new List<int>();
        }
        public string FirstName { get; set; }
        public string MidlleName { get; set; }
        public string LastName { get; set; }
        public string? JoiningBatch { get; set; }
        public Dept Department { get; set; }
        public Degree Degree { get; set; }
        public IList<int> AttendedCourse { get; set; }
        public IList<int> SemestersAttended { get; set; }
    }
}
