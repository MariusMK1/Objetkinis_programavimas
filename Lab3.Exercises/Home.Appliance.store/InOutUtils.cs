using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Home.Appliance.store
{
    internal class InOutUtils
    {
        public static RefrigiratorsContainer ReadRefrigirators(string fileName)
        {
            RefrigiratorsContainer Refrigirators = new RefrigiratorsContainer();
            StreamReader read = new StreamReader(fileName, Encoding.UTF8);
            string name = read.ReadLine();
            string address = read.ReadLine();
            string phoneNumber = read.ReadLine();
            string lines;
            Refrigirators.ShopName = name;
            Refrigirators.Address = address;
            Refrigirators.PhoneNumber = phoneNumber;

            while ((lines = read.ReadLine()) != null)
            {
                string[] Values = lines.Split(';');
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
                if (!Refrigirators.Contains(refrigirator))
                {
                    Refrigirators.Add(refrigirator);
                }
            }
            return Refrigirators;
        }
        public static void PrintRefrigirators(RefrigiratorsContainer container)
        {
            Console.WriteLine("{0}", container.ShopName);
            Console.WriteLine(new string('-', 115));
            Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,15} | {4,-15} | {5,-10} | {6,-13} | {7,-7} |", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Turi šaldiklį", "Kaina");
            Console.WriteLine(new string('-', 115));



            for (int i = 0; i < container.Count; i++)
            {
                Refrigirator refrigirator = container.Get(i);
                Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,15} | {4,-15} | {5,-10} | {6,-13} | {7,7:f2} |", refrigirator.Manufacturer, refrigirator.Model, refrigirator.Capacity, refrigirator.EnergyClass, refrigirator.MountingType, refrigirator.Colour, refrigirator.HasFreezer, refrigirator.Price);
            }
            Console.WriteLine(new string('-', 115));
            Console.WriteLine();
        }
        public static void PrintCapacities(List<int> capacities)
        {
            if (capacities.Count != 0)
            {
                Console.WriteLine("Skirtingos talpos su kokiomis galima įsigyti šaldytuvus:");
                for (int i = 0; i < capacities.Count; i++)
                {
                    Console.WriteLine("{0}", capacities[i]);
                }
            }
            else
            {
                Console.WriteLine("Šiuo metu nėra jokių šaldytuvų kuriuos galima įsigyti");
            }
            Console.WriteLine();
        }
        public static void PrintRefrigiratorsSmalestPrice(RefrigiratorsContainer Refs, RefrigiratorsContainer r1, RefrigiratorsContainer r2)
        {
            if (Refs.Count > 0)
            {
                Console.WriteLine("Pigiausi pastatomi šaldytuvai kurie turi šaldiklius:");
                Console.WriteLine(new String('-', 76));
                Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,-7} | {4,23} |", "Gamintojas", "Modelis", "Talpa", "Kaina", "Parduotuvės pavadinimas");
                Console.WriteLine(new String('-', 76));
                for (int i = 0; i < Refs.Count; i++)
                {
                    Refrigirator refrigirator = Refs.Get(i);
                    if (r1.Contains(Refs.Get(i)) && r2.Contains(Refs.Get(i)))
                        Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,7:f2} | {4,23} |", refrigirator.Manufacturer, refrigirator.Model, refrigirator.Capacity, refrigirator.Price, "Galima rasti abejuose");
                    else if (r1.Contains(refrigirator))
                        Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,7:f2} | {4,-23} |", refrigirator.Manufacturer, refrigirator.Model, refrigirator.Capacity, refrigirator.Price, r1.ShopName);
                    else
                        Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,7:f2} | {4,-23} |", refrigirator.Manufacturer, refrigirator.Model, refrigirator.Capacity, refrigirator.Price, r2.ShopName);
                }
                Console.WriteLine(new String('-', 76));
            }
            else
                Console.WriteLine("Informaacijos apie pigiausią pastatomą šaldytuvą su šaldikliu nėra");
            Console.WriteLine();
        }
        public static void PrintRefrigiraitorsToCSVFile(string fileName, RefrigiratorsContainer Filtered)
        {
            if (Filtered.Count != 0)
            {
                string[] lines = new string[Filtered.Count + 1];
                lines[0] = string.Format("{0,-10};{1,-15};{2,5};{3,15};{4,-15};{5,-10};{6,-13};{7,-7}", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Turi šaldiklį", "Kaina");
                for (int i = 0; i < Filtered.Count; i++)
                {
                    lines[i + 1] = String.Format("{0,-10};{1,-15};{2,5};{3,15};{4,-15};{5,-10};{6,-13};{7,7:f2}", Filtered.Get(i).Manufacturer, Filtered.Get(i).Model, Filtered.Get(i).Capacity, Filtered.Get(i).EnergyClass, Filtered.Get(i).MountingType, Filtered.Get(i).Colour, Filtered.Get(i).HasFreezer, Filtered.Get(i).Price);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                string[] lines = new string[Filtered.Count + 1];
                lines[0] = string.Format("{0}", "Tokių šaldytuvų nėra");
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }

    }
}
