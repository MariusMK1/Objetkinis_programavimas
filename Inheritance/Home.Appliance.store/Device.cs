using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    public abstract class Device
    {
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string EnergyClass { get; set; }
        public string Colour { get; set; }
        public double Price { get; set; }
        public Device(string type, string manufacturer, string model, string energyClass, string colour, double price)
        {
            this.Type = type;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.EnergyClass = energyClass;
            this.Colour = colour;
            this.Price = price;
        }
        public override bool Equals(object other)
        {
            return this.Model == ((Device)other).Model;
        }
        public override int GetHashCode()
        {
            return this.Model.GetHashCode();
        }
        public double CompareTo(Device other)
        {
            double studentcomp = this.Manufacturer.CompareTo(other.Manufacturer);
            if (studentcomp == 0)
            {
                double result = this.Model.CompareTo(other.Model);
                if (result == 0)
                {
                    double result2 = this.Price.CompareTo(other.Price);
                    if (result2 == 0)
                    {
                    }
                    return result2;
                }
                return result;
            }
            return studentcomp;
        }
        public static string PrintFormat()
        {
            return string.Format("| {0,-10} | {1,-10} | {2,-15} | {3,-15} | {4,-10} | {5,8} | {6,-5} | {7,-12} | {8,-13} | {9,7} | {10,6} | {11,5} | {12,5} | {13,12} |", "Tipas", "Gamintojas", "Modelis", "Energijos klasė", "Spalva", "Kaina", "Talpa", "Mont. Tipas", "Turi šaldiklį", "Aukštis", "Plotis", "Gylis", "Galia", "Programų sk.");
        }
    }
}
