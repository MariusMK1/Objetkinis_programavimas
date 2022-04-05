using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    internal class AnimalsComparatorByBirthDate : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            int dogcomp = a.BirthDate.CompareTo(b.BirthDate);
            if (dogcomp == 0)
            {
                int result = b.ID.CompareTo(a.ID);
                if (result == 0)
                {
                }
                return result;
            }
            return dogcomp;
        }
    }
}
