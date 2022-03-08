using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    internal class Director
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public Director(string name, int count)
        {
            this.Name = name;
            this.Count = count;
        }
    }
}
