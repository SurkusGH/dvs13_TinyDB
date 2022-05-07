using dvs13_TinyDB.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvs13_TinyDB
{
    public class Root
    {
        public static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine($"\nFunctions:" +
                              $"\n\n [1] -> create a *COURSE* + *STUDENT* + *LECTURES*" +
                              $"\n                  (!)new     (!)new      (!)new" +
                              $"\n\n [2] -> add *STUDENT* + *LECTURES* to *COURSE*" +
                              $"\n             (!)new       (!)new      (!)in_DB" +
                              $"\n\n [3] -> add *LECTURES* to *COURSE*" +
                              $"\n              (!)new     (!)in_DB" +
                              $"\n\n [4] -> *COURSE* + *STUDENT* + *LECTURES*" +
                              $"\n        (!)in_DB    (!)new     (!)in_DB" +
                              $"\n\n [5] -> transfer *STUDENT* to another *COURSE*" +
                              $"\n                 (!)in_DB             (!)in_DB" +
                              $"\n\n\nDB Data Depictiom:" +
                              $"\n [6] -> print *COURSES* w/ all asociated *STUDENTS*" +
                              $"\n [7] -> print *COURSES* w/ all asociated *LECTURES*" +
                              $"\n [8] -> PRINT *LECTURE* w/ all asociated *STUDENTS*" +
                              $"\n [9] -> print all *DATA*" +
                              $"\n[10] <- Enviroment.Exit()");

            switch (InputValidationHelper.IntInputValidation(10))
            {
                case 0:
                    DataCreation.AddCourse();
                    Menu();
                    break;
                case 1:
                    DataCreation.ToExistingCourse_Add_StudentLectures();
                    Menu();
                    break;
                case 2:
                    DataCreation.ToExistingCourse_Add_Lectures();
                    Menu();
                    break;
                case 3:
                    DataCreation.ToExistingCourse_Add_CreatedStudent_AddExistingLectures();
                    Menu();
                    break;
                case 4:
                    DataCreation.Change_ExistingStudents_CourseAlociation();
                    Menu();
                    break;
                case 5:
                    DataReading.QueryStudentsByCourse();
                    Menu();
                    break;
                case 6:
                    DataReading.QueryLecturesByCourse();
                    Menu();
                    break;
                case 7:
                    DataReading.QueryLecturesByStudent();
                    Menu();
                    break;
                case 8:
                    DataReading.Dev_QueryCourses();
                    Menu();
                    break;
                case 9:
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
