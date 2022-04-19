using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    internal class PlayersContainer
    {
        private Player[] players;
        public int Count { get; private set; }
        public PlayersContainer()
        {
            this.players = new Player[16]; //default capacity
        }
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
        public PlayersContainer(int capacity = 16)
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
        public PlayersContainer FilterPlayersByTeam(TeamsRegister team)
        {
            PlayersContainer players = new PlayersContainer();
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = 0; j < team.TeamCount(); j++)
                {
                    if (this.Get(i).Team == team.GetTeam(j).TeamName)
                    {
                        players.Add(this.Get(i));
                    }
                }
            }
            return players;
        }
        public double FindsAveragePoints()
        {
            int sum = 0;
            for (int i = 0; i < this.Count; i++)
            {
                sum += this.Get(i).Points;
            }
            return sum / this.Count;
        }
        public PlayersContainer FilterByAverageAndPlayedGames(TeamsRegister team)
        {
            PlayersContainer players = new PlayersContainer();
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = 0; j < team.TeamCount(); j++)
                {
                    if (this.Get(i).PlayedGames.Equals(team.GetTeam(j).GamesPlayed) && this.Get(i).Points >= this.FindsAveragePoints())
                    {
                        players.Add(this.Get(i));
                    }
                }
            }
            return players;
        }
        public PlayersContainer FilterPlayersByTeam(PlayersContainer players)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Team == "Žalgiris")
                {
                        players.Add(this.Get(i));
                }
            }
            return players;
        }
    }
}
