using System;
using static Lev0.Models.Enum;

namespace Lev0.Models
{
    public class Student : Person
    {
        public string StudentCode { get; set; }
        public string School { get; set; }
        public int StartYear { get; set; }
        public double Gpa { get; set; }
        public AcademicPerformance AcademicPerformance { get; set; }

        public static AcademicPerformance UpdateAcademicPerformance(double Gpa)
        {
            if (Gpa < 3)
                return AcademicPerformance.Poor;
            if (Gpa < 5)
                return AcademicPerformance.Weak;
            if (Gpa < 6.5)
                return AcademicPerformance.Average;
            if (Gpa < 7.5)
                return AcademicPerformance.Good;
            if (Gpa < 9)
                return AcademicPerformance.Excellent;
            return AcademicPerformance.Excellent;
        }
        public Student()
        {

        }

        public Student(int id, string name, DateTime birthDay, string address, double? height, double? weight,
                        string studentCode, string school, int startYear, double gpa)
                       : base(id, name, birthDay, address, height, weight)
        {
            StudentCode = studentCode;
            School = school;
            StartYear = startYear;
            Gpa = gpa;
            AcademicPerformance = UpdateAcademicPerformance(gpa);
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                   $"CodeStudent={StudentCode}\n" +
                   $"School={School}\n" +
                   $"StartYear={StartYear}\n" +
                   $"GPA={Gpa}\n" +
                   $"AcademicPerforman={UpdateAcademicPerformance(Gpa)}";
        }
    }
}
