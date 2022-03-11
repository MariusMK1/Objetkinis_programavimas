using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Home.appliance.store
{
    internal class InOutUtils
    {
        public static List<Refrigirator> ReadRefrigirators(string fileName)
        {
            List<Refrigirator> Refs = new List<Refrigirator>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string manufacturer = Values[0];
                string model = Values[1];
                int capacity = int.Parse(Values[2]);
                string energyType = Values[3];
                string mountingType = Values[4];
                string colour = Values[5];
                HasFreezer hasFreezer;
                Enum.TryParse(Values[6], out hasFreezer);
                double price = double.Parse(Values[7]);
                Refrigirator refrigirator = new Refrigirator(manufacturer, model, capacity, energyType, mountingType, colour, hasFreezer, price);
                Refs.Add(refrigirator);
            }
            return Refs;
        }
        public static void PrintRefrigirators(List<Refrigirator> Refs)
        {
            Console.WriteLine(new String('-', 115));
            Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,15} | {4,-15} | {5,-10} | {6,-13} | {7,-7} |", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Turi šaldiklį", "Kaina");
            Console.WriteLine(new String('-', 115));
            foreach (Refrigirator refrigirator in Refs)
            {
                Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,15} | {4,-15} | {5,-10} | {6,-13} | {7,7:f2} |", refrigirator.Manufacturer, refrigirator.Model, refrigirator.Capacity, refrigirator.EnergyClass, refrigirator.MountingType, refrigirator.Colour, refrigirator.HasFreezer, refrigirator.Price);
            }
            Console.WriteLine(new String('-', 115));
        }
        public static void PrintCapacities(List<int> capacities)
        {
            Console.WriteLine("Visos esamos talpos:");
            foreach (int capacity in capacities)
            {
                Console.WriteLine(capacity);
            }
            Console.WriteLine();
        }
        public static void PrintRefrigiratorsBySmalestPriceOfStandigNoFrezer(List<Refrigirator> Filtered)
        {
            if(!Filtered.Count.Equals(0))
            {
                Console.WriteLine("Mažiausia kainuojantys šaldytuvai kurie yra pastatomi ir turi šaldiklius:");
                foreach (Refrigirator refrigirator in Filtered)
                {
                    Console.WriteLine("{0} {1} {2} {3,7:f2}", refrigirator.Manufacturer, refrigirator.Model, refrigirator.Capacity, refrigirator.Price);
                }
            }
            else
            {
                Console.WriteLine("Šaldytuvų kurie yra pastatomi ir turi šaldiklius nėra");
            }
            Console.WriteLine();
        }
        public static void PrintRefrigiratorsBYColourAndEnergyClassToCSVFile(string fileName, List<Refrigirator> Refs)
        {
            if (!Refs.Count.Equals(0))
            {
                string[] lines = new string[Refs.Count + 1];
                lines[0] = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Turi šaldiklį", "Kaina");
                for (int i = 0; i < Refs.Count; i++)
                {
                    lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};", Refs[i].Manufacturer, Refs[i].Model, Refs[i].Capacity, Refs[i].EnergyClass, Refs[i].MountingType, Refs[i].Colour, Refs[i].HasFreezer, Refs[i].Price);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                string[] lines = new string[Refs.Count + 1];
                lines[0] = string.Format("Tokio tipo šaldytuvų nėra");
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
    }
}
