﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvs13_checkpoint_TinyDB.DataModels
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Lecture> LectureList { get; set; } = new();
        public Course Course { get; set; }
    }
}