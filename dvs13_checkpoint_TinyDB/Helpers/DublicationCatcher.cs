using dvs13_TinyDB.DataAccess;
using dvs13_TinyDB.DataModels;
using System;
using System.Linq;
namespace dvs13_TinyDB.Helpers
{
    public class DublicationCatcher
    {
        private readonly static Context db = new();
        public static void CheckCourses(Course course)
        {
            var courseList = db.Courses.ToList();
            foreach (var coursesInDb in courseList)
            {
                if (course.Name == coursesInDb.Name)
                {
                    Console.WriteLine($"Course {course.Name} is already in DB" +
                                      $"\nBack to main menu");
                    Root.Menu();
                }
                else
                {
                    continue;
                }
            }
        }
        public static void CheckLectures(Lecture lecture)
        {
            var lectureList = db.Lectures.ToList();
            foreach (var lecturesInDb in lectureList)
            {
                if (lecture.Name == lecturesInDb.Name)
                {
                    Console.WriteLine($"Lecture {lecture.Name} is already in DB" +
                                      $"\nBack to main menu");
                    Root.Menu();
                }
                else
                {
                    continue;
                }
            }
        }
        public static void CheckStudents(Student student)
        {
            var studentList = db.Students.ToList();
            foreach (var studentsInDb in studentList)
            {
                if (student.Name == studentsInDb.Name)
                {
                    Console.WriteLine($"Student {student.Name} is already in DB" +
                                      $"\nBack to main menu");
                    Root.Menu();
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
