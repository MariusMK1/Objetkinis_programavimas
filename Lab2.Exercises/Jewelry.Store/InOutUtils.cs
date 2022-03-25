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
        public static RingsRegister ReadRings(string fileName)
        {
            RingsRegister Rings = new RingsRegister();
            StreamReader read = new StreamReader(fileName);
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
        public static void PrintRings(RingsRegister register)
        {
            Console.WriteLine("{0}", register.ShopName);
            Console.WriteLine(new string('-', 78));
            Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6} | {4,5} | {5,5} | {6,7} |", "Gamintojas", "Modelis", "Metalas", "Svoris", "Dydis", "Praba", "Kaina");
            Console.WriteLine(new string('-', 78));

            for (int i = 0; i < register.RingCount(); i++)
            {
                Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6:f2} | {4,5} | {5,5} | {6,7:f2} |", register.GetRing(i).Manufacturer, register.GetRing(i).Model, register.GetRing(i).Metal, register.GetRing(i).Weight, register.GetRing(i).Size, register.GetRing(i).Purity, register.GetRing(i).Price);
            }
            Console.WriteLine(new string('-', 78));
            Console.WriteLine();
        }
        public static void PrintRingsWithHighestPurity(RingsRegister register)
        {
            Console.WriteLine("Parduotuvėje {0}:", register.ShopName);
            Console.WriteLine("Aukščiausios prabos žiedų yra {0} vnt.", register.HowManyRingsHighestPurity());
            Console.WriteLine("Aukščiausios prabos žiedai:");
            if (register.FilterHighestPurityGold().Count != 0)
            {
                Console.WriteLine("Aukščiausios prabos aukso žiedų yra {0} vnt", register.FilterHighestPurityGold().Count);
            }
            else
            {
                Console.WriteLine("Aukščiausios prabos aukso žiedų nėra.");
            }
            if (register.FilterHighestPuritySilver().Count != 0)
            {
                Console.WriteLine("Aukščiausios prabos sidabro žiedų yra {0} vnt", register.FilterHighestPuritySilver().Count);
            }
            else
            {
                Console.WriteLine("Aukščiausios prabos sidabro žiedų nėra.");
            }
            if (register.FilterHighestPurityPlatinum().Count != 0)
            {
                Console.WriteLine("Aukščiausios prabos platinos žiedų yra {0} vnt", register.FilterHighestPurityPlatinum().Count);
            }
            else
            {
                Console.WriteLine("Aukščiausios prabos platinos žiedų nėra.");
            }
            if (register.FilterHighestPurityPalladium().Count != 0)
            {
                Console.WriteLine("Aukščiausios prabos paladžio žiedų yra {0} vnt", register.FilterHighestPurityPalladium().Count);
            }
            else
            {
                Console.WriteLine("Aukščiausios prabos paladžio žiedų nėra.");
            }
            Console.WriteLine();
        }
        public static void PrintMaxPricePlatinumRings(RingsRegister register)
        {
            if (register.RingCount() != 0)
            {
                Console.WriteLine(new string('-', 78));
                Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6} | {4,5} | {5,5} | {6,7} |", "Gamintojas", "Modelis", "Metalas", "Svoris", "Dydis", "Praba", "Kaina");
                Console.WriteLine(new string('-', 78));

                for (int i = 0; i < register.RingCount(); i++)
                {
                    Console.WriteLine("| {0,-10} | {1,-15} | {2,-8} | {3,6:f2} | {4,5} | {5,5} | {6,7:f2} |", register.GetRing(i).Manufacturer, register.GetRing(i).Model, register.GetRing(i).Metal, register.GetRing(i).Weight, register.GetRing(i).Size, register.GetRing(i).Purity, register.GetRing(i).Price);
                }
                Console.WriteLine(new string('-', 78));
                Console.WriteLine();
            }
            else
                Console.WriteLine("Žiedų pagamintų iš platinos nėra");
        }
        public static void PrintRingsToCSVFile(string fileName, RingsRegister Filtered)
        {
            if (Filtered.RingCount() != 0)
            {
                string[] lines = new string[Filtered.RingCount() + 1];
                lines[0] = string.Format("{0};{1};{2};{3};{4};{5};{6}", "Gamintojas", "Modelis", "Metalas", "Svoris", "Dydis", "Praba", "Kaina");
                for (int i = 0; i < Filtered.RingCount(); i++)
                {
                    lines[i + 1] = string.Format("{0};{1};{2};{3};{4};{5};{6}", Filtered.GetRing(i).Manufacturer, Filtered.GetRing(i).Model, Filtered.GetRing(i).Metal, Filtered.GetRing(i).Weight, Filtered.GetRing(i).Size, Filtered.GetRing(i).Purity, Filtered.GetRing(i).Price);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                string[] lines = new string[Filtered.RingCount() + 1];
                lines[0] = string.Format("{0}", "Tokių žiedų nėra");
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
    }
}
