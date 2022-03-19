using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    internal class PlayerRegister
    {
        private List<Player> AllPlayers;
        public PlayerRegister()
        {
            AllPlayers = new List<Player>();
        }
        public PlayerRegister(List<Player> Players)
        {
            AllPlayers = new List<Player>();
            foreach (Player player in Players)
            {
                this.AllPlayers.Add(player);
            }
        }
        public void Add(Player player)
        {
            AllPlayers.Add(player);
        }
        public int PlayersCount()
        {
            return this.AllPlayers.Count;
        }
        public Player GetPlayer(int index)
        {
            return this.AllPlayers[index];
        }
        public bool Contains(Player player)
        {
            return AllPlayers.Contains(player);
        }
        public List<Player> FindPosition(string position)
        {
            List<Player> FilteredByPosition = new List<Player>();
            foreach (Player player in AllPlayers)
            {
                if (player.Position == position && !FilteredByPosition.Contains(player))
                {
                    FilteredByPosition.Add(player);
                }
            }
            return FilteredByPosition;
        }
        public int FindsTalestPlayer()
        {
            int talest = int.MinValue;
            foreach (Player player in AllPlayers)
            {
                if (player.Height > talest)
                    talest = player.Height;
            }
            return talest;
        }
        public List<string> FindClubs(List<string> Clubs)
        {
            foreach (Player player in this.AllPlayers)
            {
                string club = player.Team;
                if (!Clubs.Contains(club))        //uses List method Contains()
                {
                    Clubs.Add(club);
                }
            }
            return Clubs;
        }
    }
}
