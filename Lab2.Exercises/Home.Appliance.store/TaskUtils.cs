using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    internal class TaskUtils
    {
        public static double FindsSmallestPriceOFStandingNoFreezerInTwoRegisters(RefrigiratorsRegister register1, RefrigiratorsRegister register2)
        {
            double minPrice = 0;
            if (register1.FindsSmallestPriceOFStandingNoFreezer() <= register2.FindsSmallestPriceOFStandingNoFreezer())
                minPrice = register1.FindsSmallestPriceOFStandingNoFreezer();
            else
                minPrice = register2.FindsSmallestPriceOFStandingNoFreezer();
            return minPrice;
        }
        public static List<Refrigirator> FindsBySmalestPriceOfStandigNoFreezer(List<Refrigirator> Filtered, RefrigiratorsRegister register1, double minPrice)
        {
            for (int i = 0; i < register1.RefrigiratorCount(); i++)
            {
                if (register1.GetRefrigirator(i).MountingType == "Pastatomas" && register1.GetRefrigirator(i).HasFreezer == HasFreezer.True && minPrice == register1.GetRefrigirator(i).Price)
                {
                    if (!Filtered.Contains(register1.GetRefrigirator(i)))
                        Filtered.Add(register1.GetRefrigirator(i));
                }
            }
            return Filtered;
        }
        public static RefrigiratorsRegister BothShopsSells(RefrigiratorsRegister register1, RefrigiratorsRegister register2)
        {
            RefrigiratorsRegister Filtered = new RefrigiratorsRegister();
            for(int i = 0; i < register1.RefrigiratorCount(); i++)
            {
                if (register2.Contains(register1.GetRefrigirator(i)))
                {
                    Filtered.Add(register1.GetRefrigirator(i));
                }
            }
            return Filtered;
        }

    }
}
