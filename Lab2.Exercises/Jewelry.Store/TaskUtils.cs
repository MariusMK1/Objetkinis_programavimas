using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.Store
{
    internal class TaskUtils
    {
        public static double MaxPricePlatinumInBothStores(RingsRegister register1, RingsRegister register2)
        {
            if (register1.MaxPricePlatinum() <= register2.MaxPricePlatinum())
                return register2.MaxPricePlatinum();
            else
                return register1.MaxPricePlatinum();
        }
        public static RingsRegister FindsMaxPricePlatinumRing(RingsRegister filtered, RingsRegister register, double maxPrice)
        {
            for (int i = 0; i < register.RingCount(); i++)
            {
                if (register.GetRing(i).Price.Equals(maxPrice))
                {
                    filtered.Add(register.GetRing(i));
                }
            }
            return filtered;
        }
    }
}
