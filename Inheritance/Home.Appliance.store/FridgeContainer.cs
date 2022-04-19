using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    internal class FridgeContainer
    {
        private Fridge[] fridges;
        public int Count { get; private set; }
        public FridgeContainer()
        {
            this.fridges = new Fridge[16]; //default capacity
        }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public void Add(Fridge fridge)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.fridges[this.Count++] = fridge;
        }
        public void Put(int i, Fridge fridge)
        {
            this.Put(i, fridge);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Fridge fridge)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.fridges[i] = this.fridges[i - 1];
            }
            this.fridges[index] = fridge;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Fridge fridge)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.fridges[i].Equals(fridge))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.fridges[j] = this.fridges[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.fridges[i] = this.fridges[i + 1];
            }
            Count--;
        }
        public Fridge Get(int index)
        {
            return this.fridges[index];
        }
        public void Sort(DeviceComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Fridge a = this.fridges[i];
                    Fridge b = this.fridges[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.fridges[i] = b;
                        this.fridges[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public bool Contains(Fridge fridge)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.fridges[i].Equals(fridge))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public FridgeContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.fridges = new Fridge[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Fridge[] temp = new Fridge[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.fridges[i];
                }
                this.Capacity = minimumCapacity;
                this.fridges = temp;
            }
        }
        public FridgeContainer(FridgeContainer container) : this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public FridgeContainer Intersect(FridgeContainer other)
        {
            FridgeContainer result = new FridgeContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Fridge current = this.fridges[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public List<string> AllFridgeColours()
        {
            List <string> colours = new List<string> ();
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
            for(int i = 0; i < this.Count; i++)
            {
                if(price > this.Get(i).Price && this.Get(i).EnergyClass == "A+")
                    price = this.Get(i).Price;
            }
            return price;
        }
        public FridgeContainer FridgeWithMinPriceOFA()
        {
            FridgeContainer Fridges = new FridgeContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (MinPrice() == this.Get(i).Price && this.Get(i).EnergyClass == "A+")
                    Fridges.Add(this.Get(i));
            }
            return Fridges;
        }
        public FridgeContainer FilterBySize()
        {
            FridgeContainer Fridges = new FridgeContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if(this.Get(i).Width >= 0.52 && this.Get(i).Width <= 0.56)
                {
                    Fridges.Add(this.Get(i));
                }
            }
            return Fridges;
        }
    }
}
