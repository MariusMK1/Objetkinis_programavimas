using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    internal class RefrigiratorsContainer
    {
        private Refrigirator[] refrigirators;
        public int Count { get; private set; }
        public RefrigiratorsContainer()
        {
            this.refrigirators = new Refrigirator[16]; //default capacity
        }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public void Add(Refrigirator refrigirator)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.refrigirators[this.Count++] = refrigirator;
        }
        public void Put(int i, Refrigirator refrigirator)
        {
            this.Put(i, refrigirator);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Refrigirator refrigirator)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.refrigirators[i] = this.refrigirators[i - 1];
            }
            this.refrigirators[index] = refrigirator;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Refrigirator refrigirator)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.refrigirators[i].Equals(refrigirator))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.refrigirators[j] = this.refrigirators[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.refrigirators[i] = this.refrigirators[i + 1];
            }
            Count--;
        }
        public Refrigirator Get(int index)
        {
            return this.refrigirators[index];
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Refrigirator a = this.refrigirators[i];
                    Refrigirator b = this.refrigirators[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.refrigirators[i] = b;
                        this.refrigirators[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public bool Contains(Refrigirator refrigirator)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.refrigirators[i].Equals(refrigirator))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public RefrigiratorsContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.refrigirators = new Refrigirator[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Refrigirator[] temp = new Refrigirator[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.refrigirators[i];
                }
                this.Capacity = minimumCapacity;
                this.refrigirators = temp;
            }
        }
        public RefrigiratorsContainer(RefrigiratorsContainer container) : this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public RefrigiratorsContainer Intersect(RefrigiratorsContainer other)
        {
            RefrigiratorsContainer result = new RefrigiratorsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Refrigirator current = this.refrigirators[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public List<int> FindCapacities(List<int> Capacities)
        {
            for (int i = 0; i < this.Count; i++)
            {
                int capacity = this.Get(i).Capacity;
                if (!Capacities.Contains(capacity))        //uses List method Contains()
                {
                    Capacities.Add(capacity);
                }
            }
            return Capacities;
        }
        public double FindsSmallestPriceOFStandingNoFreezer()
        {
            double minPrice = double.MaxValue;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).MountingType.Contains("Pastatomas") && this.Get(i).HasFreezer == HasFreezer.True && minPrice > this.Get(i).Price)
                {
                    minPrice = this.Get(i).Price;
                }
            }
            return minPrice;
        }
        public RefrigiratorsContainer FilterWhiteA(RefrigiratorsContainer Filtered)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Colour.Contains("Balta") && this.Get(i).EnergyClass.Contains("A++") && !(Filtered.Contains(this.Get(i))))
                {
                    Filtered.Add(this.Get(i));
                }
            }
            return Filtered;
        }
    }
}
