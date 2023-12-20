using Microsoft.EntityFrameworkCore;
using StudentmManagement.Models;

namespace StudentmManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-8TSS50J\\SQLEXPRESS01;Database=studentManagement;Integrated Security=true;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                        .HasMany(a => a.AttendedCourse)
                        .WithMany(c => c.Students);
            modelBuilder.Entity<Student>()
                        .HasMany(se => se.SemestersAttended)
                        .WithMany(s => s.Students);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Semester> Semesters { get; set; }
    }
}
