using System.Collections.Generic;

namespace dvs13_TinyDB.DataModels
{
    public class Lecture : Common
    {
        public string Name { get; set; }
        public List<Student> StudentList { get; set; } = new();
        public List<Course> CourseList { get; set; } = new();
    }
}
