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
    public class Employee_Method
    {
        private static string connectionString = "Data Source = DESKTOP-64QT8T3; DataBase = HighSchoolSystem; Trusted_connection = True; MultipleActiveResultSets = True; TrustServerCertificate=True";
        private string[] employeeMenuOptions = { "[1] Visa all personal\t\t", "[2] Visa alla rektorer\t\t", "[3] Visa alla administratörer \t\t", "[4] Visa alla lärare\t\t", "[5] Visa alla skolsköterskor\t\t", "[6] Visa alla städare \t\t", "[7] Visa alla vaktmästare\t\t", "[8] Tillbaka till huvudmenyn\t\t" };
        private int employeeMenuSelected = 0;

        private HighSchoolSystemContext Context { get; set; }
        public Employee_Method()
        {
            Context = new();
        }
        public void ShowEmployees()
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

                for (int i = 0; i < employeeMenuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == employeeMenuSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(employeeMenuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(employeeMenuOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && employeeMenuSelected + 1 != employeeMenuOptions.Length)
                {
                    employeeMenuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && employeeMenuSelected != 0)
                {
                    employeeMenuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (employeeMenuSelected)
                    {
                        case 0:
                            ShowAllEmployees();
                            break;
                        case 1:
                            ShowAllPrincipals();
                            break;
                        case 2:
                            ShowAllAdmins();
                            break;
                        case 3:
                            ShowAllTeachers();
                            break;
                        case 4:
                            ShowAllSchoolNurses();
                            break;
                        case 5:
                            ShowAllCleaners();
                            break;
                        case 6:
                            ShowAllJanitors();
                            break;
                        case 7:
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
            ReturnToMenu();
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
            ShowEmployees();
        }

        public static void ShowAllEmployees()
        {
            Console.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Employees", connection);

                    using (SqlDataReader employee = command.ExecuteReader())
                    {
                        while (employee.Read())
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14} {15} {16}", 
                                "ID: ", employee["EmployeeId"], " | Namn: ", employee["FirstName"], employee["LastName"], 
                                " | Titel: ", employee["Title"], " | Anställningsdatum: ", employee["HireDate"], " | Födelsedatum: ", employee["Birthdate"], 
                                " | Adress: ", employee["Address"], " | Postnummer: ", employee["Zip"], " | Befattnings-ID:", employee["FKprofessionId"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ShowAllPrincipals()
        {
            Console.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Employees\r\nWHERE Employees.FKProfessionID = '1'", connection);

                    using (SqlDataReader employee = command.ExecuteReader())
                    {
                        while (employee.Read())
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}",
                                "ID: ", employee["EmployeeId"], " | Namn: ", employee["FirstName"], employee["LastName"],
                                " | Titel: ", employee["Title"], " | Anställningsdatum: ", employee["HireDate"], " | Födelsedatum: ", employee["Birthdate"],
                                " | Adress: ", employee["Address"], " | Postnummer: ", employee["Zip"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public static void ShowAllAdmins()
        {
            Console.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Employees\r\nWHERE Employees.FKProfessionID = '2'", connection);

                    using (SqlDataReader employee = command.ExecuteReader())
                    {
                        while (employee.Read())
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}",
                                "ID: ", employee["EmployeeId"], " | Namn: ", employee["FirstName"], employee["LastName"],
                                " | Titel: ", employee["Title"], " | Anställningsdatum: ", employee["HireDate"], " | Födelsedatum: ", employee["Birthdate"],
                                " | Adress: ", employee["Address"], " | Postnummer: ", employee["Zip"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ShowAllTeachers()
        {
            Console.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Employees\r\nWHERE Employees.FKProfessionID = '3'", connection);

                    using (SqlDataReader employee = command.ExecuteReader())
                    {
                        while (employee.Read())
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}",
                                "ID: ", employee["EmployeeId"], " | Namn: ", employee["FirstName"], employee["LastName"],
                                " | Titel: ", employee["Title"], " | Anställningsdatum: ", employee["HireDate"], " | Födelsedatum: ", employee["Birthdate"],
                                " | Adress: ", employee["Address"], " | Postnummer: ", employee["Zip"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ShowAllSchoolNurses()
        {
            Console.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Employees\r\nWHERE Employees.FKProfessionID = '4'", connection);

                    using (SqlDataReader employee = command.ExecuteReader())
                    {
                        while (employee.Read())
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}",
                                "ID: ", employee["EmployeeId"], " | Namn: ", employee["FirstName"], employee["LastName"],
                                " | Titel: ", employee["Title"], " | Anställningsdatum: ", employee["HireDate"], " | Födelsedatum: ", employee["Birthdate"],
                                " | Adress: ", employee["Address"], " | Postnummer: ", employee["Zip"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ShowAllCleaners()
        {
            Console.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Employees\r\nWHERE Employees.FKProfessionID = '5'", connection);

                    using (SqlDataReader employee = command.ExecuteReader())
                    {
                        while (employee.Read())
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}",
                                "ID: ", employee["EmployeeId"], " | Namn: ", employee["FirstName"], employee["LastName"],
                                " | Titel: ", employee["Title"], " | Anställningsdatum: ", employee["HireDate"], " | Födelsedatum: ", employee["Birthdate"],
                                " | Adress: ", employee["Address"], " | Postnummer: ", employee["Zip"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ShowAllJanitors()
        {
            Console.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Employees\r\nWHERE Employees.FKProfessionID = '6'", connection);

                    using (SqlDataReader employee = command.ExecuteReader())
                    {
                        while (employee.Read())
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12} {13} {14}",
                                "ID: ", employee["EmployeeId"], " | Namn: ", employee["FirstName"], employee["LastName"],
                                " | Titel: ", employee["Title"], " | Anställningsdatum: ", employee["HireDate"], " | Födelsedatum: ", employee["Birthdate"],
                                " | Adress: ", employee["Address"], " | Postnummer: ", employee["Zip"]);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public void AddNewEmployee()
        {
            {
                Console.Clear();
                Console.WriteLine("Ange Anställnings-ID:");
                string empId = Console.ReadLine();
                int employeeId = Int32.Parse(empId);
                Console.WriteLine("Ange förnamn:");
                string firstName = Console.ReadLine();
                Console.WriteLine("Ange efternamn");
                string lastName = Console.ReadLine();
                Console.WriteLine("Ange titel (mr, ms, mrs):");
                string title = Console.ReadLine();
                Console.WriteLine("Ange anställningsdatum (YYYY-MM-DD:");
                string hDate = Console.ReadLine();
                DateTime hireDate = DateTime.Parse(hDate);
                Console.WriteLine("Ange födelsedatum (YYYY-MM-DD):");
                string bDate = Console.ReadLine();
                DateTime birthDate = DateTime.Parse(bDate);
                Console.WriteLine("Ange adress:");
                string address = Console.ReadLine();
                Console.WriteLine("Ange postnummer:");
                string zip = Console.ReadLine();
                Console.WriteLine("Ange befattnings-ID:");
                string fkProfId = Console.ReadLine();
                int fkProfessionId = Int32.Parse(fkProfId);
                Console.Clear();

                var newEmployee = new Employee
                {
                    EmployeeId = employeeId,
                    FirstName = firstName,
                    LastName = lastName,
                    Title = title,
                    HireDate = hireDate,
                    BirthDate = birthDate,
                    Address = address,
                    Zip = zip,
                    FkprofessionId = fkProfessionId
                };
                Context.Employees.Add(newEmployee);

                Console.WriteLine("Ny anställd har lagts till i databasen");

                Context.SaveChanges();
                ReturnToMainMenu();
            }
        }
    }
}
