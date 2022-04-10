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
            DeviceContainer container1 = InOutUtils.ReadRefrigirators(@"Duom.txt");
            InOutUtils.PrintRefrigirators(container1);
            DeviceContainer container2 = InOutUtils.ReadRefrigirators(@"Duom2.txt");
            InOutUtils.PrintRefrigirators(container2);
            DeviceContainer container3 = InOutUtils.ReadRefrigirators(@"Duom3.txt");
            InOutUtils.PrintRefrigirators(container3);

            //// Findig all the capacities
            //List<int> capacities = new List<int>();
            //container1.FindCapacities(capacities);
            //container2.FindCapacities(capacities);
            //InOutUtils.PrintCapacities(capacities);

            ////Finding smalest price standing with a freezer refrigirator
            //DeviceContainer Filtered = new DeviceContainer();
            //double minPrice = TaskUtils.FindsSmallestPriceOFStandingNoFreezerInTwoRegisters(container1, container2);
            //Console.WriteLine(minPrice);
            //TaskUtils.FindsBySmalestPriceOfStandigNoFreezer(Filtered, container1, minPrice);
            //TaskUtils.FindsBySmalestPriceOfStandigNoFreezer(Filtered, container2, minPrice);
            //InOutUtils.PrintRefrigiratorsSmalestPrice(Filtered, container1, container2);

            ////Finding all white A++ refrigirators and sorting them
            //DeviceContainer Filtered2 = new DeviceContainer();
            //container1.FilterWhiteA(Filtered2);
            //container2.FilterWhiteA(Filtered2);
            //Filtered2.Sort();
            //InOutUtils.PrintRefrigiraitorsToCSVFile("Balti.csv", Filtered2);

            //////Finding fridges that are being sold in both stores
            //InOutUtils.PrintRefrigiraitorsToCSVFile("Abi.csv", TaskUtils.BothShopsSells(container1, container2));
            //Console.WriteLine("Programa baigė darbą!");
        }
    }
}
