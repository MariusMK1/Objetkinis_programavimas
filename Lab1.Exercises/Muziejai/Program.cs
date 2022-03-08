using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muziejai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            List<Museum> allMuseums = InOutUtils.ReadMuseums(@"muziejai.txt");
            InOutUtils.PrintMuseums(allMuseums);
            InOutUtils.PrintHowManyHaveGuide(allMuseums, "Kaunas");
            Console.WriteLine();
            List<string> Types = TaskUtils.FindTypesInCityOnDay(allMuseums, "Vilnius", 2);
            InOutUtils.PrintTypes(Types, "Vilnius", "Trečiadienį");
            List<Museum> NotLesThanTwoDays = TaskUtils.NotLessThanTwoDays(allMuseums, "Kaunas");
            InOutUtils.PrintMuseumsToCSVFile("Filtruoti.csv", NotLesThanTwoDays);
        }
    }
}
