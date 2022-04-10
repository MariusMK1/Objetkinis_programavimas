using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public class BasketballPlayer : Player
    {
        public int Rebounds { get; set; }
        public int Assists { get; set; }
        public BasketballPlayer(string team, string lastName, string firstName, DateTime birthDate, int playedGames, int points, int rebounds, int assists) : base(team, lastName, firstName, birthDate, playedGames, points)
        {
            this.Rebounds = rebounds;
            this.Assists = assists;
        }
    }
}
