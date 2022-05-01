﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvs13_checkpoint_TinyDB.DataModels
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Lecture> LectureList { get; set; } = new();
        public List<Student> StudentList { get; set; } = new();
    }
}