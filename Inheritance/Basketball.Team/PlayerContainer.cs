using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    internal class PlayerContainer
    {
        private Player[] players;
        public int Count { get; private set; }
        public PlayerContainer()
        {
            this.players = new Player[16]; //default capacity
        }
        public int Year { get; set; }
        public void Add(Player player)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.players[this.Count++] = player;
        }
        public void Put(int i, Player player)
        {
            this.Put(i, player);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Player player)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.players[i] = this.players[i - 1];
            }
            this.players[index] = player;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Player player)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.players[i].Equals(player))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.players[j] = this.players[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.players[i] = this.players[i + 1];
            }
            Count--;
        }
        public Player Get(int index)
        {
            return this.players[index];
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Player a = this.players[i];
                    Player b = this.players[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.players[i] = b;
                        this.players[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public bool Contains(Player player)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.players[i].Equals(player))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public PlayerContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.players = new Player[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Player[] temp = new Player[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.players[i];
                }
                this.Capacity = minimumCapacity;
                this.players = temp;
            }
        }
        public PlayerContainer(PlayerContainer container) : this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public PlayerContainer Intersect(PlayerContainer other)
        {
            PlayerContainer result = new PlayerContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Player current = this.players[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public PlayerContainer FindPosition(string position, PlayerContainer FilteredByPosition)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Position.Contains(position) && !FilteredByPosition.Contains(this.Get(i)))
                {
                    FilteredByPosition.Add(this.Get(i));
                }
            }
            return FilteredByPosition;
        }
        public PlayerContainer FilterInvited()
        {
            PlayerContainer Filtered = new PlayerContainer();
            for (int i = 0; i < this.Count; i++)
            {
                if (!(this.Get(i).InvitedOrNot == 0))
                {
                    Filtered.Add(this.Get(i));
                }
            }
            return Filtered;
        }
    }
}
