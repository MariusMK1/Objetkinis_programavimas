using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    internal class Refrigirator
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string EnergyClass { get; set; }
        public string MountingType { get; set; }
        public string Colour { get; set; }
        public HasFreezer HasFreezer { get; set; }
        public double Price { get; set; }
        public Refrigirator(string manufacturer, string model, int capacity, string energyClass, string mountingType, string colour, HasFreezer HasFreezer, double price)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Capacity = capacity;
            this.EnergyClass = energyClass;
            this.MountingType = mountingType;
            this.Colour = colour;
            this.HasFreezer = HasFreezer;
            this.Price = price;
        }
        public override bool Equals(object other)
        {
            return this.Model == ((Refrigirator)other).Model;
        }
        public override int GetHashCode()
        {
            return this.Model.GetHashCode();
        }
    }
}
