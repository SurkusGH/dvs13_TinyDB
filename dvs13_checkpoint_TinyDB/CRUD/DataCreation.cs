using dvs13_TinyDB.CRUD;
using dvs13_TinyDB.DataAccess;
using dvs13_TinyDB.DataModels;
using dvs13_TinyDB.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace dvs13_TinyDB.Functions
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

            DublicationCatcher.CheckCourses(course);
            course.StudentList.Add(AddStudent(course));

            db.Courses.Add(course);
            db.SaveChanges();
        }
        public static Student AddStudent(Course course)
        {
            Student student = new();
            Console.WriteLine($"Declare *Student* name");
            student.Name = Console.ReadLine();

            DublicationCatcher.CheckStudents(student);
            student.Course = course;

            student.LectureList.Add(AddLecture(course, student));

            Console.WriteLine("Lectures to be added:");
            DataReading.QueryLecturesByStudent(student);

            Console.WriteLine($"Add *More* lectures? y/n");
            var input = InputValidation.CharInputValidation();

            while (input == "y")
            {
                Console.WriteLine("Lectures to be added:");
                DataReading.QueryLecturesByStudent(student);

                student.LectureList.Add(AddLecture(course, student));
                Console.WriteLine($"Add *More* lectures? y/n");
                input = InputValidation.CharInputValidation();
            }

            return student;
        }
        public static Lecture AddLecture(Course course, Student student)
        {
            Lecture lecture = new();
            Console.WriteLine($"Declare *Lecture* name");
            var lectureName = Console.ReadLine();
            lecture.Name = lectureName;

            DublicationCatcher.CheckLectures(lecture);

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
            int index = 1;

            Console.WriteLine("Existing Courses");
            db.Courses.Select(x => x.Name).ToList().ForEach(x => Console.WriteLine($"{index++} - {x}"));
            var indexLimiter = db.Courses.Select(x => x.Name).ToList().Count();

            Console.WriteLine("Select to which Course to add to:");
            var targetCourse = db.Courses.SingleOrDefault(x => x.ID == InputValidation.IntInputValidation(indexLimiter));

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

            DublicationCatcher.CheckLectures(lecture);
            lecture.CourseList.Add(course);

            return lecture;
        }
        #endregion

        #region (2.3)
        // (2.3) Sukurti paskaitą ir ją priskirti prie departamento;
        public static void ToExistingCourse_Add_Lectures()
        {
            int index = 1;
            Course course = new();

            db.Courses.Select(x => x.Name).ToList().ForEach(x => Console.WriteLine($"{index++} - {x}"));
            var indexLimiter = db.Courses.Select(x => x.Name).ToList().Count();

            Console.WriteLine("Select to which Course to add to:");
            var targetCourse = db.Courses.SingleOrDefault(x => x.ID == InputValidation.IntInputValidation(indexLimiter));

            Console.WriteLine($"Course: #{targetCourse.ID} - {targetCourse.Name} selected");
            targetCourse.LectureList.Add(AddLecture(targetCourse));

            Console.WriteLine($"Lectures in this ({targetCourse.Name}) course:");
            DataReading.QueryLecturesByCourse(targetCourse);

            Console.WriteLine($"Add *More* lectures? y/n");
            var input = InputValidation.CharInputValidation();

            while (input == "y")
            {
                Console.WriteLine($"Lectures in this ({targetCourse.Name}) course:");
                DataReading.QueryLecturesByCourse(targetCourse);

                targetCourse.LectureList.Add(AddLecture(targetCourse));
                Console.WriteLine($"Add *More* lectures? y/n");
                input = InputValidation.CharInputValidation();
            }

            db.Update(targetCourse);
            db.SaveChanges();

            Root.Menu();
        }
        #endregion

    }
}
