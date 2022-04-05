using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class AnimalsComparatorByName : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            int dogcomp = a.Name.CompareTo(b.Name);
            if (dogcomp == 0)
            {
                int result = a.ID.CompareTo(b.ID);
                if (result == 0)
                {
                }
                return result;
            }
            return dogcomp;
        }
    }
}
