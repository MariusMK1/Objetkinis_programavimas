using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            //Reading and printing initial data
            RefrigiratorsRegister register1 = InOutUtils.ReadRefrigirators(@"Duom.txt");
            InOutUtils.PrintRefrigirators(register1);
            RefrigiratorsRegister register2 = InOutUtils.ReadRefrigirators(@"Duom2.txt");
            InOutUtils.PrintRefrigirators(register2);

            //Finding smalest price standing with a freezer refrigirator
            List<Refrigirator> Filtered = new List<Refrigirator>();
            double minPrice = TaskUtils.FindsSmallestPriceOFStandingNoFreezerInTwoRegisters(register1, register2);
            Console.WriteLine(minPrice);
            TaskUtils.FindsBySmalestPriceOfStandigNoFreezer(Filtered, register1, minPrice);
            TaskUtils.FindsBySmalestPriceOfStandigNoFreezer(Filtered, register2, minPrice);
            InOutUtils.PrintRefrigiratorsSmalestPrice(Filtered, register1, register2);

            //Finding most expensive manufacturer in each store
            InOutUtils.PrintMaxPriceManufacturer(register1.FilterByMaxPrice());
            InOutUtils.PrintMaxPriceManufacturer(register2.FilterByMaxPrice());

            //Finding fridges that are being sold in both stores
            InOutUtils.PrintRefrigiraitorsToCSVFile("Abi.csv", TaskUtils.BothShopsSells(register1, register2));
            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
