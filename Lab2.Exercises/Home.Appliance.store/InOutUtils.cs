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
        public static RefrigiratorsRegister ReadRefrigirators(string fileName)
        {
            RefrigiratorsRegister Refrigirators = new RefrigiratorsRegister();
            StreamReader read = new StreamReader(fileName);
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
        public static void PrintRefrigirators(RefrigiratorsRegister register)
        {
            Console.WriteLine(new string('-', 115));
            Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,15} | {4,-15} | {5,-10} | {6,-13} | {7,-7} |", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Turi šaldiklį", "Kaina");
            Console.WriteLine(new string('-', 115));



            for (int i = 0; i < register.RefrigiratorCount(); i++)
            {
                Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,15} | {4,-15} | {5,-10} | {6,-13} | {7,7:f2} |", register.GetRefrigirator(i).Manufacturer, register.GetRefrigirator(i).Model, register.GetRefrigirator(i).Capacity, register.GetRefrigirator(i).EnergyClass, register.GetRefrigirator(i).MountingType, register.GetRefrigirator(i).Colour, register.GetRefrigirator(i).HasFreezer, register.GetRefrigirator(i).Price);
            }
            Console.WriteLine(new string('-', 115));
            Console.WriteLine();
        }
        public static void PrintRefrigiratorsSmalestPrice(List<Refrigirator> Refs, RefrigiratorsRegister r1, RefrigiratorsRegister r2)
        {
            if (Refs.Count > 0)
            {
                Console.WriteLine("Pigiausi pastatomi šaldytuvai kurie turi šaldiklius:");
                Console.WriteLine(new String('-', 141));
                Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,15} | {4,-15} | {5,-10} | {6,-13} | {7,-7} | {8,23} |", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Turi šaldiklį", "Kaina", "Parduotuvės pavadinimas");
                Console.WriteLine(new String('-', 141));
                foreach (Refrigirator refrigirator in Refs)
                {
                    if (r1.Contains(refrigirator) && r2.Contains(refrigirator))
                        Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,15} | {4,-15} | {5,-10} | {6,-13} | {7,7:f2} | {8,23} |", refrigirator.Manufacturer, refrigirator.Model, refrigirator.Capacity, refrigirator.EnergyClass, refrigirator.MountingType, refrigirator.Colour, refrigirator.HasFreezer, refrigirator.Price, "Galima rasti abejuose");
                    else if (r1.Contains(refrigirator))
                        Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,15} | {4,-15} | {5,-10} | {6,-13} | {7,7:f2} | {8,-23} |", refrigirator.Manufacturer, refrigirator.Model, refrigirator.Capacity, refrigirator.EnergyClass, refrigirator.MountingType, refrigirator.Colour, refrigirator.HasFreezer, refrigirator.Price, r1.ShopName);
                    else
                        Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,15} | {4,-15} | {5,-10} | {6,-13} | {7,7:f2} | {8,-23} |", refrigirator.Manufacturer, refrigirator.Model, refrigirator.Capacity, refrigirator.EnergyClass, refrigirator.MountingType, refrigirator.Colour, refrigirator.HasFreezer, refrigirator.Price, r2.ShopName);
                }
                Console.WriteLine(new String('-', 141));
            }
            else
                Console.WriteLine("Informaacijos apie pigiausią pastatomą šaldytuvą su šaldikliu nėra");
            Console.WriteLine();
        }
        public static void PrintMaxPriceManufacturer (RefrigiratorsRegister Filtered)
        {
            Console.Write("{0} parduotuvėje brangiausius šaldytuvus pardavinėja: ", Filtered.ShopName);
            for (int i = 0; i < Filtered.RefrigiratorCount(); i++)
            {
                Console.WriteLine("{0} ", Filtered.GetRefrigirator(i).Manufacturer);
            }
            Console.WriteLine();
        }
        public static void PrintRefrigiraitorsToCSVFile(string fileName, RefrigiratorsRegister Filtered)
        {
            if(Filtered.RefrigiratorCount() != 0)
            {
                string[] lines = new string[Filtered.RefrigiratorCount() + 1];
                lines[0] = string.Format("{0,-10};{1,-15};{2,5};{3,15};{4,-15};{5,-10};{6,-13};{7,-7}", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Turi šaldiklį", "Kaina");
                for (int i = 0; i < Filtered.RefrigiratorCount(); i++)
                {
                    lines[i + 1] = String.Format("{0,-10};{1,-15};{2,5};{3,15};{4,-15};{5,-10};{6,-13};{7,7:f2}", Filtered.GetRefrigirator(i).Manufacturer, Filtered.GetRefrigirator(i).Model, Filtered.GetRefrigirator(i).Capacity, Filtered.GetRefrigirator(i).EnergyClass, Filtered.GetRefrigirator(i).MountingType, Filtered.GetRefrigirator(i).Colour, Filtered.GetRefrigirator(i).HasFreezer, Filtered.GetRefrigirator(i).Price);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                string[] lines = new string[Filtered.RefrigiratorCount() + 1];
                lines[0] = string.Format("{0}", "Šaldytuvu kuriuos pardavinėtų abi parduotuvės nėra");
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }

    }
}
