using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jewelry.Store
{
    internal class InOutUtils
    {
        public static List<Ring> ReadRings(string fileName)
        {
            List<Ring> Rings = new List<Ring>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string manufacturer = Values[0];
                string model = Values[1];
                string metal = Values[2];
                double weight = double.Parse(Values[3]);
                int size = int.Parse(Values[4]);
                int purity = int.Parse(Values[5]);
                double price = double.Parse(Values[6]);
                Ring ring = new Ring(manufacturer, model, metal, weight, size, purity, price);
                Rings.Add(ring);
            }
            return Rings;
        }
        public static void PrintRings(List<Ring> Rings)
        {
            Console.WriteLine(new String('-', 78));
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6} | {4,5} | {5,5} | {6,7} |", "Gamintojas", "Modelis", "Metalas", "Svoris", "Dydis", "Praba", "Kaina");
            Console.WriteLine(new String('-', 78));
            foreach (Ring ring in Rings)
            {
                Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6:f2} | {4,5} | {5,5} | {6,7:f2} |", ring.Manufacturer, ring.Model, ring.Metal, ring.Weight, ring.Size, ring.Purity, ring.Price);
            }
            Console.WriteLine(new String('-', 78));
        }
        public static void PrintHeaviestRings(List<Ring> Filtered)
        {
            Console.WriteLine("Daugiausiai sverentys žiedai:");
            foreach (Ring ring in Filtered)
            {
                  Console.WriteLine("{0} {1} {2} {3,4:f2} {4}", ring.Model, ring.Metal, ring.Size, ring.Weight, ring.Purity);
            }
            Console.WriteLine();
        }
        public static void PrintRingsWithHighestPurity(List<Ring> Filtered1, List<Ring> Filtered2, List<Ring> Filtered3, List<Ring> Filtered4)
        {
            Console.WriteLine("Aukščiausios prabos žiedų yra {0} vnt.", TaskUtils.HowManyRingsHighestPurity(Filtered1, Filtered2, Filtered3, Filtered4));
            Console.WriteLine("Aukščiausios prabos žiedai:");
            Console.WriteLine(new String('-', 78));
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6} | {4,5} | {5,5} | {6,7} |", "Gamintojas", "Modelis", "Metalas", "Svoris", "Dydis", "Praba", "Kaina");
            Console.WriteLine(new String('-', 78));
            if (Filtered1.Count != 0)
            {
                foreach (Ring ring in Filtered1)
                {
                    Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6:f2} | {4,5} | {5,5} | {6,7:f2} |", ring.Manufacturer, ring.Model, ring.Metal, ring.Weight, ring.Size, ring.Purity, ring.Price);
                }
            }
            else
            {
                Console.WriteLine("| Aukščiausios prabos aukso žiedų nėra. |");
            }
            if (Filtered2.Count != 0)
            {
                foreach (Ring ring in Filtered2)
                {
                    Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6:f2} | {4,5} | {5,5} | {6,7:f2} |", ring.Manufacturer, ring.Model, ring.Metal, ring.Weight, ring.Size, ring.Purity, ring.Price);
                }
            }
            else
            {
                Console.WriteLine("| Aukščiausios prabos sidabro žiedų nėra. |");
            }
            if (Filtered3.Count != 0)
            {
                foreach (Ring ring in Filtered3)
                {
                    Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6:f2} | {4,5} | {5,5} | {6,7:f2} |", ring.Manufacturer, ring.Model, ring.Metal, ring.Weight, ring.Size, ring.Purity, ring.Price);
                }
            }
            else
            {
                Console.WriteLine("| Aukščiausios prabos platinos žiedų nėra. |");
            }
            if (Filtered4.Count != 0)
            {
                foreach (Ring ring in Filtered4)
                {
                    Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6:f2} | {4,5} | {5,5} | {6,7:f2} |", ring.Manufacturer, ring.Model, ring.Metal, ring.Weight, ring.Size, ring.Purity, ring.Price);
                }
            }
            else
            {
                Console.WriteLine("| Aukščiausios prabos paladžio žiedų nėra. |");
            }
            Console.WriteLine(new String('-', 78));
        }
        public static void PrintMetalsToCSV(string fileName, List<string> Metals)
        {
            string[] lines = new string[Metals.Count + 1];
            lines[0] = string.Format("{0}", "Metalas");
            for (int i = 0; i < Metals.Count; i++)
            {
                lines[i + 1] = String.Format("{0}", Metals[i]);
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
    }
}
