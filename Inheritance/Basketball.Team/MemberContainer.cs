using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    internal class MemberContainer
    {
        private Member[] members;
        public int Count { get; private set; }
        public MemberContainer()
        {
            this.members = new Member[16]; //default capacity
        }
        public int Year { get; set; }
        public void Add(Member member)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.members[this.Count++] = member;
        }
        public void Put(int i, Member member)
        {
            this.Put(i, member);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Member member)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.members[i] = this.members[i - 1];
            }
            this.members[index] = member;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Member member)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.members[i].Equals(member))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.members[j] = this.members[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.members[i] = this.members[i + 1];
            }
            Count--;
        }
        public Member Get(int index)
        {
            return this.members[index];
        }
        public void Sort(MembersComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Member a = this.members[i];
                    Member b = this.members[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.members[i] = b;
                        this.members[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public bool Contains(Member member)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.members[i].Equals(member))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public MemberContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.members = new Member[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Member[] temp = new Member[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.members[i];
                }
                this.Capacity = minimumCapacity;
                this.members = temp;
            }
        }
        public MemberContainer(MemberContainer container) : this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public MemberContainer Intersect(MemberContainer other)
        {
            MemberContainer result = new MemberContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Member current = this.members[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public MemberContainer FindMembersInAllCamps(MemberContainer container2, MemberContainer container3)
        {
            MemberContainer filtered = new MemberContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (container2.Contains(this.Get(i)) && container3.Contains(this.Get(i)))
                {
                    filtered.Add(this.Get(i));
                }
            }
            return filtered;
        }
    }
}
