using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Players
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            PlayersContainer container = InOutUtils.ReadPlayers(@"Duom.txt");
            InOutUtils.PrintPlayers("Žaidėjai", container);
            TeamsRegister Teams = InOutUtils.ReadTeams(@"Duom2.txt");
            InOutUtils.PrintTeams("Komandos", Teams);
            Console.Write("Įveskite miestą kurio komandos žaidėjus norite atrinkti: ");
            string City = Console.ReadLine();
            TeamsRegister FilterdTeam = Teams.FilterTeam(City);
            Console.WriteLine(FilterdTeam.GetTeam(0).City);
            Console.WriteLine(FilterdTeam.GetTeam(0).TeamName);
            Console.WriteLine(container.Get(0).Team);
            Console.WriteLine(FilterdTeam.TeamCount());
            Console.WriteLine(container.Count);
            PlayersContainer FilteredPlayersByTeam = container.FilterPlayersByTeam(FilterdTeam);
            PlayersContainer FilteredPlayersByAvgAndPlayedGames = FilteredPlayersByTeam.FilterByAverageAndPlayedGames(Teams);
            InOutUtils.PrintFilteredPlayers("Atrinkti žaidėjai:", FilteredPlayersByAvgAndPlayedGames);
        }
    }
}
