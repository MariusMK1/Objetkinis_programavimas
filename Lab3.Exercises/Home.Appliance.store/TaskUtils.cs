using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    internal class TaskUtils
    {
        public static double FindsSmallestPriceOFStandingNoFreezerInTwoRegisters(RefrigiratorsContainer container1, RefrigiratorsContainer container2)
        {
            double minPrice = 0;
            if (container1.FindsSmallestPriceOFStandingNoFreezer() <= container2.FindsSmallestPriceOFStandingNoFreezer())
                minPrice = container1.FindsSmallestPriceOFStandingNoFreezer();
            else
                minPrice = container2.FindsSmallestPriceOFStandingNoFreezer();
            return minPrice;
        }
        public static RefrigiratorsContainer FindsBySmalestPriceOfStandigNoFreezer(RefrigiratorsContainer Filtered, RefrigiratorsContainer container1, double minPrice)
        {
            for (int i = 0; i < container1.Count; i++)
            {
                if (container1.Get(i).MountingType == "Pastatomas" && container1.Get(i).HasFreezer == HasFreezer.True && minPrice == container1.Get(i).Price)
                {
                    if (!Filtered.Contains(container1.Get(i)))
                        Filtered.Add(container1.Get(i));
                }
            }
            return Filtered;
        }
        public static RefrigiratorsContainer BothShopsSells(RefrigiratorsContainer container1, RefrigiratorsContainer container2)
        {
            RefrigiratorsContainer Filtered = new RefrigiratorsContainer();
            for (int i = 0; i < container1.Count; i++)
            {
                if (container2.Contains(container1.Get(i)))
                {
                    Filtered.Add(container1.Get(i));
                }
            }
            return Filtered;
        }

    }
}
