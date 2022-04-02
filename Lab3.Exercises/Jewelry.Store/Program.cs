using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Reads and prints files
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            RingsContainer container1 = InOutUtils.ReadRings(@"Duom.txt");
            RingsContainer container2 = InOutUtils.ReadRings(@"Duom2.txt");
            InOutUtils.PrintRings(container1);
            InOutUtils.PrintRings(container2);

            // Finds most expensive Gold ring
            RingsContainer filtered = new RingsContainer();
            double maxPriceGold = TaskUtils.MaxPriceGoldInBothStores(container1, container2);
            TaskUtils.FindsMaxPriceGoldRing(filtered, container1, maxPriceGold);
            TaskUtils.FindsMaxPriceGoldRing(filtered, container2, maxPriceGold);
            Console.WriteLine("Brangiausias auksinis žiedas:");
            InOutUtils.PrintMaxPriceGoldRings(filtered);

            // Finds number of highest purity rings
            InOutUtils.PrintRingsWithHighestPurity(container1);
            InOutUtils.PrintRingsWithHighestPurity(container2);

            //Finds rings that you can buy in both stores and prints to csv file
            RingsContainer filtered2 = TaskUtils.BothShopsSells(container1 , container2);
            InOutUtils.PrintRingsToCSVFile("Visur.csv", filtered2);


            // Filters rings by size and price and prints it to CSV file
            RingsContainer filtered3 = new RingsContainer();
            container1.FiltersBySizeAndPrice(filtered3);
            container2.FiltersBySizeAndPrice(filtered3);
            filtered3.Sort();
            InOutUtils.PrintRingsToCSVFile("Žiedai.csv", filtered3);

            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
