﻿using dvs13_checkpoint_TinyDB.DataAccess;
using dvs13_checkpoint_TinyDB.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvs13_checkpoint_TinyDB.Functions
{

    public class DataCreation
    {
        private readonly static Context db = new();

        #region (2.1)
        // (2.1) Sukurti departamentą ir į jį pridėti studentus, paskaitas(papildomi points
        //       jei pridedamos paskaitos jau egzistuojančios duomenų bazėje);
        public static void AddCourse()
        {
            Course course = new();
            Console.WriteLine($"Declare *Course* name");

            course.Name = Console.ReadLine();

            course.StudentList.Add(AddStudent(course));

            db.Courses.Add(course);
            db.SaveChanges();
        }
        public static Student AddStudent(Course course)
        {
            Student student = new();

            Console.WriteLine($"Declare *Student* name");

            student.Name = Console.ReadLine();

            student.Course = course;

            student.LectureList.Add(AddLecture(course, student));

            Console.WriteLine($"Add *More* lectures? y/n");
            var input = InputValidationHelper.CharInputValidation();
            while (input == "y")
            {
                student.LectureList.Add(AddLecture(course, student));
                Console.WriteLine($"Add *More* lectures? y/n");
                input = InputValidationHelper.CharInputValidation();
            }

            return student;
        }
        public static Lecture AddLecture(Course course, Student student)
        {
            Lecture lecture = new();

            Console.WriteLine($"Declare *Lecture* name");
            var lectureName = Console.ReadLine();

            lecture.Name = lectureName;
            lecture.StudentList.Add(student);
            lecture.CourseList.Add(course);
            
            return lecture;
        }

        #endregion

        #region (2.2)
        // (2.2) Pridėti studentus / paskaitas į jau egzistuojantį departamentą;
        public static void ToExistingCourse_Add_StudentLectures()
        {
            Course course = new();
            Console.WriteLine("Existing Courses");
            int i = 1;
            db.Courses.Select(x => x.Name).ToList().ForEach(x => Console.WriteLine($"{i++} - {x}"));
            var indexLimiter = db.Courses.Select(x => x.Name).ToList().Count();
            Console.WriteLine("Select to which Course to add to:");
            var targetCourse = db.Courses.SingleOrDefault(x => x.ID == InputValidationHelper.IntInputValidation(indexLimiter));
            Console.WriteLine($"Course: #{targetCourse.ID} - {targetCourse.Name} selected");

            targetCourse.StudentList.Add(AddStudent(targetCourse));
            db.Update(targetCourse);
            db.SaveChanges();
        }
        public static Lecture AddLecture(Course course)
        {
            Lecture lecture = new();

            Console.WriteLine($"Declare *Lecture* name");
            var lectureName = Console.ReadLine();

            lecture.Name = lectureName;
            lecture.CourseList.Add(course);

            return lecture;
        }
        #endregion

        #region (2.3)
        // (2.3) Sukurti paskaitą ir ją priskirti prie departamento;
        public static void ToExistingCourse_Add_Lectures()
        {
            Course course = new();
            Console.WriteLine("Existing Courses");
            int i = 1;
            db.Courses.Select(x => x.Name).ToList().ForEach(x => Console.WriteLine($"{i++} - {x}"));
            var indexLimiter = db.Courses.Select(x => x.Name).ToList().Count();
            Console.WriteLine("Select to which Course to add to:");
            var targetCourse = db.Courses.SingleOrDefault(x => x.ID == InputValidationHelper.IntInputValidation(indexLimiter));
            Console.WriteLine($"Course: #{targetCourse.ID} - {targetCourse.Name} selected");
            targetCourse.LectureList.Add(AddLecture(targetCourse));
            db.Update(targetCourse);
            db.SaveChanges();
        }
        #endregion

        #region (2.4)
        // (2.4) Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam
        //       egzistuojančias paskaitas;
        public static void ToExistingCourse_Add_CreatedStudent_AddExistingLectures()
        {
            Course course = new();
            Console.WriteLine("Existing Courses");
            int i = 1;
            db.Courses.Select(x => x.Name).ToList().ForEach(x => Console.WriteLine($"{i++} - {x}"));
            var indexLimiter = db.Courses.Select(x => x.Name).ToList().Count();
            Console.WriteLine("Select to which *Course* to add to:");
            var targetCourse = db.Courses.SingleOrDefault(x => x.ID == InputValidationHelper.IntInputValidation(indexLimiter));
            Console.WriteLine($"Course: #{targetCourse.ID} - {targetCourse.Name} selected");

            //AddStudent_LecturesFromList(targetCourse);

            targetCourse.StudentList.Add(AddStudent_LecturesFromList(targetCourse));

            db.Update(targetCourse);
            db.SaveChanges();
        }

        public static Student AddStudent_LecturesFromList(Course course)
        {
            Student student = new();

            Console.WriteLine($"Declare *Student* name");

            student.Name = Console.ReadLine();

            student.Course = course;

            student.LectureList.Add(AddLectureFromList(course, student));

            Console.WriteLine($"Add *More* lectures? y/n");
            var input = InputValidationHelper.CharInputValidation();
            while (input == "y")
            {
                student.LectureList.Add(AddLectureFromList(course, student));
                Console.WriteLine($"Add *More* lectures? y/n");
                input = InputValidationHelper.CharInputValidation();
            }

            return student;
        }

        public static Lecture AddLectureFromList(Course course, Student student)
        {
            int i = 1;
            var indexedCourse = db.Courses.Include(x => x.LectureList).Where(x => x.ID == course.ID);
            var indexLimiter = db.Courses.Include(x => x.LectureList).Where(x => x.ID == course.ID).Count();

            Console.WriteLine("Select to which Lecture to add:");
            foreach (var lecture in indexedCourse) {Console.WriteLine($"{i++} - {lecture.Name}");}

            var queryedLectures = db.Lectures.Include(x => x.CourseList).Where(x => x.ID == course.ID);

            var targetLecture = queryedLectures.SingleOrDefault(x => x.ID == InputValidationHelper.IntInputValidation(indexLimiter));
            return targetLecture;
        }

            #endregion
    }
}
