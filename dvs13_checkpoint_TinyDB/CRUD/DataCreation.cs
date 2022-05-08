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

            Console.WriteLine($"Add *More* lectures? y/n");
            var input = InputValidation.CharInputValidation();

            while (input == "y")
            {
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

            Console.WriteLine($"Add *More* lectures? y/n");
            var input = InputValidation.CharInputValidation();

            while (input == "y")
            {
                targetCourse.LectureList.Add(AddLecture(targetCourse));
                Console.WriteLine($"Add *More* lectures? y/n");
                input = InputValidation.CharInputValidation();
            }

            db.Update(targetCourse);
            db.SaveChanges();

            Root.Menu();
        }
        #endregion

        #region (2.4)
        // (2.4) Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam
        //       egzistuojančias paskaitas;
        public static void ToExistingCourse_Add_CreatedStudent_AddExistingLectures()
        {
            int index = 1;
            var indexLimiter = db.Courses.Select(x => x.Name).ToList().Count();

            Console.WriteLine("Existing Courses");
            db.Courses.Select(x => x.Name).ToList().ForEach(x => Console.WriteLine($"{index++} - {x}"));
            
            Console.WriteLine("Select to which *Course* to add to:");
            var targetCourse = db.Courses.SingleOrDefault(x => x.ID == InputValidation.IntInputValidation(indexLimiter));

            Console.WriteLine($"Course: #{targetCourse.ID} - {targetCourse.Name} selected");
            targetCourse.StudentList.Add(AddStudent_LecturesFromList(targetCourse));

            db.Update(targetCourse);
            db.SaveChanges();
        }

        public static Student AddStudent_LecturesFromList(Course course)
        {
            Student student = new();

            Console.WriteLine($"Declare *Student* name");
            student.Name = Console.ReadLine();
            DublicationCatcher.CheckStudents(student);

            student.Course = course;
            student.LectureList.Add(AddLectureFromList(course));

            Console.WriteLine($"Add *More* lectures? y/n");
            var input = InputValidation.CharInputValidation();

            while (input == "y")
            {
                student.LectureList.Add(AddLectureFromList(course));
                Console.WriteLine($"Add *More* lectures? y/n");
                input = InputValidation.CharInputValidation();
            }
            return student;
        }

        public static Lecture AddLectureFromList(Course course)
        {
            int index = 1;

            var queryedLectures = db.Lectures.Include(x => x.CourseList).Where(x => x.CourseList.Contains(course)).ToList();
            var indexLimiter = queryedLectures.Count();

            Console.WriteLine("Select which Lecture to add:");
            foreach (var lecture in queryedLectures) {Console.WriteLine($"{index++} - {lecture.Name}");}

            var userSelection = InputValidation.IntInputValidation(indexLimiter+1);
            var selectedLecture = queryedLectures[userSelection-1];

            return selectedLecture;
        }

        #endregion

        #region (2.5)
        public static void Change_ExistingStudents_CourseAlociation()
        {
            
            int index = 1;
            var allStudents = db.Students.Include(x => x.Course).Include(x => x.LectureList).ToList();
            var indexLimiter = allStudents.Count();

            Console.WriteLine("Existing Students and their course allocation:");
            foreach (var student in allStudents){Console.WriteLine($"index:{index++} - {student.Name} - course: {student.Course.Name} ");}

            Console.WriteLine("Select a student to move a course:");
            var selectedStudent = allStudents[InputValidation.IntInputValidation(indexLimiter)-1];

            Console.WriteLine($"Select a new course for a student {selectedStudent.Name}:");
            index = 1;

            db.Courses.Select(x => x.Name).ToList().ForEach(x => Console.WriteLine($"{index++} - {x}"));
            var indexLimiter2 = db.Courses.Select(x => x.Name).ToList().Count();
            var selectedtCourse = db.Courses.Include(x => x.LectureList).SingleOrDefault(x => x.ID == (InputValidation.IntInputValidation(indexLimiter2)));

            Console.WriteLine($"Student {selectedStudent.Name} is moved to {selectedtCourse.Name}");

            selectedStudent.Course = selectedtCourse;
            selectedStudent.LectureList.Clear();
            selectedStudent.LectureList = selectedtCourse.LectureList;

            Console.WriteLine($"Lectures are now changed to {selectedtCourse.Name} course's lectures:");
            DataReading.QueryLecturesByStudent(selectedStudent);

            db.Update(selectedStudent);
            db.SaveChanges();
        }
        #endregion
    }
}
