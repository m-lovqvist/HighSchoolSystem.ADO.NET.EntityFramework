using HighSchoolSystem.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolSystem.Application.ApplicationLogic
{
    public class Student_Method
    {
        private static string connectionString = "Data Source = DESKTOP-64QT8T3; DataBase = HighSchoolSystem; Trusted_connection = True; MultipleActiveResultSets = True; TrustServerCertificate=True";
        private string[] studentMenuOptions = { "[1] Sortera alla elever efter förnamn\t\t", "[2] Sortera alla elever efter efternamn\t\t", "[3] Stigande sortering \t\t", "[4] Fallande sortering\t\t", "[5] Tillbaka till huvudmenyn\t\t" };
        private int studentMenuSelected = 0;

        private HighSchoolSystemContext Context { get; set; }
        public Student_Method()
        {
            Context = new();
        }

        public void ShowAllStudentsMenu()
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

                for (int i = 0; i < studentMenuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == studentMenuSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(studentMenuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(studentMenuOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && studentMenuSelected + 1 != studentMenuOptions.Length)
                {
                    studentMenuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && studentMenuSelected != 0)
                {
                    studentMenuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (studentMenuSelected)
                    {
                        case 0:
                            SortByFirstName();
                            break;
                        case 1:
                            SortByLastName();
                            break;
                        case 2:
                            AscendingSorting();
                            break;
                        case 3:
                            DescendingSorting();
                            break;
                        case 4:
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
            ShowAllStudentsMenu();
        }

        public static void AddNewStudent()
        {
            Console.Clear();
            Console.WriteLine("Ange Elev-ID:");
            string studentId = Console.ReadLine();
            Console.WriteLine("Ange förnamn:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Ange efternamn:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Ange personnummer (YYYYMMDD-XXXX:");
            string personalNumber = Console.ReadLine();
            Console.WriteLine("Ange adress:");
            string address = Console.ReadLine();
            Console.WriteLine("Ange postnummer:");
            string zip = Console.ReadLine();
            Console.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Students (StudentID, FirstNameName, LastName, PersonalNumber, Address, Zip) VALUES (@StudentID, @FirstName, @LastName, @PersonalNumber, @Address, @Zip)";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@PersonalNumber", personalNumber);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Zip", zip);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result < 1)
                    {
                        Console.WriteLine("Fel inmatning");
                    }
                    else
                    {
                        Console.WriteLine("Ny elev har lagts till i databasen");
                    }
                }
            }
        }

        public void SortByFirstName()
        {
            Context.Students.ToList();
            using (var context = new HighSchoolSystemContext())
            {
                var students = from s in context.Students.OrderBy(s => s.FirstName)
                               select s;

                foreach (var s in students)
                {
                    Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                }

            }
        }

        public void SortByLastName()
        {
            Context.Students.ToList();
            using (var context = new HighSchoolSystemContext())
            {
                var students = from s in context.Students.OrderBy(s => s.LastName)
                               select s;

                foreach (var s in students)
                {
                    Console.WriteLine($"Namn: {s.LastName} {s.FirstName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                }

            }
        }

        public void AscendingSorting()
        {
            Context.Students.ToList();
            using (var context = new HighSchoolSystemContext())
            {
                var students = from s in context.Students
                               orderby s.StudentId ascending
                               select s;

                foreach (var s in students)
                {
                    Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                }

            }
        }

        public void DescendingSorting()
        {
            Context.Students.ToList();
            using (var context = new HighSchoolSystemContext())
            {
                var students = from s in context.Students
                               orderby s.StudentId descending
                               select s;

                foreach (var s in students)
                {
                    Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                }

            }
        }
    }
}
