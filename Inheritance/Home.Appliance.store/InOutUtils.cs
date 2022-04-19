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
        public static DeviceContainer ReadRefrigirators(string fileName, FridgeContainer AllFridges, OvenContainer AllOvens, KettleContainer AllKettles)
        {
            DeviceContainer device = new DeviceContainer();
            StreamReader read = new StreamReader(fileName, Encoding.UTF8);
            string name = read.ReadLine();
            string address = read.ReadLine();
            string phoneNumber = read.ReadLine();
            string lines;
            device.ShopName = name;
            device.Address = address;
            device.PhoneNumber = phoneNumber;

            while ((lines = read.ReadLine()) != null)
            {
                string[] Values = lines.Split(';');
                string type = Values[0];
                string manufacturer = Values[1];
                string model = Values[2];
                string energyType = Values[3];
                string colour = Values[4];
                double price = double.Parse(Values[5]);
                switch (type)
                {
                    case "Fridge":
                        int capacity = int.Parse(Values[6]);
                        string mountingType = Values[7];
                        HasFreezer hasFreezer;
                        Enum.TryParse(Values[8], out hasFreezer);
                        double height = double.Parse(Values[9]);
                        double width = double.Parse(Values[10]);
                        double length = double.Parse(Values[11]);
                        Fridge fridge = new Fridge(type, manufacturer, model, energyType, colour, price, capacity, mountingType, hasFreezer, height, width, length);
                        if (!device.Contains(fridge))
                        {
                            device.Add(fridge);
                        }
                        if (!AllFridges.Contains(fridge))
                        {
                            AllFridges.Add(fridge);
                        }
                        break;
                    case "Oven":
                        int power = int.Parse(Values[6]);
                        int numberPrograms = int.Parse(Values[7]);
                        Oven oven = new Oven(type, manufacturer, model, energyType, colour, price, power, numberPrograms);
                        if (!device.Contains(oven))
                        {
                            device.Add(oven);
                        }
                        if (!AllOvens.Contains(oven))
                        {
                            AllOvens.Add(oven);
                        }
                        break;
                    case "Kettle":
                        int power2 = int.Parse(Values[6]);
                        int capacity2 = int.Parse(Values[7]);
                        Kettle kettle = new Kettle(type, manufacturer, model, energyType, colour, price, power2, capacity2);
                        if (!device.Contains(kettle))
                        {
                            device.Add(kettle);
                        }
                        if (!AllKettles.Contains(kettle))
                        {
                            AllKettles.Add(kettle);
                        }
                        break;
                    default:
                        break; //unknown type
                }
            }
            return device;
        }
        public static void PrintDevices(DeviceContainer container)
        {
            Console.WriteLine("{0}", container.ShopName);
            Console.WriteLine(new string('-', Device.PrintFormat().Length));
            Console.WriteLine(Device.PrintFormat());
            Console.WriteLine(new string('-', Device.PrintFormat().Length));

            for (int i = 0; i < container.Count; i++)
            {
                Console.WriteLine(container.Get(i).ToString());
            }
            Console.WriteLine(new string('-', Device.PrintFormat().Length));
            Console.WriteLine();
        }
        public static void PrintDevicesToCSVFile(string fileName, DeviceContainer Filtered)
        {
            if (Filtered.Count != 0)
            {
                string[] lines = new string[Filtered.Count + 1];
                lines[0] = Device.PrintFormat();
                for (int i = 0; i < Filtered.Count; i++)
                {
                    lines[i + 1] = String.Format(Filtered.Get(i).ToString());
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                string[] lines = new string[Filtered.Count + 1];
                lines[0] = string.Format("{0}", "Tokių prekių nėra nėra");
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
        public static void PrintRefrigirators(FridgeContainer container)
        {
            Console.WriteLine("{0}", container.ShopName);
            Console.WriteLine(new string('-', Device.PrintFormat().Length));
            Console.WriteLine(Device.PrintFormat());
            Console.WriteLine(new string('-', Device.PrintFormat().Length));

            for (int i = 0; i < container.Count; i++)
            {
                Console.WriteLine(container.Get(i).ToString());
            }
            Console.WriteLine(new string('-', Device.PrintFormat().Length));
            Console.WriteLine();
        }
        public static void PrintRefrigiraitorsToCSVFile(string fileName, FridgeContainer Filtered)
        {
            if (Filtered.Count != 0)
            {
                string[] lines = new string[Filtered.Count + 1];
                lines[0] = Device.PrintFormat();
                for (int i = 0; i < Filtered.Count; i++)
                {
                    lines[i + 1] = String.Format(Filtered.Get(i).ToString());
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
        public static void PrintOvens(OvenContainer container)
        {
            Console.WriteLine("{0}", container.ShopName);
            Console.WriteLine(new string('-', Device.PrintFormat().Length));
            Console.WriteLine(Device.PrintFormat());
            Console.WriteLine(new string('-', Device.PrintFormat().Length));

            for (int i = 0; i < container.Count; i++)
            {
                Console.WriteLine(container.Get(i).ToString());
            }
            Console.WriteLine(new string('-', Device.PrintFormat().Length));
            Console.WriteLine();
        }
        public static void PrintKettles(KettleContainer container)
        {
            Console.WriteLine("{0}", container.ShopName);
            Console.WriteLine(new string('-', Device.PrintFormat().Length));
            Console.WriteLine(Device.PrintFormat());
            Console.WriteLine(new string('-', Device.PrintFormat().Length));

            for (int i = 0; i < container.Count; i++)
            {
                Console.WriteLine(container.Get(i).ToString());
            }
            Console.WriteLine(new string('-', Device.PrintFormat().Length));
            Console.WriteLine();
        }
        public static void PrintListStringColours (string title, List<string> colours)
        {
            Console.WriteLine(title);
            for(int i = 0;i < colours.Count; i++)
            {
                Console.WriteLine(colours[i]);
            }
            Console.WriteLine();
        }
        //public static void PrintCapacities(List<int> capacities)
        //{
        //    if (capacities.Count != 0)
        //    {
        //        Console.WriteLine("Skirtingos talpos su kokiomis galima įsigyti šaldytuvus:");
        //        for (int i = 0; i < capacities.Count; i++)
        //        {
        //            Console.WriteLine("{0}", capacities[i]);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Šiuo metu nėra jokių šaldytuvų kuriuos galima įsigyti");
        //    }
        //    Console.WriteLine();
        //}
        //public static void PrintRefrigiratorsSmalestPrice(DeviceContainer Refs, DeviceContainer r1, DeviceContainer r2)
        //{
        //    if (Refs.Count > 0)
        //    {
        //        Console.WriteLine("Pigiausi pastatomi šaldytuvai kurie turi šaldiklius:");
        //        Console.WriteLine(new String('-', 76));
        //        Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,-7} | {4,23} |", "Gamintojas", "Modelis", "Talpa", "Kaina", "Parduotuvės pavadinimas");
        //        Console.WriteLine(new String('-', 76));
        //        for (int i = 0; i < Refs.Count; i++)
        //        {
        //            Device refrigirator = Refs.Get(i);
        //            if (r1.Contains(Refs.Get(i)) && r2.Contains(Refs.Get(i)))
        //                Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,7:f2} | {4,23} |", refrigirator.Manufacturer, refrigirator.Model, refrigirator.Capacity, refrigirator.Price, "Galima rasti abejuose");
        //            else if (r1.Contains(refrigirator))
        //                Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,7:f2} | {4,-23} |", refrigirator.Manufacturer, refrigirator.Model, refrigirator.Capacity, refrigirator.Price, r1.ShopName);
        //            else
        //                Console.WriteLine("| {0,-10} | {1,-15} | {2,5} | {3,7:f2} | {4,-23} |", refrigirator.Manufacturer, refrigirator.Model, refrigirator.Capacity, refrigirator.Price, r2.ShopName);
        //        }
        //        Console.WriteLine(new String('-', 76));
        //    }
        //    else
        //        Console.WriteLine("Informaacijos apie pigiausią pastatomą šaldytuvą su šaldikliu nėra");
        //    Console.WriteLine();
        //}
    }
}
