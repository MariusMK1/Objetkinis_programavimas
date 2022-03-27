using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Collections;

namespace Faculty
{
    internal class InOutUtils
    {
        public static StudentContainer ReadStudents(string fileName)
        {
            StudentContainer Students = new StudentContainer();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);
                string line;
                line = reader.ReadLine();
                string FacultyName = line;
                Students.FacultyName = FacultyName;
                while (null != (line = reader.ReadLine()))
                {
                    ArrayList Grades = new ArrayList();
                    string[] Values = line.Split(';');
                    string LastName = Values[0];
                    string FirstName = Values[1];
                    string Class = Values[2];
                    int NOOfGrades = int.Parse(Values[3]);
                    string[] lines2 = Values[4].Trim().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    Grades.Clear();
                    foreach (string line2 in lines2)
                    {
                        int aa = int.Parse(line2);
                        Grades.Add(aa);
                    }
                        Student student = new Student(LastName, FirstName, Class, NOOfGrades, Grades);
                    if (!Students.Contains(student))
                    {
                        Students.Add(student);
                    }
                }
            }
            return Students;
        }
        public static void PrintStudents(StudentContainer Students)
        {
            Console.WriteLine(new string('-', 73));
            Console.WriteLine("| {0,-69} |", Students.FacultyName);
            Console.WriteLine(new string('-', 73));
            Console.WriteLine("| {0,-9} | {1,-6} | {2,-5} | {3,-10} |     {4,-12} | {5,-8} |", "Pavardė", "Vardas", "Grupė", "Pažymių sk", "Pažymiai", "Vidurkis");
            Console.WriteLine(new string('-', 73));
            for (int i = 0; i < Students.Count; i++)
            {
                Student student = Students.Get(i);
                Console.Write("| {0,-9} | {1,-6} | {2,-5} | {3,5}      |", student.LastName, student.FirstName, student.Class, student.NOOfGrades);
                foreach(int grade in student.Grades)
                {
                    Console.Write("{0,3:d}", grade);
                }
                Console.Write("|");
                Console.WriteLine("   {0,-6:f2} |", student.CountAverage());
            }
            Console.WriteLine(new string('-', 73));
        }
    }
}
