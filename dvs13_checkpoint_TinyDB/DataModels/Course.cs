using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvs13_TinyDB.DataModels
{
    public class Course : Common
    {
        public string Name { get; set; } = string.Empty;
        public List<Lecture> LectureList { get; set; } = new();
        public List<Student> StudentList { get; set; } = new();
    }
}
