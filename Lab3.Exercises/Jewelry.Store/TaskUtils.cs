using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.Store
{
    internal class TaskUtils
    {
        public static double MaxPriceGoldInBothStores(RingsContainer container1, RingsContainer container2)
        {
            if (container1.MaxPriceGold() <= container2.MaxPriceGold())
                return container2.MaxPriceGold();
            else
                return container1.MaxPriceGold();
        }
        public static RingsContainer FindsMaxPriceGoldRing(RingsContainer filtered, RingsContainer container, double maxPrice)
        {
            for (int i = 0; i < container.Count; i++)
            {
                if (container.Get(i).Price.Equals(maxPrice))
                {
                    filtered.Add(container.Get(i));
                }
            }
            return filtered;
        }
        public static RingsContainer BothShopsSells(RingsContainer container1, RingsContainer container2)
        {
            RingsContainer Filtered = new RingsContainer();
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
