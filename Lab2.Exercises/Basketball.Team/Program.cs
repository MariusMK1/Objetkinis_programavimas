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
            PlayerRegister register1 = InOutUtils.ReadPlayers(@"Duom.csv");
            PlayerRegister register2 = InOutUtils.ReadPlayers(@"Duom2.csv");
            InOutUtils.PrintPlayers(register1);
            InOutUtils.PrintPlayers(register2);
            //Filtering players by positions
            List<Player> FilteredByPosition1 = register1.FindPosition("Puolėjas");
            List<Player> FilteredByPosition2 = register2.FindPosition("Puolėjas");
            InOutUtils.PrintPlayersByPosition(FilteredByPosition1, "Puolėjas");
            InOutUtils.PrintPlayersByPosition(FilteredByPosition2, "Puolėjas");
            //Finding talest players
            int talest = TaskUtils.TalestInTwoRegisters(register1, register2);
            PlayerRegister register3 = new PlayerRegister();
            TaskUtils.Talest(register3, register1, talest);
            TaskUtils.Talest(register3, register2, talest);
            Console.WriteLine("Aukščiausi žaidėjai:");
            InOutUtils.PrintPlayers(register3);
            // Findig all the clubs
            List<string> Clubs = new List<string>();
            register1.FindClubs(Clubs);
            register2.FindClubs(Clubs);
            InOutUtils.PrintClubsToCSVFile("Klubai.csv", Clubs);
        }
    }
}
