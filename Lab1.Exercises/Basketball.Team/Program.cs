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
            List<Player> allPlayers = InOutUtils.ReadPlayers(@"Duom.csv");
            InOutUtils.PrintPlayers(allPlayers);
            List<Player> oldestPlayers = TaskUtils.OldestPlayers(allPlayers);
            Console.WriteLine();
            Console.WriteLine("Vyriausi žaidėjai:");
            InOutUtils.PrintPlayers(oldestPlayers);
            Console.WriteLine();
            List<Player> PlayersByPosition = TaskUtils.FindPosition(allPlayers, "Puolėjas");
            InOutUtils.PrintPlayersByPosition(PlayersByPosition, "Puolėjas");
            List<Player> InvitedPlayers = TaskUtils.InvitedPlayers(allPlayers);
            InOutUtils.PrintInvitedPlayersToCSVFile("InvitedPlayers.csv", InvitedPlayers);
        }
    }
}
