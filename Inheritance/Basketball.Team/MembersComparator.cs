using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    public class MembersComparator
    {
        public virtual int Compare(Member a, Member b)
        {
            return a.CompareTo(b);
        }
    }
}
