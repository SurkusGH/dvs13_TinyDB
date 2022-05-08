using System.Collections.Generic;

namespace dvs13_TinyDB.DataModels
{
    public class Student : Common
    {
        public string Name { get; set; }
        public List<Lecture> LectureList { get; set; } = new();
        public Course Course { get; set; }
    }
}
