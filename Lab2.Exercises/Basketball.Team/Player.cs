using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    internal class Player
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Height { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
        public InvitedOrNot InvitedOrNot { get; set; }
        public Captain Captain { get; set; }
        public Player (string name, string lastName, DateTime birthDate, int height, string position, string team, InvitedOrNot invitedOrNot, Captain captain)
        {
            this.Name = name;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Height = height;
            this.Position = position;
            this.Team = team;
            this.InvitedOrNot = invitedOrNot;
            this.Captain = captain;
        }
        public int CalculateAge()
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
}
