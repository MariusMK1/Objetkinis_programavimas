using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Players
{
    internal class InOutUtils
    {
        public static PlayersContainer ReadPlayers(string fileName)
        {
            PlayersContainer players = new PlayersContainer();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string type = Values[0];
                string team = Values[1];
                string lastName = Values[2];
                string firstName = Values[3];
                DateTime birthDate = DateTime.Parse(Values[4]);
                int playedGames = int.Parse(Values[5]);
                int points = int.Parse(Values[6]);

                switch (type)
                {
                    case "Basketball":
                        int rebounds = int.Parse(Values[7]);
                        int assists = int.Parse(Values[8]);
                        BasketballPlayer bPlayer = new BasketballPlayer(team, lastName, firstName, birthDate, playedGames, points, rebounds, assists);
                        if (!players.Contains(bPlayer))
                        {
                            players.Add(bPlayer);
                        }
                        break;
                    case "Football":
                        int yCards = int.Parse(Values[7]);
                        FootballPlayer fPlayer = new FootballPlayer(team, lastName, firstName, birthDate, playedGames, points, yCards);
                        if (!players.Contains(fPlayer))
                        {
                            players.Add(fPlayer);
                        }
                        break;
                    default:
                        break; //unknown type
                }
            }
            return players;
        }
        public static void PrintPlayers(string label, PlayersContainer Players)
        {
            Console.WriteLine(new string('-', 85));
            Console.WriteLine("| {0,-81} |", label);
            Console.WriteLine(new string('-', 85));
            Console.WriteLine("| {0,-8} | {1,-15} | {2,-15} | {3,-12} | {4,6} | {5,10 } |", "Komanda", "Pavadė", "Vardas", "Gimimo data", "Taškai",  "suž. varž.");
            Console.WriteLine(new string('-', 85));
            for (int i = 0; i < Players.Count; i++)
            {
                Player player = Players.Get(i);
                Console.WriteLine("| {0,-8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,6} | {5,10} |", player.Team, player.LastName, player.FirstName, player.BirthDate, player.Points, player.PlayedGames);
            }
            Console.WriteLine(new string('-', 85));
        }
        public static TeamsRegister ReadTeams(string fileName)
        {
            TeamsRegister teams = new TeamsRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string teamName = Values[0];
                string city = Values[1];
                string coachFirstName = Values[2];
                string coachLastName = Values[3];
                int playedGames = int.Parse(Values[4]);
                Team team = new Team(teamName, city, coachFirstName, coachLastName, playedGames);
                if (!teams.Contains(team))
                {
                    teams.Add(team);
                }
            }
            return teams;
        }
        public static void PrintTeams(string label, TeamsRegister Teams)
        {
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("| {0,-66} |", label);
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("| {0,-8} | {1,-12} | {2,-12} | {3,-12} | {4,10} |", "Komanda", "Miestas", "Vardas", "pavardė", "suž. varž.");
            Console.WriteLine(new string('-', 70));
            for (int i = 0; i < Teams.TeamCount(); i++)
            {
                Team team = Teams.GetTeam(i);
                Console.WriteLine("| {0,-8} | {1,-12} | {2,-12} | {3,-12} | {4,10} |", team.TeamName, team.City, team.CoachName, team.CoachLName, team.GamesPlayed);
            }
            Console.WriteLine(new string('-', 70));
        }
        public static void PrintFilteredPlayers(string label, PlayersContainer Players)
        {
            if(Players != null)
            {
                Console.WriteLine(new string('-', 85));
                Console.WriteLine("| {0,-81} |", label);
                Console.WriteLine(new string('-', 85));
                Console.WriteLine("| {0,-8} | {1,-15} | {2,-15} | {3,-12} | {4,6} | {5,10 } |", "Komanda", "Pavadė", "Vardas", "Gimimo data", "Taškai", "suž. varž.");
                Console.WriteLine(new string('-', 85));
                for (int i = 0; i < Players.Count; i++)
                {
                    Player player = Players.Get(i);
                    Console.WriteLine("| {0,-8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,6} | {5,10} |", player.Team, player.LastName, player.FirstName, player.BirthDate, player.Points, player.PlayedGames);
                }
                Console.WriteLine(new string('-', 85));
            }
            else
            {
                Console.WriteLine("Tokio miesto žaidėjų kurie atitiktų kriterijus nėra");
            }
        }
    }
}
