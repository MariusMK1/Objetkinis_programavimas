using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewelry.Store
{
    internal class RingsContainer
    {
        private Ring[] rings;
        public int Count { get; private set; }
        public RingsContainer()
        {
            this.rings = new Ring[16]; //default capacity
        }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public void Add(Ring ring)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.rings[this.Count++] = ring;
        }
        public void Put(int i, Ring ring)
        {
            this.Put(i, ring);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Ring ring)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.rings[i] = this.rings[i - 1];
            }
            this.rings[index] = ring;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Ring ring)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.rings[i].Equals(ring))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.rings[j] = this.rings[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.rings[i] = this.rings[i + 1];
            }
            Count--;
        }
        public Ring Get(int index)
        {
            return this.rings[index];
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Ring a = this.rings[i];
                    Ring b = this.rings[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.rings[i] = b;
                        this.rings[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public bool Contains(Ring ring)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.rings[i].Equals(ring))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public RingsContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.rings = new Ring[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Ring[] temp = new Ring[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.rings[i];
                }
                this.Capacity = minimumCapacity;
                this.rings = temp;
            }
        }
        public RingsContainer(RingsContainer container) : this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public RingsContainer Intersect(RingsContainer other)
        {
            RingsContainer result = new RingsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Ring current = this.rings[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public double MaxPriceGold()
        {
            double maxPrice = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (maxPrice < this.Get(i).Price && this.Get(i).Metal.Contains("Auksas"))
                {
                    maxPrice = this.Get(i).Price;
                }
            }
            return maxPrice;
        }
        public List<Ring> FilterHighestPurityGold()
        {
            List<Ring> Filtered = new List<Ring>();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Purity.Equals(750) && this.Get(i).Metal.Equals("Auksas"))
                {
                    Filtered.Add(this.Get(i));
                }
            }
            return Filtered;
        }
        public List<Ring> FilterHighestPuritySilver()
        {
            List<Ring> Filtered = new List<Ring>();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Purity.Equals(925) && this.Get(i).Metal.Equals("Sidabras"))
                {
                    Filtered.Add(this.Get(i));
                }
            }
            return Filtered;
        }
        public List<Ring> FilterHighestPurityPlatinum()
        {
            List<Ring> Filtered = new List<Ring>();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Purity.Equals(950) && this.Get(i).Metal.Equals("Platina"))
                {
                    Filtered.Add(this.Get(i));
                }
            }
            return Filtered;
        }
        public List<Ring> FilterHighestPurityPalladium()
        {
            List<Ring> Filtered = new List<Ring>();
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Purity.Equals(850) && this.Get(i).Metal.Equals("Paladis"))
                {
                    Filtered.Add(this.Get(i));
                }
            }
            return Filtered;
        }
        public int HowManyRingsHighestPurity()
        {
            int count = FilterHighestPurityGold().Count + FilterHighestPurityPalladium().Count + FilterHighestPurityPlatinum().Count + FilterHighestPuritySilver().Count;
            return count;
        }
        public RingsContainer FiltersBySizeAndPrice(RingsContainer filtered)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Size >= 12 && this.Get(i).Size <= 13 && this.Get(i).Price <= 300)
                {
                    filtered.Add(this.Get(i));
                }
            }
            return filtered;
        }
    }
}
