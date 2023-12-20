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

    public class StudentResponseDto
    {
        public StudentResponseDto()
        {
            AttendedCourse = new List<CourseDto>();
            SemestersAttended = new List<SemesterDto>();
        }
        public string FirstName { get; set; }
        public string MidlleName { get; set; }
        public string LastName { get; set; }
        public string? JoiningBatch { get; set; }
        public Dept Department { get; set; }
        public Degree Degree { get; set; }
        public IList<CourseDto> AttendedCourse { get; set; }
        public IList<SemesterDto> SemestersAttended { get; set; }
    }
}
