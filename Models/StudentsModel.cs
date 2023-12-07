using static StudentmManagement.Enums.Enums;

namespace StudentmManagement.Models
{
    public class StudentsModel
    {
        public StudentsModel()
        {
            SemestersAttended = new List<SemesterModel>();
            AttendedCourse = new List<CoursesModel>();
            JoiningBatch = string.Empty;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; } = string.Empty;
        public string MidlleName { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string? JoiningBatch { get; set; }
        public Dept Department { get; set; } = Dept.None;
        public Degree Degree { get; set; } = Degree.None;

        public List<CoursesModel> AttendedCourse { get; set; }
        public List<SemesterModel> SemestersAttended { get; set; }
    }
}
