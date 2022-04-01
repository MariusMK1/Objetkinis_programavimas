using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basketball.Team
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            //Reading and printing initial data
            PlayerContainer container1 = InOutUtils.ReadPlayers(@"Duom.csv");
            PlayerContainer container2 = InOutUtils.ReadPlayers(@"Duom2.csv");
            InOutUtils.PrintPlayers(container1);
            InOutUtils.PrintPlayers(container2);
            //Finding talest players
            int talest = TaskUtils.TalestInTwoContainers(container1, container2);
            PlayerContainer container3 = new PlayerContainer();
            TaskUtils.Talest(container3, container1, talest);
            TaskUtils.Talest(container3, container2, talest);
            Console.WriteLine("Aukščiausi žaidėjai:");
            InOutUtils.PrintPlayers(container3);
            //Filtering players by positions
            PlayerContainer FilteredByPosition = new PlayerContainer();
            container1.FindPosition("Puolėjas", FilteredByPosition);
            container2.FindPosition("Puolėjas", FilteredByPosition);
            FilteredByPosition.Sort();
            InOutUtils.PrintPlayersByPosition(FilteredByPosition, "Puolėjas");
            //Fitering players who were selected to the national team
            PlayerContainer container4 = container1.FilterInvited();
            PlayerContainer container5 = container2.FilterInvited();
            InOutUtils.PrintPlayersToCSVFile("Rinktinė1.csv", container4);
            InOutUtils.PrintPlayersToCSVFile("Rinktinė2.csv", container5);
            // Findig all the clubs
            List<string> Clubs = new List<string>();
            container1.FindClubs(Clubs);
            container2.FindClubs(Clubs);
            InOutUtils.PrintClubsToCSVFile("Klubai.csv", Clubs);
        }
    }
}
