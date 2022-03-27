using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Faculty
{
    internal class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Class { get; set; }
        public int NOOfGrades { get; set; }
        public ArrayList Grades { get; set; }
        public Student(string LastName, string FirstName, string Class, int NOOfGrades, ArrayList Grades)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Class = Class;
            this.NOOfGrades = NOOfGrades;
            this.Grades = Grades;
        }
        public override bool Equals(object other)
        {
            return this.LastName == ((Student)other).LastName;
        }
        public override int GetHashCode()
        {
            return this.LastName.GetHashCode();
        }
        public double CountAverage()
        {
            double sum = 0;
            foreach (int grade in Grades)
            {
                sum += grade;
            }
            return sum / NOOfGrades;
        }
        public double CompareTo(Student other)
        {
            double studentcomp = this.Class.CompareTo(other.Class);
            if (studentcomp == 0)
            {
                double result = other.CountAverage() - CountAverage();
                if (result == 0)
                {
                }
                return result;
            }
            return studentcomp;
        }
    }

}
