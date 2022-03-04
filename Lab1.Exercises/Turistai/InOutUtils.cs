using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Turistai
{
    internal class InOutUtils
    {
        public static List<Tourist>ReadTourists(string fileName)
        {
            List<Tourist> tourists = new List<Tourist>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string name= Values[0];
                string lastName = Values[1];
                double money = double.Parse(Values[2]);

                Tourist tourist = new Tourist(name, lastName, money);
                tourists.Add(tourist);
            }
            return tourists;
        }
        public static void PrintTourists(List<Tourist> tourists)
        {
            Console.WriteLine(new String('-', 38));
            Console.WriteLine("| {0,-8} | {1,-10} | {2,10} |", "Vardas", "Pavardė", "Pinigai");
            Console.WriteLine(new String('-', 38));
            foreach (Tourist tourist in tourists)
            {
                Console.WriteLine("| {0,-8} | {1,-10} | {2,10:f2} |", tourist.Name, tourist.LastName, tourist.Money);
            }
            Console.WriteLine(new String('-', 38));
        }
        public static void PrintTouristsWithContributions(List<Tourist> tourists)
        {
            Console.WriteLine(new String('-', 48));
            Console.WriteLine("| {0,-8} | {1,-10} | {2,10} | {3,7} |", "Vardas", "Pavardė", "Pinigai", "Skyrė");
            Console.WriteLine(new String('-', 48));
            foreach (Tourist tourist in tourists)
            {
                Console.WriteLine("| {0,-8} | {1,-10} | {2,10:f2} | {3,7:f2} |", tourist.Name, tourist.LastName, tourist.Money, tourist.Money * 0.25);
            }
            Console.WriteLine(new String('-', 48));
        }
        public static void PrintFilterdTouristsToCSVFile(string fileName, List<Tourist> tourists)
        {
            string[] lines = new string[tourists.Count + 1];
            lines[0] = string.Format("{0};{1};{2};{3}", "Vardas", "Pavardė", "Pinigai", "Skyrė");
            for (int i = 0; i < tourists.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3}", tourists[i].Name, tourists[i].LastName, tourists[i].Money, tourists[i].Money * 0.25);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
