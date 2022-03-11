using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    internal class TaskUtils
    {
        public static int FindOldestAge(List<Player> Players)
        {
            int oldestAge = 0;
            foreach (Player player in Players)
            {
                if (oldestAge < player.CalculateAge())
                    oldestAge = player.CalculateAge();
            }
            return oldestAge;

        }
        public static List<Player> OldestPlayers(List<Player> Players)
        {
            List<Player> Filtered = new List<Player>();
            foreach(Player player in Players)
            {
                if(FindOldestAge(Players) == player.CalculateAge())
                {
                    Filtered.Add(player);
                }
            }
            return Filtered;
        }
        public static List<Player> FindPosition(List<Player> Players, string position)
        {
            List<Player> Filtered = new List<Player>();
            foreach (Player player in Players)
            {
                if (player.Position.Contains(position))
                {
                    Filtered.Add(player);
                }
            }
            return Filtered;
        }
        public static List<Player> InvitedPlayers(List<Player> Players)
        {
            List<Player> Filtered = new List<Player>();
            foreach (Player player in Players)
            {
                if (player.InvitedOrNot == InvitedOrNot.Pakviestas)
                {
                    Filtered.Add(player);
                }
            }
            return Filtered;
        }
    }
}
