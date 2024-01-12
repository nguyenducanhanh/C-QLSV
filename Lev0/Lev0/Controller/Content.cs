using Lev0.Library;
using Lev0.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using static Lev0.Models.Enum;

namespace Lev0.Controller
{
    public class Content
    {
        List<Student> students = new List<Student>();
        Valid valid = new Valid();
        public void DisplayStudentInfo(Student student)
        {
            Console.WriteLine(student.ToString());
            Console.WriteLine("--------------------------");
        }

        public void DisplayStudents(List<Student> studentList)
        {
            Console.WriteLine("LIST:");
            foreach (Student student in studentList)
            {
                DisplayStudentInfo(student);
            }
        }

        public void AddStudent()
        {
            Console.WriteLine("Enter student in Validion:");
            Student newStudent = valid.GetStudent(students);
            try
            {
                students.Add(newStudent);
                Console.WriteLine("Student created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Failed to add the student to the list - {ex.Message}!");
            }
            DisplayStudents(students);
        }

        public void SearchStudentById()
        {
            var id = valid.InputId();
            Student student = students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                Console.WriteLine("does not exist!");
                return;
            }
            DisplayStudentInfo(student);
        }

        public void UpdateById()
        {
            var id = valid.InputId();
            Student studentUpdate = students.FirstOrDefault(x => x.Id == id);

            if (studentUpdate == null)
            {
                Console.WriteLine("Student does not exist!");
                return;
            }

            DisplayStudentInfo(studentUpdate);
            Console.WriteLine("Select the information you want to update:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Address");
            Console.WriteLine("3. School");
            Console.WriteLine("4. GPA");
            Console.WriteLine("5. Birth Day");
            Console.WriteLine("6. Start Year");
            Console.WriteLine("7. Height");
            Console.WriteLine("8. Weight");
            Console.WriteLine("9. Exit update");

            while (true)
            {
                Console.Write("Enter your choice: ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        studentUpdate.Name = Valid.GetUserInput("Enter new name: ", ValidLength.GetValidName);
                        break;
                    case 2:
                        studentUpdate.Address = Valid.GetUserInput("Enter new address: ", ValidLength.GetValidAddres);
                        break;
                    case 3:
                        studentUpdate.School = Valid.GetUserInput("Enter new school: ", ValidLength.ValidateSchool);
                        break;
                    case 4:
                        studentUpdate.Gpa = double.Parse(Valid.GetUserInput("Enter new GPA: ", ValidLength.ValidateGPA));
                        studentUpdate.AcademicPerformance = Student.UpdateAcademicPerformance(studentUpdate.Gpa);
                        break;
                    case 5:
                        studentUpdate.BirthDay = DateTime.ParseExact(Valid.GetUserInput("Enter new birth day (dd/MM/yyyy): ", ValidLength.ValidateBirthDay), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        break;
                    case 6:
                        studentUpdate.StartYear = int.Parse(Valid.GetUserInput("Enter new start year (yyyy): ", ValidLength.ValidateStartYear));
                        break;
                    case 7:
                        studentUpdate.Height = double.Parse(Valid.GetUserInput("Enter new height (cm): ", ValidLength.ValidateHeight));
                        break;
                    case 8:
                        studentUpdate.Weight = double.Parse(Valid.GetUserInput("Enter new weight (kg): ", ValidLength.ValidateWeight));
                        break;
                    case 9:
                        Console.WriteLine("Update completed.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                Console.WriteLine("Update successful!");
                DisplayStudentInfo(studentUpdate);
            }
        }


        public void DeleteStudentById()
        {          
                int id = valid.InputId();
                Student student = students.FirstOrDefault(x => x.Id == id);
                if (student != null)
                {
                    students.Remove(student);
                    Console.WriteLine("Student deleted successfully!");
                    DisplayStudents(students);
                }
                else
                {
                    Console.WriteLine("No student found with the provided ID.");
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                }           
        }
        public void ShowByPercentage()
        {
            int totalStudents = students.Count;
            Dictionary<AcademicPerformance, double> percentageDictionary = students
                .GroupBy(s => s.AcademicPerformance)
                .ToDictionary(
                    group => group.Key,
                    group => (group.Count() / (double)totalStudents) * 100
                );
            Console.WriteLine("% STUDENTS :");
            foreach (var kvp in percentageDictionary)
            {
                Console.WriteLine($"{kvp.Key,-10} : {students.Count(x => x.AcademicPerformance == kvp.Key)} ({kvp.Value.ToString("0")}%)");
            }
        }

        public void DisplayListOfStudentsByPercent()
        {
            var gpaGroups = students.GroupBy(student => student.Gpa)
                                    .Select(group => new { Gpa = group.Key, Count = group.Count() })
                                    .ToList();
            int totalStudents = students.Count;
            Console.WriteLine("DISPLAY GPA STUDENTS ");

            foreach (var group in gpaGroups)
            {
                double percentage = (group.Count / (double)totalStudents) * 100;
                Console.WriteLine($"\n{group.Gpa} : {percentage.ToString("0")}%");
            }

            Console.WriteLine("------------------------------------------");
        }

        public void DisplayListOfStudentsByAcademicPerformance()
        {
            int inputNumber;
            Console.WriteLine("Display Students By Input Academic Performance");
            Console.WriteLine("Enter the corresponding number for each rank:");
            Console.WriteLine("1 - Poor, 2 - Weak, 3 - Average, 4 - Good, 5 - Excellent");
            Dictionary<int, string> rankMappings = new Dictionary<int, string>
            { { 1, "Poor" },{ 2, "Weak" },{ 3, "Average" },{ 4, "Good" },{ 5, "Excellent" } };
            while (true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out inputNumber))
                {
                    if (rankMappings.ContainsKey(inputNumber))
                    {
                        break;
                    }
                }
                Console.WriteLine("Enter a valid number from 1 to 5:");
            }

            string input = rankMappings[inputNumber];

            List<Student> filteredStudents = students.Where(student => student.AcademicPerformance.ToString().Equals(input, StringComparison.OrdinalIgnoreCase)).ToList();

            if (filteredStudents.Count > 0)
            {
                Console.WriteLine($"\nList Academic Performance {input}:\n");
                foreach (Student student in filteredStudents)
                {
                    Console.WriteLine($"Id: {student.Id} - Name: {student.Name} - Student Code: {student.StudentCode} - GPA: {student.Gpa}");
                }
            }
            else
            {
                Console.WriteLine($"No students found with Academic Performance: {input}.");
            }
        }
        public void SaveStudentsToFile()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Student student in students)
            {
                sb.AppendLine(student.ToString());
                sb.AppendLine("--------------------------");
            }
            File.WriteAllText("students.txt", sb.ToString());
            Console.WriteLine("Students saved to file successfully.");
        }
    }
}
