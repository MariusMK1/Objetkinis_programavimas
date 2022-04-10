using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    public class MembersComparatorByAge : MembersComparator
    {
        public override int Compare(Member a, Member b)
        {
            int membcomp = b.CalculateAge().CompareTo(a.CalculateAge());
            if (membcomp == 0)
            {
            }
            return membcomp;
        }
    }
}
