using dvs13_checkpoint_TinyDB.DataAccess;
using dvs13_checkpoint_TinyDB.DataModels;
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
        public static Lecture AddLecture(Course course)
        {
            Lecture lecture = new();

            Console.WriteLine($"Declare *Lecture* name");
            var lectureName = Console.ReadLine();

            lecture.Name = lectureName;
            lecture.CourseList.Add(course);

            return lecture;
        }


        public static void AddToExistingCourse()
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

        public static void AddLectureToExistingCourse()
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
    }
}
