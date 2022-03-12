using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.Store
{
    internal class TaskUtils
    {
        public static double FindMaxWeight(List<Ring> Rings)
        {
            double MaxWeight = 0;
            foreach (Ring ring in Rings)
            {
                if (MaxWeight < ring.Weight)
                {
                    MaxWeight = ring.Weight;
                }
            }
            return MaxWeight;
        }
        public static List<Ring> FilterByMaxWeight(List<Ring> Rings)
        {
            List<Ring> Filtered = new List<Ring>();
            foreach (Ring ring in Rings)
            {
                if (ring.Weight == FindMaxWeight(Rings))
                {
                    Filtered.Add(ring);
                }
            }
            return Filtered;
        }
        public static List<Ring> FilterHighestPurityGold(List<Ring> Rings)
        {
            List<Ring> Filtered = new List<Ring>();
            foreach (Ring ring in Rings)
            {
                if (ring.Purity.Equals(750) && ring.Metal.Equals("Auksas"))
                {
                    Filtered.Add(ring);
                }
            }
            return Filtered;
        }
        public static List<Ring> FilterHighestPuritySilver(List<Ring> Rings)
        {
            List<Ring> Filtered = new List<Ring>();
            foreach (Ring ring in Rings)
            {
                if (ring.Purity.Equals(925) && ring.Metal.Equals("Sidabras"))
                {
                    Filtered.Add(ring);
                }
            }
            return Filtered;
        }
        public static List<Ring> FilterHighestPurityPlatinum(List<Ring> Rings)
        {
            List<Ring> Filtered = new List<Ring>();
            foreach (Ring ring in Rings)
            {
                if (ring.Purity.Equals(950) && ring.Metal.Equals("Platina"))
                {
                    Filtered.Add(ring);
                }
            }
            return Filtered;
        }
        public static List<Ring> FilterHighestPurityPalladium(List<Ring> Rings)
        {
            List<Ring> Filtered = new List<Ring>();
            foreach (Ring ring in Rings)
            {
                if (ring.Purity.Equals(850) && ring.Metal.Equals("Paladis"))
                {
                    Filtered.Add(ring);
                }
            }
            return Filtered;
        }
        public static int HowManyRingsHighestPurity(List<Ring> Filtered1, List<Ring> Filtered2, List<Ring> Filtered3, List<Ring> Filtered4)
        {
            int count = Filtered1.Count + Filtered2.Count + Filtered3.Count + Filtered4.Count;
            return count;
        }
        public static List<string> FindMetals(List<Ring> Rings)
        {
            List<string> Metals= new List<string>();
            foreach (Ring ring in Rings)
            {
                string metal = ring.Metal;
                if (!Metals.Contains(metal))
                {
                    Metals.Add(metal);
                }
            }
            return Metals;
        }
    }
}
