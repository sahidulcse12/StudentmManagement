using static StudentmManagement.Enums.Enums;

namespace StudentmManagement.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MidlleName { get; set; }
        public string LastName { get; set; } 
        public string? JoiningBatch { get; set; }
        public Dept Department { get; set; }
        public Degree Degree { get; set; }
        public IList<Course> AttendedCourse { get; set; }
        public IList<Semester> SemestersAttended { get; set; }
        //public IList<Course> Courses { get; set; }
        //public IList<Semester> Semesters { get; set; }
    }
}
