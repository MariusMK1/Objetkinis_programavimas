using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    public abstract class Player
    {
        public string Team { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public int PlayedGames  { get; set; }
        public int Points { get; set; }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDate.Year;
                if (this.BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }
        public Player(string team, string lastName, string firstName, DateTime birthDate, int playedGames, int points)
        {
            this.Team = team;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.BirthDate = birthDate;
            this.PlayedGames = playedGames;
            this.Points = points;
        }
        public override bool Equals(object other)
        {
            return this.LastName == ((Player)other).LastName;
        }
        public override int GetHashCode()
        {
            return this.LastName.GetHashCode();
        }
    }
}
