using Lev0.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Lev0.Library
{
    public static class ValidLength
    {
        public const int MaxNameLength = 100;
        public const int MaxGPA = 10;
        public const int MinGPA = 0;
        public const int MinYEAR = 1900;
        public const int MaxAddressLength = 300;
        public const int MinHeight = 50;
        public const int MaxHeight = 300;
        public const int MinWeight = 10;
        public const int MaxWeight = 100;
        public const int StudentCodeLength = 10;
        public const int MaxSchoolLength = 4;

        public static (bool Success, string Message) GetValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return (false, "Name is not null or empty!");
            }
            if (name.Length > MaxNameLength)
            {
                return (false, $"Name must be less than {MaxNameLength} characters!");
            }
            return (true, string.Empty);
        }

        public static (bool Success, string Message) ValidateBirthDay(string date)
        {
            DateTime convertDate;
            if (string.IsNullOrEmpty(date))
            {
                return (false, "DayOfBirth is not null or empty!");
            }
            if (!DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out convertDate))
            {
                return (false, "Enter the date in the format dd/MM/yyyy.");
            }
            if (convertDate.Year < MinYEAR)
            {
                return (false, $"Year must be greater than {MinYEAR}!");
            }
            return (true, string.Empty);
        }


        public static (bool Success, string Message) GetValidAddres(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return (true, string.Empty);
            }
            if (address.Length > MaxAddressLength)
            {
                return (false, $"Address must be less than {MaxAddressLength} characters!");
            }
            return (true, string.Empty);
        }

        public static (bool Success, string Message) ValidateHeight(string height)
        {
            double check;
            if (!double.TryParse(height, out check))
            {
                return (false, "Incorrect input format!");
            }
            if (check < MinHeight || check > MaxHeight)
            {
                return (false, $"Height must be between {MinHeight} and {MaxHeight}!");
            }
            return (true, string.Empty);
        }

        public static (bool Success, string Message) ValidateWeight(string weight)
        {
            double convertWeight;
            if (!double.TryParse(weight, out convertWeight))
            {
                return (false, "Incorrect input format!");
            }
            if (convertWeight < MinWeight || convertWeight > MaxWeight)
            {
                return (false, $"Weight must be between {MinWeight} and {MaxWeight}!");
            }
            return (true, string.Empty);
        }

        public static (bool Success, string Message) ValidateStudentCode(string studentCode, List<Student> students)
        {
            if (string.IsNullOrEmpty(studentCode))
            {
                return (false, "Student code is not null or empty!");
            }
            if (studentCode.Contains(" "))
            {
                return (false, "Student code cannot contain spaces!");
            }
            if (studentCode.Length != StudentCodeLength)
            {
                return (false, $"Student code must have {StudentCodeLength} characters!");
            }
            if (students.Any(student => student != null && student.StudentCode == studentCode))
            {
                return (false, "Student cpde already exists");
            }
            return (true, string.Empty);
        }

        public static (bool Success, string Message) ValidateSchool(string school)
        {
            if (string.IsNullOrEmpty(school))
            {
                return (false, "School is not null or empty!");
            }
            if (school.Length > MaxSchoolLength)
            {
                return (false, $"School must be less than {MaxSchoolLength} characters!");
            }
            return (true, string.Empty);
        }

        public static (bool Success, string Message) ValidateStartYear(string year)
        {
            int convertYear;
            if (string.IsNullOrEmpty(year))
            {
                return (false, "Year is not null or empty!");
            }
            if (!int.TryParse(year, out convertYear))
            {
                return (false, "Incorrect input format!");
            }
            if (convertYear < MinYEAR || year.Length != 4)
            {
                return (false, $"Year must be a valid 4-digit number from {MinYEAR} onwards!");
            }
            return (true, string.Empty);
        }

        public static (bool Success, string Message) ValidateGPA(string gpa)
        {
            double convertGpa;
            if (string.IsNullOrEmpty(gpa))
            {
                return (false, "GPA is not null or empty!");
            }
            if (!double.TryParse(gpa, out convertGpa))
            {
                return (false, "Incorrect input format!");
            }
            if (convertGpa < MinGPA || convertGpa > MaxGPA)
            {
                return (false, $"GPA must be between {MinGPA} and {MaxGPA}!");
            }
            return (true, string.Empty);
        }

        public static (bool Success, string Message) ValidateAcademicPerformance(string academicPerformance)
        {
            if (string.IsNullOrEmpty(academicPerformance))
            {
                return (false, "AcademicPerformance is not null or empty!");
            }
            return (true, string.Empty);
        }
    }
}
