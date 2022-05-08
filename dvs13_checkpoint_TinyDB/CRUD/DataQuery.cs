using dvs13_TinyDB.DataAccess;
using dvs13_TinyDB.DataModels;
using dvs13_TinyDB.Functions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace dvs13_TinyDB.CRUD
{
    public class DataQuery
    {
        private readonly static Context db = new();
        public static Course CourseSelector()
        {
            var index = 1;
            db.Courses.Include(x => x.StudentList)
                      .Include(x => x.LectureList)
                                                  .Select(x => x.Name).ToList()
                                                  .ForEach(x => Console.WriteLine($"{index++} - {x}"));

            var indexLimiter = db.Courses.Select(x => x.Name)
                                         .ToList()
                                         .Count();

            Console.WriteLine("Select a *Course*:");

            var selectedCourse = db.Courses.Include(x => x.StudentList)
                                           .Include(x => x.LectureList)
                                           .SingleOrDefault(x => x.ID == InputValidation.IntInputValidation(indexLimiter));

            Console.WriteLine($"Course: #{selectedCourse.ID} - {selectedCourse.Name} selected");
            return selectedCourse;
        }

        public static Lecture LectureSelector()
        {
            var index = 1;
            db.Lectures.Include(x => x.StudentList)
                       .Include(x => x.CourseList)
                                                  .Select(x => x.Name)
                                                  .ToList()
                                                  .ForEach(x => Console.WriteLine($"{index++} - {x}"));

            var indexLimiter = db.Lectures.Select(x => x.Name)
                                          .ToList()
                                          .Count();

            Console.WriteLine("Select a *Lecture*:");
            var selectedLecture = db.Lectures.Include(x => x.StudentList)
                                             .Include(x => x.CourseList)
                                             .SingleOrDefault(x => x.ID == InputValidation.IntInputValidation(indexLimiter));

            Console.WriteLine($"Lecture: {selectedLecture.Name} selected");
            return selectedLecture;
        }
        public static Student StudentSelector()
        {
            var index = 1;
            db.Students.Include(x => x.Course)
                       .Include(x => x.LectureList)
                                                  .Select(x => x.Name)
                                                  .ToList()
                                                  .ForEach(x => Console.WriteLine($"{index++} - {x}"));

            var indexLimiter = db.Students.Select(x => x.Name)
                                          .ToList()
                                          .Count();

            Console.WriteLine("Select a *Student*:");
            var selectedStudent = db.Students.Include(x => x.Course)
                                             .Include(x => x.LectureList)
                                             .SingleOrDefault(x => x.ID == InputValidation.IntInputValidation(indexLimiter));
            Console.WriteLine($"Student: {selectedStudent.Name} selected");
            return selectedStudent;
        }
    }
}
