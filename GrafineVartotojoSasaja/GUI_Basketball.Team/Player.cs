using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Basketball.Team
{
    class Player
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Height { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
        public InvitedOrNot InvitedOrNot { get; set; }
        public Captain Captain { get; set; }
        public Player(string name, string lastName, DateTime birthDate, int height, string position, string team, InvitedOrNot invitedOrNot, Captain captain)
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
        public override bool Equals(object other)
        {
            return this.LastName == ((Player)other).LastName;
        }
        public override int GetHashCode()
        {
            return this.LastName.GetHashCode();
        }
        public double CompareTo(Player other)
        {
            double studentcomp = other.Height.CompareTo(this.Height);
            if (studentcomp == 0)
            {
                double result = this.LastName.CompareTo(other.LastName);
                if (result == 0)
                {
                    double result2 = this.Name.CompareTo(other.Name);
                    if (result2 == 0)
                    {
                    }
                    return result2;
                }
                return result;
            }
            return studentcomp;
        }
    }
}
