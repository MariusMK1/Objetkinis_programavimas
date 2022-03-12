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
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            List<Ring> allRings = InOutUtils.ReadRings(@"Duom.txt");
            InOutUtils.PrintRings(allRings);
            Console.WriteLine();
            List<Ring> Filtered = TaskUtils.FilterByMaxWeight(allRings);
            InOutUtils.PrintHeaviestRings(Filtered);
            List<Ring> Filtered1 = TaskUtils.FilterHighestPurityGold(allRings);
            List<Ring> Filtered2 = TaskUtils.FilterHighestPuritySilver(allRings);
            List<Ring> Filtered3 = TaskUtils.FilterHighestPurityPlatinum(allRings);
            List<Ring> Filtered4 = TaskUtils.FilterHighestPurityPalladium(allRings);
            InOutUtils.PrintRingsWithHighestPurity(Filtered1, Filtered2, Filtered3, Filtered4);
            List<string> Metals = TaskUtils.FindMetals(allRings);
            InOutUtils.PrintMetalsToCSV("Metalai.csv", Metals);
            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
