using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    internal class Fridge : Device
    {
        public int Capacity { get; set; }
        public string MountingType { get; set; }
        public HasFreezer HasFreezer { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public Fridge(string type, string manufacturer, string model, string energyClass, string colour, double price, int capacity, string mountingType, HasFreezer hasFreezer, double height, double width, double length) : base(type, manufacturer, model, energyClass, colour, price)
        {
            this.Capacity = capacity;
            this.MountingType = mountingType;
            this.HasFreezer = hasFreezer;
            this.Height = height;
            this.Width = width;
            this.Length = length;
        }
        public override string ToString()
        {
            return string.Format("| {0,-10} | {1,-10} | {2,-15} | {3,-15} | {4,-10} | {5,8:f2} | {6,-5} | {7,-12} | {8,-13} | {9,7:f2} | {10,6:f2} | {11,5:f2} | {12,5} | {13,12} |", Type, Manufacturer, Model, EnergyClass, Colour, Price, Capacity, MountingType, HasFreezer, Height, Width, Length, " ", " ");
        }
    }
}
