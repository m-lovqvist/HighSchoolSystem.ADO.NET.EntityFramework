using HighSchoolSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolSystem.Application.ApplicationLogic
{
    public class Class_Method
    {
        private string[] classMenuOptions = { "[1] Välj klass att visa\t\t", "[2] Tillbaka till huvudmenyn\t\t" };
        private int classMenuSelected = 0;

        private HighSchoolSystemContext Context { get; set; }
        public Class_Method()
        {
            Context = new();
        }

        public void ClassMenu()
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

                for (int i = 0; i < classMenuOptions.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (i == classMenuSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(classMenuOptions[i] + "<--");
                    }
                    else
                    {
                        Console.WriteLine(classMenuOptions[i]);
                    }
                    Console.ResetColor();
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                ConsoleKey keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.DownArrow && classMenuSelected + 1 != classMenuOptions.Length)
                {
                    classMenuSelected++;
                }
                else if (keyPressed == ConsoleKey.UpArrow && classMenuSelected != 0)
                {
                    classMenuSelected--;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (classMenuSelected)
                    {
                        case 0:
                            ShowAllStudentsInSpecificClass();
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
            ClassMenu();
        }

        public void ShowAllStudentsInSpecificClass()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Nedan följer en översikt över alla klasser:");
            Console.ResetColor();
            Context.Classes.ToList();
            {

                var classes = from c in Context.Classes
                              select c;

                foreach (var c in classes)
                {
                    Console.WriteLine($"Klass: {c.ClassName}");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Välj klasslista genom att skriva namnet på klassen du vill visa och avsluta med Enter");
                Console.ResetColor();
                string userInput = Console.ReadLine();

                if (userInput == "BP1")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 1)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "BP2")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 2)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "BP3")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 3)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "EK1")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 4)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "EK2")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 5)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "EK3")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 6)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "EP1")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 7)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "EP2")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 8)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "EP3")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 9)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "FT1")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 10)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "FT2")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 11)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "FT3")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 12)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "NV1")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 13)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "NV2")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 14)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "NV3")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 15)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "SV1")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 16)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "SV2")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 17)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "SV3")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 18)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "TK1")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 19)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "TK2")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 20)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else if (userInput == "TK3")
                {
                    var students = from s in Context.Students.Where(c => c.FkclassId == 21)
                                   select s;

                    foreach (var s in students)
                    {
                        Console.WriteLine($"Namn: {s.FirstName} {s.LastName} | Personnummer: {s.PersonalNumber} | Adress: {s.Address} | Postnummer: {s.Zip} | Elev-ID: {s.StudentId}");
                    }
                }
                else
                {
                    Console.WriteLine("Välj vilken klass du vill visa");
                }
            }
            ReturnToMenu();
        }
    }
}
