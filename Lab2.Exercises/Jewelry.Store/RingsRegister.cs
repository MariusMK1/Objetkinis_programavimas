using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.Store
{
    internal class RingsRegister
    {
        private List<Ring> AllRings;
        public RingsRegister()
        {
            AllRings = new List<Ring>();
        }
        public RingsRegister(List<Ring> Rings)
        {
            AllRings = new List<Ring>();
            foreach (Ring ring in Rings)
            {
                this.AllRings.Add(ring);
            }
        }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public void Add(Ring ring)
        {
            AllRings.Add(ring);
        }
        public int RingCount()
        {
            return this.AllRings.Count;
        }
        public Ring GetRing(int index)
        {
            return this.AllRings[index];
        }
        public bool Contains(Ring ring)
        {
            return AllRings.Contains(ring);
        }
        public List<Ring> FilterHighestPurityGold()
        {
            List<Ring> Filtered = new List<Ring>();
            foreach (Ring ring in AllRings)
            {
                if (ring.Purity.Equals(750) && ring.Metal.Equals("Auksas"))
                {
                    Filtered.Add(ring);
                }
            }
            return Filtered;
        }
        public List<Ring> FilterHighestPuritySilver()
        {
            List<Ring> Filtered = new List<Ring>();
            foreach (Ring ring in AllRings)
            {
                if (ring.Purity.Equals(925) && ring.Metal.Equals("Sidabras"))
                {
                    Filtered.Add(ring);
                }
            }
            return Filtered;
        }
        public List<Ring> FilterHighestPurityPlatinum()
        {
            List<Ring> Filtered = new List<Ring>();
            foreach (Ring ring in AllRings)
            {
                if (ring.Purity.Equals(950) && ring.Metal.Equals("Platina"))
                {
                    Filtered.Add(ring);
                }
            }
            return Filtered;
        }
        public List<Ring> FilterHighestPurityPalladium()
        {
            List<Ring> Filtered = new List<Ring>();
            foreach (Ring ring in AllRings)
            {
                if (ring.Purity.Equals(850) && ring.Metal.Equals("Paladis"))
                {
                    Filtered.Add(ring);
                }
            }
            return Filtered;
        }
        public int HowManyRingsHighestPurity()
        {
            int count = FilterHighestPurityGold().Count + FilterHighestPurityPalladium().Count + FilterHighestPurityPlatinum().Count + FilterHighestPuritySilver().Count;
            return count;
        }
        public double MaxPricePlatinum()
        {
            double maxPrice = 0;
            foreach (Ring ring in AllRings)
            if (maxPrice < ring.Price && ring.Metal == "Platina")
                {
                    maxPrice = ring.Price;
                }
            return maxPrice;
        }
        public RingsRegister FiltersBySizeAndPrice(RingsRegister filtered)
        {
            foreach (Ring ring in AllRings)
            {
                if(ring.Size >= 12 && ring.Size <= 13 && ring.Price <= 300)
                {
                    filtered.Add(ring);
                }
            }
            return filtered;
        }
    }
}
