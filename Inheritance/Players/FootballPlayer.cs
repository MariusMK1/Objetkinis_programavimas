using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    internal class FootballPlayer : Player
    {
        public int YCards { get; set; }
        public FootballPlayer(string team, string lastName, string firstName, DateTime birthDate, int playedGames, int points, int yCards) : base(team, lastName, firstName, birthDate, playedGames, points)
        {
            this.YCards = yCards;
        }
    }
}
