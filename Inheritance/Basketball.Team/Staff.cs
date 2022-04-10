using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    internal class Staff : Member
    {
        public string Duties { get; set; }
        public Staff(string type, string name, string lastName, DateTime birthDate, string duties) : base(type, name, lastName, birthDate)
        {
            this.Duties = duties;
        }
    }
}
