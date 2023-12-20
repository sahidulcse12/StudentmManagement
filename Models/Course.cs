using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StudentmManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseCode { get; set; } 
        public string CourseName { get; set; }
        public string InstructorName { get; set; } 
        public double NumberOfCredits { get; set; }
        public IList<Student> Students { get; set; }
    }
}
