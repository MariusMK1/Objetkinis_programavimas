using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Muziejai
{
    internal class InOutUtils
    {
        public static List<Museum> ReadMuseums(string fileName)
        {
            List<Museum> Museums = new List<Museum>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string name = Values[0];
                string city = Values[1];
                string type = Values[2];
                List<int> week = new List<int>();
                for (int i = 3; i < 10; i++)
                {
                    int day = int.Parse(Values[i]);
                    week.Add(day);
                }
                double price = double.Parse(Values[10]);
                string guide = Values[11];
                Museum museum = new Museum(name, city, type, week, price, guide);
                Museums.Add(museum);
            }
            return Museums;
        }
        public static void PrintMuseums(List<Museum> Museums)
        {
            Console.WriteLine(new String('-', 125));
            Console.WriteLine("| {0,-15} | {1,-10} | {2,-8} |   {3,2}   |   {4,2}   |   {5,3}  |   {6,2}   |   {7,2}   |   {8,2}   |  {9,2}   | {10,7} | {11,-6} |", 
                "Pavadinimas", "Miestas", "Tipas", "I", "II", "III", "IV", "V", "VI", "VII", "Kaina", "Gidas");
            Console.WriteLine(new String('-', 125));
            foreach (Museum museum in Museums)
            {
                Console.Write("| {0,-15} | {1,-10} | {2,-8} |", museum.Name, museum.City, museum.Type);
                for (int i = 0; i < 7; i++)
                {
                    Console.Write(" {0,6} |", museum.WorkingOrNot(i));
                }
                Console.WriteLine(" {0,7:f2} | {1, -6} |", museum.Price, museum.Guide);
            }
            Console.WriteLine(new String('-', 125));
        }
        public static void PrintHowManyHaveGuide(List<Museum> Museums, string City)
        {
            if(TaskUtils.HowManyHaveGuide(Museums, City) > 0)
                Console.WriteLine("{0} turi {1} muziejus su gidais", City, TaskUtils.HowManyHaveGuide(Museums, City));
            else
                Console.WriteLine("{0} neturi muziejų su gidais", City, TaskUtils.HowManyHaveGuide(Museums, City));
        }
        public static void PrintTypes(List<string> Types, string City, string Day)
        {
            if (Types.Count > 0)
            {
                Console.WriteLine("{0} {1} galima aplankyti tokio tipo muziejus:", City, Day);
                foreach (string type in Types)
                {
                    Console.WriteLine(type);
                }
            }
            else
                Console.WriteLine("{0} {1} nėra dirbančių muziejų", City, Day);
        }
        public static void PrintMuseumsToCSVFile(string fileName, List<Museum> Museums)
        {
            string[] lines = new string[Museums.Count + 1];
            lines[0] = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}", "Pavadinimas", "Miestas", "Tipas", "I", "II", "III", "IV", "V", "VI", "VII", "Kaina", "Gidas");
            if (Museums.Count > 0)
            {
                for (int i = 0; i < Museums.Count; i++)
                {
                    lines[i + 1] = String.Format("{0};{1};{2};", Museums[i].Name, Museums[i].City, Museums[i].Type);
                    for (int j = 0; j < 7; j++)
                    {
                        lines[i + 1] += String.Format("{0};", Museums[i].WorkingOrNot(j));
                    }
                    lines[i + 1] += String.Format("{0};{1}", Museums[i].Price, Museums[i].Guide);
                }
            }
            else
            {
                String.Format("Tokių muziejų nėra");
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
