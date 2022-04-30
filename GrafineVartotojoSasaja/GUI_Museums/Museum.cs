using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Museums
{
    public class Museum
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        public int Monday { get; set; }
        public List<int> Week { get; set; }
        public double Price { get; set; }
        public string Guide { get; set; }
        public Museum(string name, string city, string type, List<int> week, double price, string guide)
        {
            this.Name = name;
            this.City = city;
            this.Type = type;
            this.Week = week;
            this.Price = price;
            this.Guide = guide;
        }
        public string WorkingOrNot(int i)
        {
            if (Week[i] == 1)
            {
                return "Opened";
            }
            else
            {
                return "Closed";
            }

        }
    }
}
