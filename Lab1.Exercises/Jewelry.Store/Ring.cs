using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.Store
{
    internal class Ring
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Metal { get; set; }
        public double Weight { get; set; }
        public int Size { get; set; }
        public int Purity { get; set; }
        public double Price { get; set; }
        public Ring(string manufacturer, string model, string metal, double weight,int size, int purity, double price)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Metal = metal;
            this.Weight = weight;
            this.Size = size;
            this.Purity = purity;
            this.Price = price;
        }
    }
}
