using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    internal class OvenContainer
    {
        private Oven[] ovens;
        public int Count { get; private set; }
        public OvenContainer()
        {
            this.ovens = new Oven[16]; //default capacity
        }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public void Add(Oven oven)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.ovens[this.Count++] = oven;
        }
        public void Put(int i, Oven oven)
        {
            this.Put(i, oven);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Oven oven)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.ovens[i] = this.ovens[i - 1];
            }
            this.ovens[index] = oven;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Oven oven)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.ovens[i].Equals(oven))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.ovens[j] = this.ovens[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.ovens[i] = this.ovens[i + 1];
            }
            Count--;
        }
        public Oven Get(int index)
        {
            return this.ovens[index];
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Oven a = this.ovens[i];
                    Oven b = this.ovens[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.ovens[i] = b;
                        this.ovens[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public bool Contains(Oven oven)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.ovens[i].Equals(oven))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public OvenContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.ovens = new Oven[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Oven[] temp = new Oven[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.ovens[i];
                }
                this.Capacity = minimumCapacity;
                this.ovens = temp;
            }
        }
        public OvenContainer(OvenContainer container) : this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public OvenContainer Intersect(OvenContainer other)
        {
            OvenContainer result = new OvenContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Oven current = this.ovens[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public double MinPrice()
        {
            double price = int.MaxValue;
            for (int i = 0; i < this.Count; i++)
            {
                if (price > this.Get(i).Price && this.Get(i).EnergyClass == "A+")
                    price = this.Get(i).Price;
            }
            return price;
        }
        public OvenContainer OvenWithMinPriceOFA()
        {
            OvenContainer ovens = new OvenContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (MinPrice() == this.Get(i).Price && this.Get(i).EnergyClass == "A+")
                    ovens.Add(this.Get(i));
            }
            return ovens;
        }
    }
}
