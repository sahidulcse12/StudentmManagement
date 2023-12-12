using static StudentmManagement.Enums.Enums;

namespace StudentmManagement.Models
{
    public class Student
    {
        public Student()
        {
            SemestersAttended = new List<Semester>();
            AttendedCourse = new List<Course>();
            JoiningBatch = string.Empty;
        }

        public string FirstName { get; set; }=string.Empty;
        public string MidlleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string? JoiningBatch { get; set; }
        public Dept Department { get; set; } = Dept.None;
        public Degree Degree { get; set; } = Degree.None;

        public List<Course> AttendedCourse { get; set; }
        public List<Semester> SemestersAttended { get; set; }
    }
}
