using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.appliance.store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            List<Refrigirator> allRefrigirators = InOutUtils.ReadRefrigirators(@"Duom.txt");
            InOutUtils.PrintRefrigirators(allRefrigirators);
            InOutUtils.PrintCapacities(TaskUtils.FindCapacities(allRefrigirators));
            List<Refrigirator> Filtered = TaskUtils.FindsBySmalestPriceOfStandigNoFrezer(allRefrigirators);
            InOutUtils.PrintRefrigiratorsBySmalestPriceOfStandigNoFrezer(Filtered);
            List<Refrigirator> Filtered2 = TaskUtils.FindsByColourAndEnergyClass(allRefrigirators, "A++", "Balta");
            InOutUtils.PrintRefrigiratorsBYColourAndEnergyClassToCSVFile("Refrigirators.csv", Filtered2);
            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
