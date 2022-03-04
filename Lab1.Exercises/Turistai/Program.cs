using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turistai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tourist> allTourists = InOutUtils.ReadTourists(@"Duom.txt");
            InOutUtils.PrintTourists(allTourists);
            InOutUtils.PrintTouristsWithContributions(allTourists);
            Console.WriteLine("Bendrai skirta pinigų {0,7:f2}", TaskUtils.SumContributions(allTourists));
            Console.WriteLine("Grupės nariai kurie skyrė daugiausiai pinigų:");
            List<Tourist> FilterByMaxContribution = TaskUtils.FilterByMaxContribution(allTourists);
            InOutUtils.PrintTouristsWithContributions(FilterByMaxContribution);
            InOutUtils.PrintFilterdTouristsToCSVFile("MaxContributions.csv", FilterByMaxContribution);

            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
