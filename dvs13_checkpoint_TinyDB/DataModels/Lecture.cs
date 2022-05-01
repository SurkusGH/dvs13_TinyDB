using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvs13_checkpoint_TinyDB.DataModels
{
    public class Lecture
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Student> StudentList { get; set; } = new();
        public List<Course> CourseList { get; set; } = new();
    }
}
