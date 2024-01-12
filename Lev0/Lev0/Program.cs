using Lev0.Controller;
using System;

namespace Lev0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------- ");
            Content list = new Content();
            while (true)
            {
                DisplayMenu();
                int key = int.Parse(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        list.AddStudent();
                        break;
                    case 2:
                        list.SearchStudentById();
                        break;
                    case 3:
                        list.UpdateById();
                        break;
                    case 4:
                        list.DeleteStudentById();
                        break;
                    case 5:
                        list.ShowByPercentage();
                        break;
                    case 6:
                        list.DisplayListOfStudentsByPercent();
                        break;
                    case 7:
                        list.DisplayListOfStudentsByAcademicPerformance();
                        break;
                    case 8:
                        list.SaveStudentsToFile();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid number from the menu.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("1. ADD STUDENT ");
            Console.WriteLine("2. Search Student for id");
            Console.WriteLine("3. Update for id ");
            Console.WriteLine("4. Delete for id ");
            Console.WriteLine("5. Show student ranking by GPA");
            Console.WriteLine("6. Show Student Display List Of Students By Percent ");
            Console.WriteLine("7. Display List Of Students By Academic Performance");
            Console.WriteLine("8. Save to file ");
            Console.WriteLine("9. Exit");
            Console.WriteLine("--------------------------------------");
        }
    }
}
