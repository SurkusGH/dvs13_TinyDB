﻿using dvs13_TinyDB.CRUD;
using dvs13_TinyDB.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvs13_TinyDB.Functions
{
    public class DataReading
    {
        private readonly static Context db = new();

        #region (2.6)
        // (2.6) Atvaizduoti visus departamento studentus;

        public static void QueryStudentsByCourse()
        {
            var index = 1;
            Console.WriteLine("Select a course:");
            var selectedCourse = DataQuery.CourseSelector();

            Console.WriteLine("Course w/ asociated students");
            foreach (var student in selectedCourse.StudentList)
            {
                Console.WriteLine($"{index++} - {student.Name}");
            }
        }
        #endregion

        #region (2.7)
        // (2.7) Atvaizduoti visas departamento paskaitas;
        public static void QueryLecturesByCourse()
        {
            var index = 1;
            Console.WriteLine("Select a course:");
            var selectedCourse = DataQuery.CourseSelector();

            Console.WriteLine("Course w/ asociated students");
            foreach (var lecture in selectedCourse.LectureList)
            {
                Console.WriteLine($"{index++} - {lecture.Name}");
            }
        }

        #endregion

        #region (2.8)
        // (2.8) Atvaizduoti visas paskaitas pagal studentą.

        public static void QueryLecturesByStudent()
        {
            var index = 1;
            Console.WriteLine("Select a course:");
            var selectedStudent = DataQuery.StudentSelector();

            Console.WriteLine("Student w/ asociated lectures");
            foreach (var lecture in selectedStudent.LectureList)
            {
                Console.WriteLine($"{index++} - {lecture.Name}");
            }
        }

        #endregion

        #region AdditionalFunctionality
        public static void AllDataQuery()
        {
            var courses = db.Courses.Include(x => x.LectureList).Include(x => x.StudentList);
            var lectures = db.Lectures.Include(x => x.StudentList);

            Console.WriteLine("Course w/ asociated lectures");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.ID} - {course.Name}");

                foreach (var lecture in course.LectureList)
                {
                    Console.WriteLine($"         {lecture.ID} - {lecture.Name}");
                }
            }

            Console.WriteLine("Course w/ asociated students");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.ID} - {course.Name}");

                foreach (var student in course.StudentList)
                {
                    Console.WriteLine($"         {student.ID} - {student.Name}");
                }
            }

            Console.WriteLine("Lecture w/ asociated students");
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"{lecture.ID} - {lecture.Name}");

                foreach (var student in lecture.StudentList)
                {
                    Console.WriteLine($"         {student.ID} - {student.Name}");
                }
            }
        }
        public static void AllCoursesWithStudents()
        {
            var courses = db.Courses.Include(x => x.StudentList);
            Console.WriteLine("Course w/ asociated students");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.ID} - {course.Name}");

                foreach (var student in course.StudentList)
                {
                    Console.WriteLine($"         {student.ID} - {student.Name}");
                }
            }
        }
        public static void AllCoursesWithLectures()
        {
            var courses = db.Courses.Include(x => x.LectureList);
            Console.WriteLine("Course w/ asociated lectures");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.ID} - {course.Name}");

                foreach (var student in course.LectureList)
                {
                    Console.WriteLine($"         {student.ID} - {student.Name}");
                }
            }
        }
        public static void AllLecturesByStudent()
        {
            var lectures = db.Lectures.Include(x => x.StudentList);
            Console.WriteLine("Lecture w/ asociated students");
            foreach (var lecture in lectures)
            {
                Console.WriteLine($"{lecture.ID} - {lecture.Name}");

                foreach (var student in lecture.StudentList)
                {
                    Console.WriteLine($"         {student.ID} - {student.Name}");
                }
            }
        }

        #endregion
    }
}
