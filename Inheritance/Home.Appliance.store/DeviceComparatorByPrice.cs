using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    public class DeviceComparatorByPrice : DeviceComparator
    {
        public override int Compare(Device a, Device b)
        {
            int membcomp = a.Price.CompareTo(b.Price);
            if (membcomp == 0)
            {
                int result = a.Manufacturer.CompareTo(b.Manufacturer);
                if (result == 0)
                {
                }
                return result;
            }
            return membcomp;
        }
    }
}
