using static StudentmManagement.Enums.Enums;

namespace StudentmManagement.Models
{
    public class Semester 
    {
        public int Id { get; set; }
        public SemesterCode SemesterCode { get; set; }
        public string? Year { get; set; }
        public IList<Student> Students { get; set; }
    }
}
