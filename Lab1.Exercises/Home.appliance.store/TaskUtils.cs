using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.appliance.store
{
    internal class TaskUtils
    {
        public static List<int> FindCapacities(List<Refrigirator> Refs)
        {
            List<int> capacities = new List<int>();
            foreach (Refrigirator refrigirator in Refs)
            {
                int capacity = refrigirator.Capacity;
                if (!capacities.Contains(capacity))
                {
                    capacities.Add(capacity);
                }
            }
            return capacities;
        }
        public static double FindsSmallestPriceOFStandingNoFreezer(List<Refrigirator> Refs)
        {
            double minPrice = int.MaxValue;
            foreach (Refrigirator refrigirator in Refs)
            {
                if(refrigirator.MountingType.Contains("Pastatomas") && refrigirator.HasFreezer == HasFreezer.True && minPrice > refrigirator.Price)
                {
                    minPrice = refrigirator.Price;
                }
            }
            return minPrice;
        }
        public static List<Refrigirator> FindsBySmalestPriceOfStandigNoFrezer(List<Refrigirator> Refs)
        {
            List<Refrigirator> Filtered = new List<Refrigirator>();
            foreach (Refrigirator refrigirator in Refs)
            {
                if (refrigirator.MountingType.Contains("Pastatomas") && refrigirator.HasFreezer == HasFreezer.True && FindsSmallestPriceOFStandingNoFreezer(Refs) == refrigirator.Price)
                {
                    Filtered.Add(refrigirator);
                }
            }
            return Filtered;
        }
        public static List<Refrigirator> FindsByColourAndEnergyClass(List<Refrigirator> Refs, string energyClass, string Colour)
        {
            List<Refrigirator> Filtered = new List<Refrigirator>();
            foreach (Refrigirator refrigirator in Refs)
            {
                if (refrigirator.Colour.Contains(Colour) && refrigirator.EnergyClass.Contains(energyClass))
                {
                    Filtered.Add(refrigirator);
                }
            }
            return Filtered;
        }
    }
}
