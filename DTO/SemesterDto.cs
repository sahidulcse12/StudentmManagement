using static StudentmManagement.Enums.Enums;
using StudentmManagement.Models;

namespace StudentmManagement.DTO
{
    public class SemesterDto
    {
        public SemesterCode SemesterCode { get; set; }
        public string Year { get; set; }
    }
}
