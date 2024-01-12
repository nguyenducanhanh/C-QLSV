using Lev0.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lev0.Library
{
    public class Valid
    {
        public int InputId()
        {
            bool isInt = false;
            int value = 0;
            Console.Write("Enter student ID:");
            do
            {
                var id = Console.ReadLine();
                isInt = Int32.TryParse(id, out int result);
                if (!isInt)
                {
                    Console.WriteLine(" Input again ");
                }
                else { value = result; }
            } while (isInt);
            return value;
        }

        public static string GetUserInput(string prompt, Func<string, (bool Success, string Message)> validator)
        {
            string userInput;
            bool isFieldValid;
            do
            {
                isFieldValid = true;
                Console.Write(prompt);
                userInput = Console.ReadLine()?.Trim();
                var validationMessage = validator(userInput);
                if (!validationMessage.Success)
                {
                    Console.WriteLine(validationMessage.Message);
                    isFieldValid = false;
                }
            } while (!isFieldValid);
            return userInput;
        }
        public Student GetStudent(List<Student> students)
        {
            int id = students.Count > 0 ? students.Max(s => s.Id) + 1 : 1;
            string name = GetUserInput("Please enter name: ", ValidLength.GetValidName);
            string birthDay = GetUserInput("Please enter birth day  (dd/MM/yyyy): ", ValidLength.ValidateBirthDay);
            string address = GetUserInput("Please enter address: ", ValidLength.GetValidAddres);
            string height = GetUserInput("Please enter height (cm): ", ValidLength.ValidateHeight);
            string weight = GetUserInput("Please enter weight (kg):", ValidLength.ValidateWeight);
            string studentCode = GetUserInput("Please enter student code : ", (input) => ValidLength.ValidateStudentCode(input, students));
            string school = GetUserInput("Please enter school: ", ValidLength.ValidateSchool);
            string startYear = GetUserInput("Please enter start year univer  (yyyy): ", ValidLength.ValidateStartYear);
            string gpa = GetUserInput("Please enter GPA (double): ", ValidLength.ValidateGPA);
            return new Student(id, name, DateTime.ParseExact(birthDay, "dd/MM/yyyy", CultureInfo.InvariantCulture),
            address, double.Parse(height), double.Parse(weight), studentCode, school, int.Parse(startYear), double.Parse(gpa));
        }
    }
}