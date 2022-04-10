using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Appliance.store
{
    internal class DeviceContainer
    {
        private Device[] devices;
        public int Count { get; private set; }
        public DeviceContainer()
        {
            this.devices = new Device[16]; //default capacity
        }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public void Add(Device device)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.devices[this.Count++] = device;
        }
        public void Put(int i, Device device)
        {
            this.Put(i, device);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Device device)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.devices[i] = this.devices[i - 1];
            }
            this.devices[index] = device;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Device device)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.devices[i].Equals(device))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.devices[j] = this.devices[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.devices[i] = this.devices[i + 1];
            }
            Count--;
        }
        public Device Get(int index)
        {
            return this.devices[index];
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Device a = this.devices[i];
                    Device b = this.devices[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.devices[i] = b;
                        this.devices[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public bool Contains(Device device)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.devices[i].Equals(device))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public DeviceContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.devices = new Device[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Device[] temp = new Device[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.devices[i];
                }
                this.Capacity = minimumCapacity;
                this.devices = temp;
            }
        }
        public DeviceContainer(DeviceContainer container) : this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public DeviceContainer Intersect(DeviceContainer other)
        {
            DeviceContainer result = new DeviceContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Device current = this.devices[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        //public List<int> FindCapacities(List<int> Capacities)
        //{
        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        int capacity = this.Get(i).Capacity;
        //        if (!Capacities.Contains(capacity))        //uses List method Contains()
        //        {
        //            Capacities.Add(capacity);
        //        }
        //    }
        //    return Capacities;
        //}
        //public double FindsSmallestPriceOFStandingNoFreezer()
        //{
        //    double minPrice = double.MaxValue;
        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        if (this.Get(i).MountingType.Contains("Pastatomas") && this.Get(i).HasFreezer == HasFreezer.True && minPrice > this.Get(i).Price)
        //        {
        //            minPrice = this.Get(i).Price;
        //        }
        //    }
        //    return minPrice;
        //}
        //public DeviceContainer FilterWhiteA(DeviceContainer Filtered)
        //{
        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        if (this.Get(i).Colour.Contains("Balta") && this.Get(i).EnergyClass.Contains("A++") && !(Filtered.Contains(this.Get(i))))
        //        {
        //            Filtered.Add(this.Get(i));
        //        }
        //    }
        //    return Filtered;
        //}
    }
}
