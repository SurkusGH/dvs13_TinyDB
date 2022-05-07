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
            Console.WriteLine($"Functions:" +
                              $"\n [1] to create a *COURSE* + *STUDENT* + *LECTURES*" +
                              $"\n [2] to add *STUDENT* + *LECTURES* to existing *COURSE*" +
                              $"\n [3] to add *LECTURES* to existing *COURSE*" +
                              $"\n [4] to existing *COURSE* add *STUDENT* + *LECTURES* from DB" +
                              $"\n [5] to transfer *STUDENT* to other *COURSE*" +
                              $"\n\nDepict DB Data:" +
                              $"\n [6] PRINT courses w/ asociated students" +
                              $"\n [7] PRINT courses w/ asociated lectures" +
                              $"\n [8] PRINT lecture w/ asociated students" +
                              $"\n [9] to PRINT *all* data" +
                              $"\n[10] Enviroment.Exit()");

            switch (InputValidationHelper.IntInputValidation(10))
            {
                case 1:
                    DataCreation.AddCourse();
                    Menu();
                    break;
                case 2:
                    DataCreation.ToExistingCourse_Add_StudentLectures();
                    Menu();
                    break;
                case 3:
                    DataCreation.ToExistingCourse_Add_Lectures();
                    Menu();
                    break;
                case 4:
                    DataCreation.ToExistingCourse_Add_CreatedStudent_AddExistingLectures();
                    Menu();
                    break;
                case 5:
                    //Missing function;
                    Menu();
                    break;
                case 6:
                    DataReading.QueryStudentsByCourse();
                    Menu();
                    break;
                case 7:
                    DataReading.QueryLecturesByCourse();
                    Menu();
                    break;
                case 8:
                    DataReading.QueryLecturesByStudent();
                    Menu();
                    break;
                case 9:
                    DataReading.Dev_QueryCourses();
                    Menu();
                    break;
                case 10:
                    Environment.Exit(1);
                    break;
            }
        }
    }
}
