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
            FridgeContainer allFridges = new FridgeContainer();
            OvenContainer allOvens = new OvenContainer();
            KettleContainer allKettles = new KettleContainer();
            DeviceContainer container1 = InOutUtils.ReadRefrigirators(@"Duom.txt", allFridges, allOvens, allKettles);
            InOutUtils.PrintDevices(container1);
            DeviceContainer container2 = InOutUtils.ReadRefrigirators(@"Duom2.txt", allFridges, allOvens, allKettles);
            InOutUtils.PrintDevices(container2);
            DeviceContainer container3 = InOutUtils.ReadRefrigirators(@"Duom3.txt", allFridges, allOvens, allKettles);
            InOutUtils.PrintDevices(container3);
            //Finds what colour fridges you can buy
            List<string> allFridgeColours = allFridges.AllFridgeColours();
            InOutUtils.PrintListStringColours("Visos šaldytuvų spalvos:", allFridgeColours);
            List<string> allKettleColours = allKettles.AllKettleColours();
            InOutUtils.PrintListStringColours("Visos virdulių spalvos:", allKettleColours);
            FridgeContainer minPriceFridge = allFridges.FridgeWithMinPriceOFA();
            //Finds min prices of all devicess with A+ energy class
            Console.WriteLine("Pigiausi A+ klasės šaldytuvai: ");
            InOutUtils.PrintRefrigirators(minPriceFridge);
            OvenContainer minPriceOvens = allOvens.OvenWithMinPriceOFA();
            Console.WriteLine("Pigiausios A+ klasės krosnelės: ");
            InOutUtils.PrintOvens(minPriceOvens);
            KettleContainer minPriceKettles = allKettles.KettleWithMinPriceOFA();
            Console.WriteLine("Pigiausi A+ klasės virduliai: ");
            InOutUtils.PrintKettles(minPriceKettles);
            //Finds fridges width between 52 and 56 and sorts them
            FridgeContainer fridgeBySize = allFridges.FilterBySize();
            fridgeBySize.Sort(new DeviceComparatorByPrice());
            InOutUtils.PrintRefrigiraitorsToCSVFile("Tilps.csv" ,fridgeBySize);
            //Finds devices that are in all stores
            DeviceContainer inAllStores = container1.InEvryStore(container2, container3);
            InOutUtils.PrintDevicesToCSVFile("Visur.csv", inAllStores);
        }
    }
}
