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
        public static RingsContainer ReadRings(string fileName)
        {
            RingsContainer Rings = new RingsContainer();
            StreamReader read = new StreamReader(fileName, Encoding.UTF8);
            string name = read.ReadLine();
            string address = read.ReadLine();
            string phoneNumber = read.ReadLine();
            string lines;
            Rings.ShopName = name;
            Rings.Address = address;
            Rings.PhoneNumber = phoneNumber;

            while ((lines = read.ReadLine()) != null)
            {
                string[] Values = lines.Split(';');
                string manufacturer = Values[0];
                string model = Values[1];
                string metal = Values[2];
                double weight = double.Parse(Values[3]);
                int size = int.Parse(Values[4]);
                int purity = int.Parse(Values[5]);
                double price = double.Parse(Values[6]);
                Ring ring = new Ring(manufacturer, model, metal, weight, size, purity, price);
                if (!Rings.Contains(ring))
                {
                    Rings.Add(ring);
                }
            }
            return Rings;
        }
        public static void PrintRings(RingsContainer container)
        {
            Console.WriteLine("{0}", container.ShopName);
            Console.WriteLine(new string('-', 78));
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6} | {4,5} | {5,5} | {6,7} |", "Gamintojas", "Modelis", "Metalas", "Svoris", "Dydis", "Praba", "Kaina");
            Console.WriteLine(new string('-', 78));

            for (int i = 0; i < container.Count; i++)
            {
                Ring ring = container.Get(i);
                Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6:f2} | {4,5} | {5,5} | {6,7:f2} |", ring.Manufacturer, ring.Model, ring.Metal, ring.Weight, ring.Size, ring.Purity, ring.Price);
            }
            Console.WriteLine(new string('-', 78));
            Console.WriteLine();
        }
        public static void PrintRingsWithHighestPurity(RingsContainer container)
        {
            Console.WriteLine("Parduotuvėje {0}:", container.ShopName);
            Console.WriteLine("Aukščiausios prabos žiedų yra {0} vnt.", container.HowManyRingsHighestPurity());
            Console.WriteLine("Aukščiausios prabos žiedai:");
            if (container.FilterHighestPurityGold().Count != 0)
            {
                Console.WriteLine("Aukščiausios prabos aukso žiedų yra {0} vnt", container.FilterHighestPurityGold().Count);
            }
            else
            {
                Console.WriteLine("Aukščiausios prabos aukso žiedų nėra.");
            }
            if (container.FilterHighestPuritySilver().Count != 0)
            {
                Console.WriteLine("Aukščiausios prabos sidabro žiedų yra {0} vnt", container.FilterHighestPuritySilver().Count);
            }
            else
            {
                Console.WriteLine("Aukščiausios prabos sidabro žiedų nėra.");
            }
            if (container.FilterHighestPurityPlatinum().Count != 0)
            {
                Console.WriteLine("Aukščiausios prabos platinos žiedų yra {0} vnt", container.FilterHighestPurityPlatinum().Count);
            }
            else
            {
                Console.WriteLine("Aukščiausios prabos platinos žiedų nėra.");
            }
            if (container.FilterHighestPurityPalladium().Count != 0)
            {
                Console.WriteLine("Aukščiausios prabos paladžio žiedų yra {0} vnt", container.FilterHighestPurityPalladium().Count);
            }
            else
            {
                Console.WriteLine("Aukščiausios prabos paladžio žiedų nėra.");
            }
            Console.WriteLine();
        }
        public static void PrintMaxPriceGoldRings(RingsContainer container)
        {
            if (container.Count != 0)
            {
                Console.WriteLine(new string('-', 78));
                Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6} | {4,5} | {5,5} | {6,7} |", "Gamintojas", "Modelis", "Metalas", "Svoris", "Dydis", "Praba", "Kaina");
                Console.WriteLine(new string('-', 78));

                for (int i = 0; i < container.Count; i++)
                {
                    Ring ring = container.Get(i);
                    Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6:f2} | {4,5} | {5,5} | {6,7:f2} |", ring.Manufacturer, ring.Model, ring.Metal, ring.Weight, ring.Size, ring.Purity, ring.Price);
                }
                Console.WriteLine(new string('-', 78));
                Console.WriteLine();
            }
            else
                Console.WriteLine("Žiedų pagamintų iš Aukso nėra");
        }
        public static void PrintRingsToCSVFile(string fileName, RingsContainer Filtered)
        {
            if (Filtered.Count != 0)
            {
                string[] lines = new string[Filtered.Count + 1];
                lines[0] = string.Format("{0};{1};{2};{3};{4};{5};{6}", "Gamintojas", "Modelis", "Metalas", "Svoris", "Dydis", "Praba", "Kaina");
                for (int i = 0; i < Filtered.Count; i++)
                {
                    Ring ring = Filtered.Get(i);
                    lines[i + 1] = string.Format("{0};{1};{2};{3};{4};{5};{6}", ring.Manufacturer, ring.Model, ring.Metal, ring.Weight, ring.Size, ring.Purity, ring.Price);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                string[] lines = new string[Filtered.Count + 1];
                lines[0] = string.Format("{0}", "Tokių žiedų nėra");
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
    }
}
