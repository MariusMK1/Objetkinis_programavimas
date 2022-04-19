using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    internal class KettleContainer
    {
        private Kettle[] kettles;
        public int Count { get; private set; }
        public KettleContainer()
        {
            this.kettles = new Kettle[16]; //default capacity
        }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public void Add(Kettle kettle)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.kettles[this.Count++] = kettle;
        }
        public void Put(int i, Kettle kettle)
        {
            this.Put(i, kettle);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Kettle kettle)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.kettles[i] = this.kettles[i - 1];
            }
            this.kettles[index] = kettle;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Kettle kettle)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.kettles[i].Equals(kettle))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.kettles[j] = this.kettles[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.kettles[i] = this.kettles[i + 1];
            }
            Count--;
        }
        public Kettle Get(int index)
        {
            return this.kettles[index];
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Kettle a = this.kettles[i];
                    Kettle b = this.kettles[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.kettles[i] = b;
                        this.kettles[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public bool Contains(Kettle kettle)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.kettles[i].Equals(kettle))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public KettleContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.kettles = new Kettle[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Kettle[] temp = new Kettle[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.kettles[i];
                }
                this.Capacity = minimumCapacity;
                this.kettles = temp;
            }
        }
        public KettleContainer(KettleContainer container) : this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public KettleContainer Intersect(KettleContainer other)
        {
            KettleContainer result = new KettleContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Kettle current = this.kettles[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public List<string> AllKettleColours()
        {
            List<string> colours = new List<string>();
            for (int i = 0; i < this.Count; i++)
            {
                if (!colours.Contains(this.Get(i).Colour))
                {
                    colours.Add(this.Get(i).Colour);
                }
            }
            return colours;
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
        public KettleContainer KettleWithMinPriceOFA()
        {
            KettleContainer Kettles = new KettleContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (MinPrice() == this.Get(i).Price && this.Get(i).EnergyClass == "A+")
                    Kettles.Add(this.Get(i));
            }
            return Kettles;
        }
    }
}
