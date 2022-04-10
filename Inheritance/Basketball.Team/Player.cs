using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    internal class Player : Member
    {
        public int Height { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
        public InvitedOrNot InvitedOrNot { get; set; }
        public Captain Captain { get; set; }
        public Player(string type, string name, string lastName, DateTime birthDate, int height, string position, string team, InvitedOrNot invitedOrNot, Captain captain) : base(type, name, lastName, birthDate)
        {
            this.Height = height;
            this.Position = position;
            this.Team = team;
            this.InvitedOrNot = invitedOrNot;
            this.Captain = captain;
        }
    }
}
