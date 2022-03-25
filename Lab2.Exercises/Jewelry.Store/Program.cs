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
            RingsRegister register1 = InOutUtils.ReadRings(@"Duom.txt");
            RingsRegister register2 = InOutUtils.ReadRings(@"Duom2.txt");
            InOutUtils.PrintRings(register1);
            InOutUtils.PrintRings(register2);

            // Finds number of highest purity rings
            InOutUtils.PrintRingsWithHighestPurity(register1);
            InOutUtils.PrintRingsWithHighestPurity(register2);

            // Finds most expensive platinum ring
            RingsRegister filtered = new RingsRegister();
            double maxPricePlatinum = TaskUtils.MaxPricePlatinumInBothStores(register1, register2);
            TaskUtils.FindsMaxPricePlatinumRing(filtered, register1, maxPricePlatinum);
            TaskUtils.FindsMaxPricePlatinumRing(filtered, register2, maxPricePlatinum);
            InOutUtils.PrintRings(filtered);

            // Filters rings by size and price and prints it to CSV file
            RingsRegister filtered2 = new RingsRegister();
            register1.FiltersBySizeAndPrice(filtered2);
            register2.FiltersBySizeAndPrice(filtered2);

            InOutUtils.PrintRingsToCSVFile("Žiedai.csv", filtered2);

            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
