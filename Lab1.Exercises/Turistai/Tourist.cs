using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turistai
{
    internal class Tourist
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public double Money { get; set; }
        public Tourist(string name, string lastName, double money)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Money = money;
        }
    }
}
