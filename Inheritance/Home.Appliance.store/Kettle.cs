using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    internal class Kettle : Device
    {
        public int Power { get; set; }
        public int Capacity { get; set; }
        public Kettle(string type, string manufacturer, string model, string energyClass, string colour, double price, int power, int capacity) : base(type, manufacturer, model, energyClass, colour, price)
        {
            this.Power = power;
            this.Capacity = capacity;
        }
        public override string ToString()
        {
            return string.Format("| {0,-10} | {1,-10} | {2,-15} | {3,-15} | {4,-10} | {5,8:f2} | {6,-5} | {7,-12} | {8,-13} | {9,7} | {10,6} | {11,5} | {12,5} | {13,12} |", Type, Manufacturer, Model, EnergyClass, Colour, Price, Capacity, " ", " ", " ", " ", " ", Power, " ");
        }
    }
}
