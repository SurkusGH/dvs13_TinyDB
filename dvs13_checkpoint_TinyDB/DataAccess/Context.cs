using dvs13_checkpoint_TinyDB.DataModels;
using Microsoft.EntityFrameworkCore;

namespace dvs13_checkpoint_TinyDB.DataAccess
{
    public class Context : DbContext
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                     => options.UseSqlServer($"Server=localhost;DataBase=dvs13_TinyDB;Trusted_Connection=True");
    }
}
