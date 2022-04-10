using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    internal class StaffContainer
    {
        private Staff[] staffs;
        public int Count { get; private set; }
        public StaffContainer()
        {
            this.staffs = new Staff[16]; //default capacity
        }
        public int Year { get; set; }
        public void Add(Staff staff)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.staffs[this.Count++] = staff;
        }
        public void Put(int i, Staff staff)
        {
            this.Put(i, staff);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Staff staff)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.staffs[i] = this.staffs[i - 1];
            }
            this.staffs[index] = staff;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Staff staff)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.staffs[i].Equals(staff))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.staffs[j] = this.staffs[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.staffs[i] = this.staffs[i + 1];
            }
            Count--;
        }
        public Staff Get(int index)
        {
            return this.staffs[index];
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Staff a = this.staffs[i];
                    Staff b = this.staffs[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.staffs[i] = b;
                        this.staffs[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public bool Contains(Staff staff)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.staffs[i].Equals(staff))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public StaffContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.staffs = new Staff[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Staff[] temp = new Staff[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.staffs[i];
                }
                this.Capacity = minimumCapacity;
                this.staffs = temp;
            }
        }
        public StaffContainer(StaffContainer container) : this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public StaffContainer Intersect(StaffContainer other)
        {
            StaffContainer result = new StaffContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Staff current = this.staffs[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public StaffContainer FindCoach()
        {
            StaffContainer coaches = new StaffContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (!coaches.Contains(this.Get(i)) && this.Get(i).Duties.Equals("Treneris"))
                {
                    coaches.Add(this.Get(i));
                }
            }
            return coaches;
        }
    }
}
