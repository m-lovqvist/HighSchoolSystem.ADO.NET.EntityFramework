using HighSchoolSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolSystem.Application.ApplicationLogic
{
    public class Course_Method
    {
        private static string connectionString = "Data Source = DESKTOP-64QT8T3; DataBase = HighSchoolSystem; Trusted_connection = True; MultipleActiveResultSets = True; TrustServerCertificate=True";
        private string[] courseMenuOptions = { "[1] Visa alla kurser\t\t", "[2] Tillbaka till huvudmenyn\t\t" };
        private int courseMenuSelected = 0;

        public void CourseMenu()
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

                for (int i = 0; i < courseMenuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == courseMenuSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(courseMenuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(courseMenuOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && courseMenuSelected + 1 != courseMenuOptions.Length)
                {
                    courseMenuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && courseMenuSelected != 0)
                {
                    courseMenuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (courseMenuSelected)
                    {
                        case 0:
                            ShowAllCourses();
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
            CourseMenu();
        }

        public static void ShowAllCourses()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT CourseInfo AS 'Kurs', AVG(CAST(GradeInfo AS FLOAT)) AS 'Snittbetyg', MAX(CAST(GradeInfo AS FLOAT)) AS 'Högsta betyg', MIN(CAST(GradeInfo AS FLOAT)) AS 'Lägsta betyg' FROM COURSELISTS\r\nJOIN Courses ON CourseID = FKCourseID\r\nGROUP BY CourseInfo", connection);

                    using (SqlDataReader course = command.ExecuteReader())
                    {
                        while (course.Read())
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10}", "Kurs: ", course["Kurs"], " | ", "Snittbetyg: ", course["Snittbetyg"], " | ", "Högsta betyg: ", course["Högsta betyg"], " | ", "Lägsta betyg: ", course["Lägsta betyg"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            new Course_Method().ReturnToMenu();
        }
    }
}
