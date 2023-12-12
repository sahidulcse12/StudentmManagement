using System.ComponentModel.DataAnnotations;

namespace StudentmManagement.Models
{
    public class Course
    {
        public string CourseId { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string InstructorName { get; set; } = string.Empty;
        public double NumberOfCredits { get; set; }
    }
}
