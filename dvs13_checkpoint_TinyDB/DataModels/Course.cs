using System.Collections.Generic;

namespace dvs13_TinyDB.DataModels
{
    public class Course : Common
    {
        public string Name { get; set; } = string.Empty;
        public List<Lecture> LectureList { get; set; } = new();
        public List<Student> StudentList { get; set; } = new();
    }
}
