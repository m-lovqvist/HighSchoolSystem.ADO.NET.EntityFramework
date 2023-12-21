using HighSchoolSystem.Application.ApplicationLogic;
using HighSchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolSystem.Application
{
    public class App
    {
        private string[] menuOptions = { "[1] Visa personal\t\t", "[2] Visa elever\t\t", "[3] Visa alla elever i en viss klass \t\t", "[4] Visa alla betyg från senaste månaden\t\t", "[5] Visa alla kurser\t\t", "[6] Lägg till ny elev\t\t", "[7] Lägg till ny personal\t\t" };
        private int menuSelected = 0;

        public void RunMenu()
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

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == menuSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(menuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(menuOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && menuSelected + 1 != menuOptions.Length)
                {
                    menuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && menuSelected != 0)
                {
                    menuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (menuSelected)
                    {
                        case 0:
                            ShowEmployees();
                            break;
                        case 1:
                            ShowAllStudentsMenu();
                            break;
                        case 2:
                            ShowAllStudentsInSpecificClass();
                            break;
                        case 3:
                            ShowAllGradesLastMonth();
                            break;
                        case 4:
                            ShowAllCourses();
                            break;
                        case 5:
                            AddNewStudent();
                            break;
                        case 6:
                            AddNewEmployee();
                            break;
                        default:
                            Console.WriteLine("Välj vad du vill göra");
                            break;
                    }

                    Console.CursorVisible = true;

                    break;
                }
            }
        }

        public void ShowEmployees()
        {
            new Employee_Method().ShowEmployees();
        }

        public void ShowAllStudentsMenu()
        {
            new Student_Method().ShowAllStudentsMenu();
        }

        public void ShowAllStudentsInSpecificClass()
        {
            new Class_Method().ShowAllStudentsInSpecificClass();
        }

        public void ShowAllGradesLastMonth()
        {
            CourseList_Method.ShowAllGradesLastMonth();
        }

        public void ShowAllCourses()
        {
            Course_Method.ShowAllCourses();
        }

        public void AddNewStudent()
        {
            Student_Method.AddNewStudent();
        }

        public void AddNewEmployee()
        {
            new Employee_Method().AddNewEmployee();
        }
    }
}
