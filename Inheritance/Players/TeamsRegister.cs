using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    internal class TeamsRegister
    {
        private List<Team> AllTeams;
        public int Count { get; private set; }
        public TeamsRegister()
        {
            AllTeams = new List<Team>();
        }
        public void Add(Team team)
        {
            AllTeams.Add(team);
        }
        public int TeamCount()
        {
            return this.AllTeams.Count;
        }
        public Team GetTeam(int index)
        {
            return this.AllTeams[index];
        }
        public bool Contains(Team team)
        {
            return AllTeams.Contains(team);
        }
        public TeamsRegister FilterTeam(string City)
        {
            TeamsRegister Teams = new TeamsRegister();
            foreach (Team team in AllTeams)
            {
                if (team.City == City)
                {
                    Teams.Add(team);
                }
            }
            return Teams;
        }
    }
}
