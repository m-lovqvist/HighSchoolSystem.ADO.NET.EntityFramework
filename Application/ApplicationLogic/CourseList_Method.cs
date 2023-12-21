using HighSchoolSystem.Data;
using HighSchoolSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolSystem.Application.ApplicationLogic
{
    public class CourseList_Method
    {
        private static string connectionString = "Data Source = DESKTOP-64QT8T3; DataBase = HighSchoolSystem; Trusted_connection = True; MultipleActiveResultSets = True; TrustServerCertificate=True";
        private string[] courseListMenuOptions = { "[1] Visa alla betyg som satts den senaste månaden\t\t", "[2] Tillbaka till huvudmenyn\t\t" };
        private int courseListMenuSelected = 0;

        public void CourseListMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("HighSchoolSystem");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("Styr pilen upp eller ner och tryck sedan på");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Enter");
                Console.ResetColor();
                Console.WriteLine("\x1b[?25l");

                for (int i = 0; i < courseListMenuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == courseListMenuSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(courseListMenuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(courseListMenuOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && courseListMenuSelected + 1 != courseListMenuOptions.Length)
                {
                    courseListMenuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && courseListMenuSelected != 0)
                {
                    courseListMenuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (courseListMenuSelected)
                    {
                        case 0:
                            ShowAllGradesLastMonth();
                            break;
                        case 2:
                            ReturnToMainMenu();
                            break;
                        default:
                            Console.WriteLine("Välj vad du vill göra");
                            break;
                    }

                    Console.CursorVisible = true;

                    break;
                }
            }
            ReturnToMainMenu();
        }

        public void ReturnToMainMenu()
        {
            new App().RunMenu();
        }

        public void ReturnToMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Tryck på Enter för att gå tillbaka till menyn");
            Console.ResetColor();
            Console.ReadKey(true);
            CourseListMenu();
        }

        public static void ShowAllGradesLastMonth()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT FirstName + ' ' + LastName AS 'Elev', CourseInfo AS 'Kurs', GradeInfo AS 'Betyg' FROM CourseLists\r\nJOIN Students ON StudentID = FKStudentID\r\nJOIN Courses ON CourseID = FKCourseID\r\nWHERE CourseLists.SetDate <= '2023-12-17' AND CourseLists.SetDate >='2023-11-17'", connection);

                    using (SqlDataReader grade = command.ExecuteReader())
                    {
                        while (grade.Read())
                        {
                            Console.WriteLine($"Elev: " + grade["Elev"] + " | Kurs: " + grade["Kurs"] + " | Betyg: " + grade["Betyg"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            new CourseList_Method().ReturnToMenu();
        }
    }
}
