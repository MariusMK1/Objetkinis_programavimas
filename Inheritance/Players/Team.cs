using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    internal class Team
    {
        public string TeamName { get; set; }
        public string City { get; set; }
        public string CoachName { get; set; }
        public string CoachLName { get; set; }
        public int GamesPlayed { get; set; }
        public Team(string teamName, string city, string coachName, string coachLName, int gamesPlayed)
        {
            this.TeamName = teamName;
            this.City = city;
            this.CoachName = coachName;
            this.CoachLName = coachLName;
            this.GamesPlayed = gamesPlayed;
        }
        public override bool Equals(object other)
        {
            return this.TeamName == ((Team)other).TeamName;
        }
        public override int GetHashCode()
        {
            return this.TeamName.GetHashCode();
        }
    }
}
