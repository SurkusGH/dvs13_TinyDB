using dvs13_TinyDB.DataAccess;
using dvs13_TinyDB.DataModels;
using dvs13_TinyDB.Functions;
using System;
using System.Collections.Generic;

namespace dvs13_TinyDB.Helpers
{
    public class DummyData
    {
        private readonly static Context db = new();
        
        public static void Inject()
        {
            #region CourseDescription

            Course course1 = new();
            course1.Name = "Programavimas";
            Course course2 = new();
            course2.Name = "Teisė";
            Course course3 = new();
            course3.Name = "Vadyba";

            db.AddRange(course1, course2, course3);
            db.SaveChanges();

            #endregion LectureDescription; Relatioship injection

            #region LecturesDescription, RelationshipInjection

            Lecture lecture1 = new(); lecture1.Name = "C#" ;
            Lecture lecture2 = new(); lecture2.Name = "Java";
            Lecture lecture3 = new(); lecture3.Name = "Python";
            Lecture lecture4 = new(); lecture4.Name = "PHP";
            List<Lecture> lectureList1 = new List<Lecture>();
                                                             lectureList1.Add(lecture1);
                                                             lectureList1.Add(lecture2);
                                                             lectureList1.Add(lecture3);
                                                             lectureList1.Add(lecture4);
            course1.LectureList = lectureList1;

            Lecture lecture5 = new(); lecture5.Name = "Civilinė teisė";
            Lecture lecture6 = new(); lecture6.Name = "Darbo teisė";
            Lecture lecture7 = new(); lecture7.Name = "Baudžiamoji teisė";
            Lecture lecture8 = new(); lecture8.Name = "Konstitucinė teisė";
            List<Lecture> lectureList2 = new List<Lecture>();
                                                             lectureList2.Add(lecture5);
                                                             lectureList2.Add(lecture6);
                                                             lectureList2.Add(lecture7);
                                                             lectureList2.Add(lecture8);
            course2.LectureList = lectureList2;

            Lecture lecture9 = new(); lecture9.Name = "Ekonomika 101";
            Lecture lecture10 = new(); lecture10.Name = "Mikroekonomika";
            Lecture lecture11 = new(); lecture11.Name = "Makroekonomika";
            Lecture lecture12 = new(); lecture12.Name = "Marketingas";
            List<Lecture> lectureList3 = new List<Lecture>();
                                                             lectureList3.Add(lecture9);
                                                             lectureList3.Add(lecture10);
                                                             lectureList3.Add(lecture11);
                                                             lectureList3.Add(lecture12);
            course3.LectureList = lectureList3;

            #endregion

            #region StudentsDescription, RelationshipInjection

            Student student1 = new();
                    student1.Name = "Antanas Antanaitis";
                    student1.Course = course1;
                    student1.LectureList.AddRange(lectureList1);

            Student student2 = new();
                    student2.Name = "Jonas Jonaitis";
                    student2.Course = course2;
                    student2.LectureList.AddRange(lectureList2);

            Student student3 = new();
                    student3.Name = "Juozas Juozaitis";
                    student3.Course = course3;
                    student3.LectureList.AddRange(lectureList3);

            Student student4 = new();
                    student4.Name = "Petras Petraitis";
                    student4.Course = course3;
                    student4.LectureList.AddRange(lectureList3);

            #endregion

            db.AddRange(student1, student2, student3, student4);
            db.SaveChanges();

            Console.WriteLine("Dummy Data Injected:");
            DataReading.AllDataQuery();
        }
    }
}
